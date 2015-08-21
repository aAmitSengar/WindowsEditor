using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    public partial class SetColumnWidth : Hlpr
    {
        public SetColumnWidth(object width)
        {
            InitializeComponent();
            if (width != null)
                this.textBoxColumnSize.Text = width.ToString().Replace("px", "");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxColumnSize.Text.Trim()))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.Close();
        }

        private void SetColumnWidth_Load(object sender, EventArgs e)
        {
            textBoxColumnSize.Focus();
        }
    }
}
