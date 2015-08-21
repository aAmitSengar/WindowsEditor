
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    public partial class ApplicationSettings : Hlpr
    {
        public ApplicationSettings()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
        }

        private void ApplicationSettings_Load(object sender, EventArgs e)
        {
            fillKeys();


            this.panel1.BackColor = Properties.Settings.Default.BackGroundColor;
            this.panel2.BackColor = Properties.Settings.Default.BackGroundColor;
            this.panel3.BackColor = Properties.Settings.Default.BackGroundColor;

            this.panel3.ForeColor = Properties.Settings.Default.FontColor;
            this.panel3.ForeColor = Properties.Settings.Default.FontColor;
            shortcutInput1.Keys = Properties.Settings.Default.CustomPaste;
        }

        private void fillKeys()
        {

        }

        private void button_ChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.BackGroundColor = colorDialog1.Color;
                Properties.Settings.Default.Save();

            }
        }

        private void button_ChangeFontColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.FontColor = colorDialog1.Color;
                Properties.Settings.Default.Save();

            }
        }

        private void button_ChangeFont_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.ApplicationFont = fontDialog1.Font;
                Properties.Settings.Default.Save();

            }
        }

        private void buttonCloseSettings_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void buttonResetSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            if (MessageBox.Show(this, "You need to restart Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void buttonCustomPaste_Click(object sender, EventArgs e)
        {

            if ((shortcutInput1.Alt && shortcutInput1.Shift) || (shortcutInput1.Shift && shortcutInput1.Control) || (shortcutInput1.Alt && shortcutInput1.Control))
            {
                var KeyToAction = shortcutInput1.Keys;
                var KeyCharCode = shortcutInput1.CharCode;
                Properties.Settings.Default.CustomPaste = KeyToAction;


                var kedisp1 = KeyToAction.ToString().Split(',');
                var newString = "";
                for (int i = kedisp1.Length - 1; i >= 0; i--)
                {
                    newString += "+" + kedisp1[i];
                }

                Properties.Settings.Default.CustomPasteKeysDisplay = newString;
                Properties.Settings.Default.Save();
                MessageBox.Show(this, "Updated Sussessfully!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "please Select two Checkbox Also for Short key", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
