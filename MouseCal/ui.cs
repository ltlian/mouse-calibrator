using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
    /// </summary>
    {

        // Default value
        private int mickeyValueDefault = 5611;

        // Initial values
        private int shiftState = 0;
        private int ctrlState = 0;
        private int altState = 0;

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

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4
        }

        // By assigning the arrow key enums to be mutually negative, the value
        // can be used to multiply the input argument for Mouse_Event()
        private const int leftArrow = -1;
        private const int rightArrow = 1;

        public MouseCal()
        {
            InitializeComponent();

            mickeyInput.Value = mickeyValueDefault;

            shiftState = SetModifierState(checkBoxS.Checked, KeyModifier.Shift);
            ctrlState = SetModifierState(checkBoxC.Checked, KeyModifier.Control);
            altState = SetModifierState(checkBoxA.Checked, KeyModifier.Alt);

            UpdateModifierKeys(leftArrow, Keys.Left.GetHashCode());
            UpdateModifierKeys(rightArrow, Keys.Right.GetHashCode());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Mouse_Event(0x0001, m.WParam.ToInt32()*(int)mickeyInput.Value, 0, 0, 0);
            }
        }

        private void UI_Closing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
            UnregisterHotKey(this.Handle, 1);
        }

        private void CheckBoxUpdated(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            bool checkState = chk.Checked;

            if (sender.Equals(checkBoxS))
            {
                this.shiftState = SetModifierState(checkState, KeyModifier.Shift);
            }
            if (sender.Equals(checkBoxC))
            {
                this.ctrlState = SetModifierState(checkState, KeyModifier.Control);
            }
            if (sender.Equals(checkBoxA))
            {
                this.altState = SetModifierState(checkState, KeyModifier.Alt);
            }

            UpdateModifierKeys(leftArrow, Keys.Left.GetHashCode());
            UpdateModifierKeys(rightArrow, Keys.Right.GetHashCode());
        }

        private int SetModifierState(bool checkState, KeyModifier modifierKey)
        {
            if (checkState)
            {
                return (int)modifierKey;
            }
            else
            {
                return 0;
            }
        }

        // ResetMickey resets the calibrator value
        private void ResetMickey(object sender, EventArgs e)
        {
            mickeyInput.Value = mickeyValueDefault;
        }

        private void UpdateModifierKeys(int id, int keyHashCode)
        {
            RegisterHotKey(this.Handle, id, shiftState | this.ctrlState | this.altState, keyHashCode);
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
    }
}