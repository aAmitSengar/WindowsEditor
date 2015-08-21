using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    public partial class TextInsertForm : Hlpr
    {
        private bool _accepted = false;

        public TextInsertForm(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        public string HTML
        {
            get { return textBox1.Text; }
        }

        public bool Accepted
        {
            get { return _accepted; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _accepted = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextInsertForm_Load(object sender, EventArgs e)
        {

        }

        private void imageButton_Click(object sender, EventArgs e)
        {

        }

        private void linkButton_Click(object sender, EventArgs e)
        {

        }

        private void boldButton_Click(object sender, EventArgs e)
        {

        }

        private void italicButton_Click(object sender, EventArgs e)
        {

        }

        private void underlineButton_Click(object sender, EventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {

        }

        private void backColorButton_Click(object sender, EventArgs e)
        {

        }

        private void justifyLeftButton_Click(object sender, EventArgs e)
        {

        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {

        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {

        }

        private void justifyFullButton_Click(object sender, EventArgs e)
        {

        }

        private void orderedListButton_Click(object sender, EventArgs e)
        {

        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {

        }

        private void indentButton_Click(object sender, EventArgs e)
        {

        }

        private void outdentButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}