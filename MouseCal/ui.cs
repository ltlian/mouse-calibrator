using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MouseCalibrator

/*
MouseCalibrator is a simple utility which can be used to fire off a set amount
of mickeys.

By finding a value that represents a 360 degree turn in first
person games, this value can be used in other games to normalize the mouselook
sensitivity independently of the operating system's adjusted speeds and
acceleration.
*/

{
    public partial class MouseCal : Form
    /// <summary>
    /// The Mousecal class contains the default values and handler functions
    /// for the UI form.
    /// 
    /// Based on the following example:
    /// https://www.fluxbytes.com/csharp/how-to-register-a-global-hotkey-for-your-application-in-c/
    /// </summary>
    {

        private int mickeyValueDefault = 5000;

        [DllImport("User32.dll", EntryPoint = "mouse_event", CallingConvention = CallingConvention.Winapi)]
        internal static extern void Mouse_Event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("User32.dll", EntryPoint = "GetSystemMetrics", CallingConvention = CallingConvention.Winapi)]
        internal static extern int InternalGetSystemMetrics(int value);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646309(v=vs.85).aspx
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646327(v=vs.85).aspx
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IDictionary<CheckBox, KeyModifier> CheckBoxModifiers;

        private enum KeyModifier
        {
            Alt = 1,
            Control = 2,
            Shift = 4
        }

        // By assigning the arrow key ids to be mutually negative, the value
        // can be used to multiply the input argument for Mouse_Event()
        private const int leftArrow = -1;
        private const int rightArrow = 1;

        public MouseCal()
        {
            InitializeComponent();

            mickeyInput.Value = mickeyValueDefault;

            CheckBoxModifiers = new Dictionary<CheckBox, KeyModifier>
            {
                { checkBoxA, KeyModifier.Alt },
                { checkBoxC, KeyModifier.Control },
                { checkBoxS, KeyModifier.Shift }
            };
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Mouse_Event(0x0001, m.WParam.ToInt32()*(int)mickeyInput.Value, 0, 0, 0);
            }
        }

        private void CheckBoxUpdated(object sender, EventArgs e)
        {
            int modifiers = 0;

            // The modifier keycode is a bitwise 'or' of the KeyModifier enum values.
            foreach (KeyValuePair<CheckBox, KeyModifier> pair in CheckBoxModifiers)
            {
                modifiers |= pair.Key.Checked ? (int)pair.Value : 0;
            }

            RegisterHotKey(this.Handle, leftArrow, modifiers, Keys.Left.GetHashCode());
            RegisterHotKey(this.Handle, rightArrow, modifiers, Keys.Right.GetHashCode());
        }

        private void ResetMickey(object sender, EventArgs e)
        {
            mickeyInput.Value = mickeyValueDefault;
        }

        // Suppress windows sound notification on enter keypress
        private void SuppressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void UI_Closing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, leftArrow);
            UnregisterHotKey(this.Handle, rightArrow);
        }
    }
}