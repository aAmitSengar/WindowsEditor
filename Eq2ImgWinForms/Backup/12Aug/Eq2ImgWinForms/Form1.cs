using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Astrila.Eq2ImgWinForms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBoxEquation;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Panel panelEquationEntry;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.Panel panelTollbar;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButtonRealTimeUpdate;
        private System.Windows.Forms.ToolBarButton toolBarButtonSave;
        private System.Windows.Forms.ToolBarButton toolBarButtonCopy;
        private System.Windows.Forms.ToolBarButton toolBarButtonExamples;
        private System.Windows.Forms.ToolBarButton toolBarButtonTeXHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private Label label2;
        private ComboBox comboBox1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Editor editor1;
        private System.ComponentModel.IContainer components;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxEquation = new System.Windows.Forms.TextBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.panelEquationEntry = new System.Windows.Forms.Panel();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButtonRealTimeUpdate = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCopy = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExamples = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonTeXHelp = new System.Windows.Forms.ToolBarButton();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.panelTollbar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.editor1 = new Astrila.Eq2ImgWinForms.Editor();
            this.panelEquationEntry.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.panelTollbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // textBoxEquation
            // 
            this.textBoxEquation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEquation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEquation.Location = new System.Drawing.Point(127, 10);
            this.textBoxEquation.Multiline = true;
            this.textBoxEquation.Name = "textBoxEquation";
            this.textBoxEquation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEquation.Size = new System.Drawing.Size(412, 88);
            this.textBoxEquation.TabIndex = 0;
            this.textBoxEquation.Text = "x^2 + y^2 = z^2";
            this.textBoxEquation.TextChanged += new System.EventHandler(this.textBoxEquation_TextChanged);
            this.textBoxEquation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxEquation_MouseDoubleClick);
            // 
            // buttonShow
            // 
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Location = new System.Drawing.Point(389, 105);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(61, 23);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.Text = "Show";
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // panelEquationEntry
            // 
            this.panelEquationEntry.Controls.Add(this.toolBar1);
            this.panelEquationEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEquationEntry.Location = new System.Drawing.Point(0, 0);
            this.panelEquationEntry.Name = "panelEquationEntry";
            this.panelEquationEntry.Size = new System.Drawing.Size(1095, 32);
            this.panelEquationEntry.TabIndex = 7;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonRealTimeUpdate,
            this.toolBarButtonSave,
            this.toolBarButtonCopy,
            this.toolBarButtonExamples,
            this.toolBarButtonTeXHelp});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1095, 28);
            this.toolBar1.TabIndex = 10;
            this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButtonRealTimeUpdate
            // 
            this.toolBarButtonRealTimeUpdate.ImageIndex = 4;
            this.toolBarButtonRealTimeUpdate.Name = "toolBarButtonRealTimeUpdate";
            this.toolBarButtonRealTimeUpdate.Pushed = true;
            this.toolBarButtonRealTimeUpdate.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.toolBarButtonRealTimeUpdate.Text = "Update as you type";
            // 
            // toolBarButtonSave
            // 
            this.toolBarButtonSave.ImageIndex = 0;
            this.toolBarButtonSave.Name = "toolBarButtonSave";
            this.toolBarButtonSave.Text = "Save Image";
            // 
            // toolBarButtonCopy
            // 
            this.toolBarButtonCopy.ImageIndex = 1;
            this.toolBarButtonCopy.Name = "toolBarButtonCopy";
            this.toolBarButtonCopy.Text = "Copy Image";
            // 
            // toolBarButtonExamples
            // 
            this.toolBarButtonExamples.ImageIndex = 3;
            this.toolBarButtonExamples.Name = "toolBarButtonExamples";
            this.toolBarButtonExamples.Text = "Examples";
            // 
            // toolBarButtonTeXHelp
            // 
            this.toolBarButtonTeXHelp.ImageIndex = 2;
            this.toolBarButtonTeXHelp.Name = "toolBarButtonTeXHelp";
            this.toolBarButtonTeXHelp.Text = "Help on TeX";
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.panelTollbar);
            this.panelPicture.Location = new System.Drawing.Point(0, 38);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(783, 160);
            this.panelPicture.TabIndex = 5;
            // 
            // panelTollbar
            // 
            this.panelTollbar.Controls.Add(this.label2);
            this.panelTollbar.Controls.Add(this.comboBox1);
            this.panelTollbar.Controls.Add(this.button1);
            this.panelTollbar.Controls.Add(this.label1);
            this.panelTollbar.Controls.Add(this.textBoxEquation);
            this.panelTollbar.Controls.Add(this.buttonShow);
            this.panelTollbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTollbar.Location = new System.Drawing.Point(0, 0);
            this.panelTollbar.Name = "panelTollbar";
            this.panelTollbar.Size = new System.Drawing.Size(555, 160);
            this.panelTollbar.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "No of Options :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(127, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(279, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Performance Test";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type equation here:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "GIF (*.gif)|*.gif";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.editor1);
            this.panel1.Location = new System.Drawing.Point(3, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 80);
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(13, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Pow";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(747, 283);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Show";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(680, 283);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Show";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(613, 283);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Show";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(546, 283);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(61, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Show";
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(479, 283);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Show";
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(415, 283);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(61, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "Show";
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(348, 283);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(61, 23);
            this.button9.TabIndex = 17;
            this.button9.Text = "Show";
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(281, 283);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(61, 23);
            this.button10.TabIndex = 18;
            this.button10.Text = "Show";
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(214, 283);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(61, 23);
            this.button11.TabIndex = 19;
            this.button11.Text = "Show";
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(147, 283);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(61, 23);
            this.button12.TabIndex = 20;
            this.button12.Text = "Sqrt";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Location = new System.Drawing.Point(80, 283);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(61, 23);
            this.button13.TabIndex = 21;
            this.button13.Text = "Fraction";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1051, 115);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // editor1
            // 
            this.editor1.BodyBackgroundColor = System.Drawing.Color.White;
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontSize = Astrila.Eq2ImgWinForms.FontSize.Three;
            this.editor1.Html = null;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(1051, 80);
            this.editor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonShow;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.BackGroundColor;
            this.ClientSize = new System.Drawing.Size(1095, 572);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panelEquationEntry);
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "ApplicationFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Astrila.Eq2ImgWinForms.Properties.Settings.Default, "BackGroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.ApplicationFont;
            this.ForeColor = global::Astrila.Eq2ImgWinForms.Properties.Settings.Default.FontColor;
            this.Name = "Form1";
            this.Text = "Equation Writer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelEquationEntry.ResumeLayout(false);
            this.panelEquationEntry.PerformLayout();
            this.panelPicture.ResumeLayout(false);
            this.panelTollbar.ResumeLayout(false);
            this.panelTollbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

       


        private string GetGifFilePath()
        {
            return Path.Combine(Path.GetTempPath(), "Eq2ImgWinForms.gif");
        }

        private void WriteEquation(string equation)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            if (equation.Length > 0)
            {
                string tempGifFilePath = GetGifFilePath();
                try
                {
                    NativeMethods.CreateGifFromEq(equation, tempGifFilePath);
                    pictureBox1.Image = Image.FromFile(tempGifFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "emptyeq.gif"));
            };
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            WriteEquation(textBoxEquation.Text);
            comboBox1.SelectedValue = 0;
          
       
        }

        private void buttonShow_Click(object sender, System.EventArgs e)
        {
            WriteEquation(textBoxEquation.Text);
        }

        private void textBoxEquation_TextChanged(object sender, System.EventArgs e)
        {
            if (toolBarButtonRealTimeUpdate.Pushed == true)
                WriteEquation(textBoxEquation.Text);
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonCopy)
            {
                Clipboard.SetDataObject(pictureBox1.Image);
            }
            else if (e.Button == toolBarButtonSave)
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            else if (e.Button == toolBarButtonExamples)
            {
                System.Diagnostics.Process.Start("http://www.forkosh.dreamhost.com/source_mimetex.html?referer=&remhost=#examples");
            }
            else if (e.Button == toolBarButtonTeXHelp)
            {
                System.Diagnostics.Process.Start("http://www.forkosh.com/mimetextutorial.html");
            }
            else if (e.Button == toolBarButtonRealTimeUpdate)
            { }
            else
                MessageBox.Show("This is not implemented yet");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < 2000; i++)
            {
                WriteEquation(textBoxEquation.Text);
            }
            MessageBox.Show("Time to render: " + (DateTime.Now.Subtract(startTime).Seconds / 2000.0).ToString() + " seconds");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.panel1.Controls.Count; j++)
            {
                panel1.Controls.RemoveAt(j);
                panel1.Refresh();

            }


            Point p = new Point(5, 5);
            for (int i = 0; i < Convert.ToInt16(comboBox1.SelectedItem); i++)
            {
                Label lb = new Label();
                lb.Text = "Option" + i;
                lb.Name = "lb" + i;
                lb.Location = new Point(p.Y, p.X);
                lb.BringToFront();
                //p.X = lb.Location.X + lb.Width;
                p.Y = lb.Location.Y;

                TextBox tx = new TextBox();
                tx.Name = "tx" + i;
                tx.Text = "Option" + i;
                tx.Location = new Point(p.Y, p.X + 30);
                tx.BringToFront();
                p.X = tx.Location.X + tx.Width;
                // p.Y = tx.Location.X;

                this.panel1.Controls.Add(lb);

                this.panel1.Controls.Add(tx);
                this.panel1.Refresh();
            }

        }

        private void textBoxEquation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var data = Clipboard.GetDataObject();
            textBoxEquation.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + "^";
            //webBrowser1.DocumentText = webBrowser1.DocumentText + "^";
            textBoxEquation.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + " \\frac{}{}";
            textBoxEquation.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + " \\sqrt{}";
            textBoxEquation.Focus();
        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
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

        private void linkButton_Click(object sender, EventArgs e)
        {

        }

        private void imageButton_Click(object sender, EventArgs e)
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
        //protected void CopyFromClipbordInlineShape()
        //{
        //    InlineShape inlineShape = m_word.ActiveDocument.InlineShapes[m_i];
        //    inlineShape.Select();
        //    m_word.Selection.Copy();
        //    Computer computer = new Computer();
        //    //Image img = computer.Clipboard.GetImage();
        //    if (computer.Clipboard.GetDataObject() != null)
        //    {
        //        System.Windows.Forms.IDataObject data = computer.Clipboard.GetDataObject();
        //        if (data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
        //        {
        //            Image image = (Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
        //            image.Save(Server.MapPath("~/ImagesGet/image.gif"), System.Drawing.Imaging.ImageFormat.Gif);
        //            image.Save(Server.MapPath("~/ImagesGet/image.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

        //        }
        //        else
        //        {
        //            LabelMessage.Text = "The Data In Clipboard is not as image format";
        //        }
        //    }
        //    else
        //    {
        //        LabelMessage.Text = "The Clipboard was empty";
        //    }
        //}


    }

    [System.Security.SuppressUnmanagedCodeSecurity()]
    internal class NativeMethods
    {
        private NativeMethods()
        { //all methods in this class would be static
        }

        [System.Runtime.InteropServices.DllImport("MimeTex.dll")]
        internal static extern int CreateGifFromEq(string expr, string fileName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        internal extern static IntPtr GetModuleHandle(string lpModuleName);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        internal extern static bool FreeLibrary(IntPtr hLibModule);
    }
}
