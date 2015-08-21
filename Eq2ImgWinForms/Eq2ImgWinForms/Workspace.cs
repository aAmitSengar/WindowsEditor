using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Threading;
using Astrila.Eq2ImgWinForms.Database;
using xDialog;

namespace Astrila.Eq2ImgWinForms
{
    public partial class Workspace : Form
    {
        private static SqlConnection con = new SqlConnection(DataAccess.connection);
        NewFormClass d = new NewFormClass();
        public static String SQL = null;
        int tempHeight = 0;
        int tempWidth = 0;
        public Workspace()
        {
            InitializeComponent();
            Screen Srn = Screen.PrimaryScreen;
            tempHeight = Srn.Bounds.Width;
            tempWidth = Srn.Bounds.Height;
        }
        [STAThread]
        private void Workspace_Load(object sender, EventArgs e)
        {
            this.Width = tempWidth;
            this.Height = tempHeight;
        }



        [STAThread]
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        [STAThread]
        private void newQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.DefaultInstance_EditorForm.TopLevel = false;
            //d.ControlBox = false;
            d.DefaultInstance_EditorForm.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(d.DefaultInstance_EditorForm);
            d.DefaultInstance_EditorForm.TopMost = true;
            d.DefaultInstance_EditorForm.BringToFront();
            d.DefaultInstance_EditorForm.Show();
            if (d.DefaultInstance_EditorForm.WindowState == FormWindowState.Minimized) { d.DefaultInstance_EditorForm.WindowState = FormWindowState.Maximized; }

            //Item_Master im = new Item_Master();
            //im.Size = this.Size;
            //im.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formdialogue = new ApplicationSettings();
            if (formdialogue.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                MsgBox.Show("Changed Successfully!!", "Success", MsgBox.Buttons.OK, MsgBox.Icon.Info, MsgBox.AnimateStyle.ZoomIn);
                //  MessageBox.Show(this, "Changed Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            d.DefaultInstance_QuestionsListing.TopLevel = false;
            //d.ControlBox = false;
            d.DefaultInstance_QuestionsListing.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(d.DefaultInstance_QuestionsListing);
            d.DefaultInstance_QuestionsListing.TopMost = true;
            d.DefaultInstance_QuestionsListing.BringToFront();
            d.DefaultInstance_QuestionsListing.Show();
            if (d.DefaultInstance_QuestionsListing.WindowState == FormWindowState.Minimized) { d.DefaultInstance_QuestionsListing.WindowState = FormWindowState.Maximized; }
        }


    }


}