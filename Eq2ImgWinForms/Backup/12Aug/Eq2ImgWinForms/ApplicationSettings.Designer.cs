namespace Astrila.Eq2ImgWinForms
{
    partial class ApplicationSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettings));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button_ChangeBackgroundColor = new System.Windows.Forms.Button();
            this.button_ChangeFontColor = new System.Windows.Forms.Button();
            this.button_ChangeFont = new System.Windows.Forms.Button();
            this.buttonResetSettings = new System.Windows.Forms.Button();
            this.buttonCloseSettings = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCustomPaste = new System.Windows.Forms.Button();
            this.shortcutInput1 = new Astrila.Eq2ImgWinForms.ShortcutInput();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BackGround Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Font Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Font";
            // 
            // button_ChangeBackgroundColor
            // 
            this.button_ChangeBackgroundColor.AutoEllipsis = true;
            this.button_ChangeBackgroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ChangeBackgroundColor.Location = new System.Drawing.Point(327, 42);
            this.button_ChangeBackgroundColor.Name = "button_ChangeBackgroundColor";
            this.button_ChangeBackgroundColor.Size = new System.Drawing.Size(75, 25);
            this.button_ChangeBackgroundColor.TabIndex = 6;
            this.button_ChangeBackgroundColor.Text = "Change";
            this.button_ChangeBackgroundColor.UseVisualStyleBackColor = true;
            this.button_ChangeBackgroundColor.Click += new System.EventHandler(this.button_ChangeBackgroundColor_Click);
            // 
            // button_ChangeFontColor
            // 
            this.button_ChangeFontColor.AutoEllipsis = true;
            this.button_ChangeFontColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ChangeFontColor.Location = new System.Drawing.Point(327, 134);
            this.button_ChangeFontColor.Name = "button_ChangeFontColor";
            this.button_ChangeFontColor.Size = new System.Drawing.Size(75, 28);
            this.button_ChangeFontColor.TabIndex = 7;
            this.button_ChangeFontColor.Text = "Change";
            this.button_ChangeFontColor.UseVisualStyleBackColor = true;
            this.button_ChangeFontColor.Click += new System.EventHandler(this.button_ChangeFontColor_Click);
            // 
            // button_ChangeFont
            // 
            this.button_ChangeFont.AutoEllipsis = true;
            this.button_ChangeFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ChangeFont.Location = new System.Drawing.Point(327, 236);
            this.button_ChangeFont.Name = "button_ChangeFont";
            this.button_ChangeFont.Size = new System.Drawing.Size(75, 26);
            this.button_ChangeFont.TabIndex = 8;
            this.button_ChangeFont.Text = "Change";
            this.button_ChangeFont.UseVisualStyleBackColor = true;
            this.button_ChangeFont.Click += new System.EventHandler(this.button_ChangeFont_Click);
            // 
            // buttonResetSettings
            // 
            this.buttonResetSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonResetSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonResetSettings.Location = new System.Drawing.Point(12, 356);
            this.buttonResetSettings.Name = "buttonResetSettings";
            this.buttonResetSettings.Size = new System.Drawing.Size(143, 36);
            this.buttonResetSettings.TabIndex = 9;
            this.buttonResetSettings.Text = "Reset";
            this.buttonResetSettings.UseVisualStyleBackColor = true;
            this.buttonResetSettings.Click += new System.EventHandler(this.buttonResetSettings_Click);
            // 
            // buttonCloseSettings
            // 
            this.buttonCloseSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonCloseSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCloseSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCloseSettings.Location = new System.Drawing.Point(885, 356);
            this.buttonCloseSettings.Name = "buttonCloseSettings";
            this.buttonCloseSettings.Size = new System.Drawing.Size(101, 36);
            this.buttonCloseSettings.TabIndex = 10;
            this.buttonCloseSettings.Text = "Close";
            this.buttonCloseSettings.UseVisualStyleBackColor = true;
            this.buttonCloseSettings.Click += new System.EventHandler(this.buttonCloseSettings_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Enable Auto Save Size";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Location = new System.Drawing.Point(473, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 37);
            this.panel4.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.EnableAutoSizePanels;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "EnableAutoSizePanels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point(158, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(13, 12);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.BackGroundColor;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "BackGroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel3.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel3.ForeColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.FontColor;
            this.panel3.Location = new System.Drawing.Point(158, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 83);
            this.panel3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.BackGroundColor;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "BackGroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.ApplicationFont;
            this.label5.ForeColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.FontColor;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 81);
            this.label5.TabIndex = 5;
            this.label5.Text = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.BackGroundColor;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "BackGroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel2.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel2.ForeColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.FontColor;
            this.panel2.Location = new System.Drawing.Point(158, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 82);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.ApplicationFont;
            this.label4.ForeColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.FontColor;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 80);
            this.label4.TabIndex = 4;
            this.label4.Text = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.BackGroundColor;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "BackGroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel1.Location = new System.Drawing.Point(158, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 38);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Custom Paste";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.shortcutInput1);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(473, 93);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 128);
            this.panel5.TabIndex = 17;
            // 
            // buttonCustomPaste
            // 
            this.buttonCustomPaste.AutoEllipsis = true;
            this.buttonCustomPaste.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCustomPaste.Location = new System.Drawing.Point(713, 193);
            this.buttonCustomPaste.Name = "buttonCustomPaste";
            this.buttonCustomPaste.Size = new System.Drawing.Size(75, 28);
            this.buttonCustomPaste.TabIndex = 18;
            this.buttonCustomPaste.Text = "Change";
            this.buttonCustomPaste.UseVisualStyleBackColor = true;
            this.buttonCustomPaste.Click += new System.EventHandler(this.buttonCustomPaste_Click);
            // 
            // shortcutInput1
            // 
            this.shortcutInput1.Alt = false;
            this.shortcutInput1.CharCode = ((byte)(65));
            this.shortcutInput1.Control = false;
            this.shortcutInput1.Keys = System.Windows.Forms.Keys.A;
            this.shortcutInput1.Location = new System.Drawing.Point(50, 32);
            this.shortcutInput1.Name = "shortcutInput1";
            this.shortcutInput1.Shift = false;
            this.shortcutInput1.Size = new System.Drawing.Size(181, 93);
            this.shortcutInput1.TabIndex = 17;
            // 
            // ApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 404);
            this.Controls.Add(this.buttonCustomPaste);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonCloseSettings);
            this.Controls.Add(this.buttonResetSettings);
            this.Controls.Add(this.button_ChangeFont);
            this.Controls.Add(this.button_ChangeFontColor);
            this.Controls.Add(this.button_ChangeBackgroundColor);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ApplicationSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ApplicationSettings";
            this.Load += new System.EventHandler(this.ApplicationSettings_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_ChangeBackgroundColor;
        private System.Windows.Forms.Button button_ChangeFontColor;
        private System.Windows.Forms.Button button_ChangeFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonResetSettings;
        private System.Windows.Forms.Button buttonCloseSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCustomPaste;
        private ShortcutInput shortcutInput1;
    }
}