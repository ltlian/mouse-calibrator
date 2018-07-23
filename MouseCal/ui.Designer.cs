namespace MouseCalibrator
{
    partial class MouseCal
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseCal));
            this.mickeyInput = new System.Windows.Forms.NumericUpDown();
            this.resetBtn = new System.Windows.Forms.Button();
            this.checkBoxS = new System.Windows.Forms.CheckBox();
            this.checkBoxC = new System.Windows.Forms.CheckBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mickeyInput)).BeginInit();
            this.SuspendLayout();
            // 
            // mickeyInput
            // 
            this.mickeyInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mickeyInput.BackColor = System.Drawing.SystemColors.Window;
            this.mickeyInput.Location = new System.Drawing.Point(181, 12);
            this.mickeyInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.mickeyInput.Name = "mickeyInput";
            this.mickeyInput.Size = new System.Drawing.Size(58, 20);
            this.mickeyInput.TabIndex = 0;
            this.mickeyInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mickeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuppressEnter);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.Location = new System.Drawing.Point(181, 38);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(58, 30);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetMickey);
            // 
            // checkBoxS
            // 
            this.checkBoxS.AutoSize = true;
            this.checkBoxS.Checked = true;
            this.checkBoxS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxS.Location = new System.Drawing.Point(12, 12);
            this.checkBoxS.Name = "checkBoxS";
            this.checkBoxS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxS.Size = new System.Drawing.Size(47, 17);
            this.checkBoxS.TabIndex = 3;
            this.checkBoxS.Text = "Shift";
            this.checkBoxS.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.checkBoxS.UseVisualStyleBackColor = true;
            this.checkBoxS.CheckStateChanged += new System.EventHandler(this.CheckBoxUpdated);
            // 
            // checkBoxC
            // 
            this.checkBoxC.AutoSize = true;
            this.checkBoxC.Location = new System.Drawing.Point(12, 35);
            this.checkBoxC.Name = "checkBoxC";
            this.checkBoxC.Size = new System.Drawing.Size(41, 17);
            this.checkBoxC.TabIndex = 4;
            this.checkBoxC.Text = "Ctrl";
            this.checkBoxC.UseVisualStyleBackColor = true;
            this.checkBoxC.CheckStateChanged += new System.EventHandler(this.CheckBoxUpdated);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Location = new System.Drawing.Point(12, 58);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(38, 17);
            this.checkBoxA.TabIndex = 5;
            this.checkBoxA.Text = "Alt";
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.CheckStateChanged += new System.EventHandler(this.CheckBoxUpdated);
            // 
            // MouseCal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(251, 87);
            this.Controls.Add(this.checkBoxA);
            this.Controls.Add(this.checkBoxC);
            this.Controls.Add(this.checkBoxS);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.mickeyInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseCal";
            this.Text = "Mouse Calibrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.mickeyInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mickeyInput;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.CheckBox checkBoxS;
        private System.Windows.Forms.CheckBox checkBoxC;
        private System.Windows.Forms.CheckBox checkBoxA;
    }
}
