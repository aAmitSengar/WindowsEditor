using System.Drawing;
using System.Text;
using System.IO;
using mshtml;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;
using Astrila.Eq2ImgWinForms.Helper;
using xDialog;
using System.Runtime.InteropServices;
using System.Threading;


namespace Astrila.Eq2ImgWinForms
{


    public partial class EditorForm : Hlpr
    {
        private string _filename = null;
        SqlTransaction transaction = null;
        //convert_to_unicode


        int QuestionParagraphId = 0;
        public EditorForm()
        {


            SelectablePanel ss = new SelectablePanel();

            InitializeComponent();
            editor.Tick += new Editor.TickDelegate(editor_Tick);
            timer1.Interval = 1000;
            timer1.Start();

            if (Properties.Settings.Default.EnableAutoLocationSave)
            {
                #region popup Paragraph
                ControlMover.Init(button_paragraphSave);
                ControlMover.Init(button_paragraphCancel);
                ControlMover.Init(button_paragraphClear);
                ControlMover.Init(button4);
                #endregion
                #region main Page
                ControlMover.Init(label1);
                //English Option
                ControlMover.Init(label2);
                ControlMover.Init(label3);
                ControlMover.Init(label4);
                ControlMover.Init(label5);
                ControlMover.Init(label5);
                //English Option 
                //Hindi Option
                ControlMover.Init(label13);
                ControlMover.Init(label14);
                ControlMover.Init(label15);
                ControlMover.Init(label16);
                //Hindi Option

                ControlMover.Init(label11);
                ControlMover.Init(label12);
                ControlMover.Init(comboBox_MainSubject);
                ControlMover.Init(comboBox_SubSubject);
                ControlMover.Init(buttonCopyOptions);
                ControlMover.Init(BtnSave);
                ControlMover.Init(button_closeParagraphQuestion);
                ControlMover.Init(buttonSaveParagraphQuestionsAndNexe);
                ControlMover.Init(buttonCancel);
                ControlMover.Init(label10);
                ControlMover.Init(checkBox1);
                #endregion
                #region SplitOptions
                splitContainer1.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;
                splitContainer8.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;
                splitContainer9.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;
                #endregion
            }
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();

        }
        private void EditorForm_Load(object sender, EventArgs e)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "shree.htm";
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "shree.htm");

            RegisterHotKey(Handle, 42, 0, (int)Keys.F1);
            RegisterHotKey(Handle, 42, 0, (int)Keys.F3);

            //= "SHREE-DEV7-0708E";
            FillAutoCompleteMainSubject();

            #region Load Defaults

            UpdateLanguage();
            #endregion

            //for (var j = U+2200; j < U+22FF; j++)
            //{
            //    editor.BodyHtml+=j.ToString();
            //}

        }

        private void UpdateLanguage()
        {
            try
            {


            }
            catch (Exception ex)
            {

                MsgBox.Show(ex.Message, "Errort", MsgBox.Buttons.OK, MsgBox.Icon.Error, MsgBox.AnimateStyle.ZoomIn);

            }
        }


        private void FillAutoCompleteMainSubject()
        {
            SqlDataAdapter dap = new SqlDataAdapter("select distinct SubjectID,SubjectName from SubjectMaster where SubjectIsActive=1", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed) { con.Open(); }

            dap.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                comboBox_MainSubject.DataSource = dt;
                comboBox_MainSubject.ValueMember = "SubjectID";

                //comboBox_MainSubject.Items.Insert(0, "--Select Subject--");
                //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                //{
                //    comboBox_MainSubject.Items.Add(dt.Rows[i][1].ToString());

                //}
                comboBox_MainSubject.DisplayMember = "SubjectName";
            }
        }
        private void editor_Tick()
        {
            undoToolStripMenuItem.Enabled = editor.CanUndo();
            redoToolStripMenuItem.Enabled = editor.CanRedo();
            cutToolStripMenuItem.Enabled = editor.CanCut();
            copyToolStripMenuItem.Enabled = editor.CanCopy();
            pasteToolStripMenuItem.Enabled = editor.CanPaste();
            imageToolStripMenuItem.Enabled = editor.CanInsertLink();


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _filename = null;
            Text = null;
            editor.BodyHtml = string.Empty;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filename == null)
            {
                if (!SaveFileDialog())
                    return;
            }
            SaveFile(_filename);
        }

        private bool SaveFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = "htm";
                dlg.Filter = "HTML files (*.html;*.htm)|*.html;*.htm";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                    return true;
                }
                else
                    return false;
            }
        }

        private void SaveFile(string filename)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.Write(editor.DocumentText);
                writer.Flush();
                writer.Close();
            }
        }

        private void LoadFile(string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                editor.Html = reader.ReadToEnd();
                Text = editor.DocumentTitle;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "HTML files (*.html;*.htm)|*.html;*.htm";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                }
                else
                    return;
            }
            LoadFile(_filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog())
                SaveFile(_filename);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SearchDialog dlg = new SearchDialog(editor))
            {
                dlg.ShowDialog(this);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyText);
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyHtml);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Print();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertBreak();
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var textData = "";
            switch (myenum)
            {
                case MyEnum.EnglishQuestion:
                    textData = editor.BodyHtml;
                    break;
                case MyEnum.EnglishOption1:
                    textData = editorEN1.BodyHtml;
                    break;
                case MyEnum.EnglishOption2:
                    textData = editorEN2.BodyHtml;
                    break;
                case MyEnum.EnglishOption3:
                    textData = editorEN3.BodyHtml;
                    break;
                case MyEnum.EnglishOption4:
                    textData = editorEN4.BodyHtml;
                    break;
                case MyEnum.HindiQuestion:
                    textData = editor1.BodyHtml;
                    break;
                case MyEnum.HindiOption1:
                    textData = editorHI1.BodyHtml;
                    break;
                case MyEnum.HindiOption2:
                    textData = editorHI2.BodyHtml;
                    break;
                case MyEnum.HindiOption3:
                    textData = editorHI3.BodyHtml;
                    break;
                case MyEnum.HindiOption4:
                    textData = editorHI4.BodyHtml;
                    break;
                default:
                    textData = editor.BodyHtml;
                    break;
            }
            using (TextInsertForm form = new TextInsertForm(textData))
            {
                form.ShowDialog(this);
                if (form.Accepted)
                {
                    switch (myenum)
                    {
                        case MyEnum.EnglishQuestion:
                            editor.BodyHtml = form.HTML;
                            break;
                        case MyEnum.EnglishOption1:
                            editorEN1.BodyHtml = form.HTML;
                            break;
                        case MyEnum.EnglishOption2:
                            editorEN2.BodyHtml = form.HTML;
                            break;
                        case MyEnum.EnglishOption3:
                            editorEN3.BodyHtml = form.HTML;
                            break;
                        case MyEnum.EnglishOption4:
                            editorEN4.BodyHtml = form.HTML;
                            break;
                        case MyEnum.HindiQuestion:
                            editor1.BodyHtml = form.HTML;
                            break;
                        case MyEnum.HindiOption1:
                            editorHI1.BodyHtml = form.HTML;
                            break;
                        case MyEnum.HindiOption2:
                            editorHI2.BodyHtml = form.HTML;
                            break;
                        case MyEnum.HindiOption3:
                            editorHI3.BodyHtml = form.HTML;
                            break;
                        case MyEnum.HindiOption4:
                            editorHI4.BodyHtml = form.HTML;
                            break;
                        default:
                            editor.BodyHtml = form.HTML;
                            break;
                    }

                }
            }
        }

        private void paragraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (myenum)
            {
                case MyEnum.EnglishQuestion:
                    editor.InsertParagraph();
                    break;
                case MyEnum.EnglishOption1:
                    editorEN1.InsertParagraph();
                    break;
                case MyEnum.EnglishOption2:
                    editorEN2.InsertParagraph();
                    break;
                case MyEnum.EnglishOption3:
                    editorEN3.InsertParagraph();
                    break;
                case MyEnum.EnglishOption4:
                    editorEN4.InsertParagraph();
                    break;
                case MyEnum.HindiQuestion:
                    editor1.InsertParagraph();
                    break;
                case MyEnum.HindiOption1:
                    editorHI1.InsertParagraph();
                    break;
                case MyEnum.HindiOption2:
                    editorHI2.InsertParagraph();
                    break;
                case MyEnum.HindiOption3:
                    editorHI3.InsertParagraph();
                    break;
                case MyEnum.HindiOption4:
                    editorHI4.InsertParagraph();
                    break;
                default:
                    editor.InsertParagraph();
                    break;
            }

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (myenum)
            {
                case MyEnum.EnglishQuestion:
                    editor.InsertImage();
                    break;
                case MyEnum.EnglishOption1:
                    editorEN1.InsertImage();
                    break;
                case MyEnum.EnglishOption2:
                    editorEN2.InsertImage();
                    break;
                case MyEnum.EnglishOption3:
                    editorEN3.InsertImage();
                    break;
                case MyEnum.EnglishOption4:
                    editorEN4.InsertImage();
                    break;
                case MyEnum.HindiQuestion:
                    editor1.InsertImage();
                    break;
                case MyEnum.HindiOption1:
                    editorHI1.InsertImage();
                    break;
                case MyEnum.HindiOption2:
                    editorHI2.InsertImage();
                    break;
                case MyEnum.HindiOption3:
                    editorHI3.InsertImage();
                    break;
                case MyEnum.HindiOption4:
                    editorHI4.InsertImage();
                    break;
                default:
                    editor.InsertImage();
                    break;
            }

        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var EmailHost = Properties.Settings.Default.EmailHost;
            var EmailuserName = Properties.Settings.Default.EmailuserName;
            var EmailPassword = Properties.Settings.Default.EmailPassword;
            var IsSecureConnection = Properties.Settings.Default.SecureConnection;
            switch (myenum)
            {
                case MyEnum.EnglishQuestion:
                    var form = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editor.ToMailMessage());
                    form.ShowDialog();
                    break;
                case MyEnum.EnglishOption1:
                    var form1 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorEN1.ToMailMessage());
                    form1.ShowDialog();
                    break;
                case MyEnum.EnglishOption2:
                    var form2 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorEN2.ToMailMessage());
                    form2.ShowDialog();
                    break;
                case MyEnum.EnglishOption3:
                    var form3 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorEN3.ToMailMessage());
                    form3.ShowDialog();
                    break;
                case MyEnum.EnglishOption4:
                    var form4 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorEN4.ToMailMessage());
                    form4.ShowDialog();
                    break;
                case MyEnum.HindiQuestion:
                    var form5 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editor1.ToMailMessage());
                    form5.ShowDialog();
                    break;
                case MyEnum.HindiOption1:
                    var form6 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorHI1.ToMailMessage());
                    form6.ShowDialog();
                    break;
                case MyEnum.HindiOption2:
                    var form7 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorHI2.ToMailMessage());
                    form7.ShowDialog();
                    break;
                case MyEnum.HindiOption3:
                    var form8 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorHI3.ToMailMessage());
                    form8.ShowDialog();
                    break;
                case MyEnum.HindiOption4:
                    var form9 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editorHI4.ToMailMessage());
                    form9.ShowDialog();
                    break;
                default:
                    var form0 = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editor.ToMailMessage());
                    form0.ShowDialog();
                    break;
            }

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {

            }
            else
            {
                try
                {
                    if (checkBox1.CheckState == CheckState.Unchecked && string.IsNullOrEmpty(editor.BodyHtml) && string.IsNullOrEmpty(editorEN1.BodyHtml) && string.IsNullOrEmpty(editorEN2.BodyHtml) && string.IsNullOrEmpty(editorEN3.BodyHtml) && string.IsNullOrEmpty(editorEN4.BodyHtml) && string.IsNullOrEmpty(editor1.BodyHtml) && string.IsNullOrEmpty(editorHI1.BodyHtml) && string.IsNullOrEmpty(editorHI1.BodyHtml) && string.IsNullOrEmpty(editorHI2.BodyHtml) && string.IsNullOrEmpty(editorHI3.BodyHtml) && string.IsNullOrEmpty(editorHI4.BodyHtml))
                    {
                        MsgBox.Show("Please Enter a question to save", "Nothig to save", MsgBox.Buttons.OK, MsgBox.Icon.Info, MsgBox.AnimateStyle.FadeIn);
                        return;
                    }
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    transaction = con.BeginTransaction();
                    var ID = SaveQuestion();
                    if (ID > 0)
                    {
                        transaction.Commit();
                        MsgBox.Show("Saved Successfully!!", "Success", MsgBox.Buttons.OK, MsgBox.Icon.Info, MsgBox.AnimateStyle.ZoomIn);
                        ClearTextData();
                    }
                    else
                    {
                        MsgBox.Show("Error While saving", "Error", MsgBox.Buttons.OK, MsgBox.Icon.Error, MsgBox.AnimateStyle.ZoomIn);
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();

                }
                finally { con.Close(); }

            }
        }

        private int SaveQuestion(int ParagraphId = 0)
        {
            //   window.external.notify('camera~clearTempArr');
            var LastQuestionID = 0;
            var MainSubjectID = Convert.ToInt16(comboBox_MainSubject.SelectedValue);
            var SubjectTopicID = Convert.ToInt16(comboBox_SubSubject.SelectedValue);
            var text = editor.BodyText;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                // transaction = con.BeginTransaction();
                var SQL = "";
                if (ParagraphId == 0)
                {
                    SQL = "insert into QuestionMaster(QueSubjectID,QueSubSubjectID,QueTitleEng,QueTitleHindi,QueIsActive,QueIsApproved,QueCreateBy) values(" + MainSubjectID + "," + SubjectTopicID + ",@ques,@quesHI11111,1,0,1) select @@IDENTITY";
                }
                else
                {
                    SQL = "insert into QuestionMaster(QueSubjectID,QueSubSubjectID,QueTitleEng,QueTitleHindi,QueIsActive,QueIsApproved,QueCreateBy,QuestionParagraphID) values(" + MainSubjectID + "," + SubjectTopicID + ",@ques,@quesHI11111,1,0,1," + ParagraphId + ") select @@IDENTITY";

                }
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@ques", this.editor.BodyHtml ?? "");
                var finalstring = System.Web.HttpUtility.HtmlDecode((this.editor1.BodyHtml ?? ""));
                var UniE1 = KrutitoUnicode(finalstring);
                cmd.Parameters.AddWithValue("@quesHI11111", UniE1 ?? "");

                LastQuestionID = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                finalstring = "";
                #region English,Hindi
                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN1,@quesHI1,1)";
                cmd.Parameters.AddWithValue("@quesEN1", this.editorEN1.BodyHtml ?? "");
                finalstring = System.Web.HttpUtility.HtmlDecode((this.editorHI1.BodyHtml ?? ""));
                cmd.Parameters.AddWithValue("@quesHI1", KrutitoUnicode(finalstring) ?? "");

                cmd.ExecuteNonQuery();

                finalstring = "";
                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN2,@quesHI2,2)";
                cmd.Parameters.AddWithValue("@quesEN2", this.editorEN2.BodyHtml ?? "");
                finalstring = System.Web.HttpUtility.HtmlDecode((this.editorHI2.BodyHtml ?? ""));
                cmd.Parameters.AddWithValue("@quesHI2", KrutitoUnicode(finalstring) ?? "");
                cmd.ExecuteNonQuery();

                finalstring = "";
                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN3,@quesHI3,3)";
                cmd.Parameters.AddWithValue("@quesEN3", this.editorEN3.BodyHtml ?? "");
                finalstring = System.Web.HttpUtility.HtmlDecode((this.editorHI3.BodyHtml ?? ""));
                cmd.Parameters.AddWithValue("@quesHI3", KrutitoUnicode(finalstring) ?? "");
                cmd.ExecuteNonQuery();

                finalstring = "";
                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN4,@quesHI4,4)";
                cmd.Parameters.AddWithValue("@quesEN4", this.editorEN4.BodyHtml ?? "");
                finalstring = System.Web.HttpUtility.HtmlDecode((this.editorHI4.BodyHtml ?? ""));
                cmd.Parameters.AddWithValue("@quesHI4", KrutitoUnicode(finalstring) ?? "");
                cmd.ExecuteNonQuery();
                #endregion

                // transaction.Commit();

                //MessageBox.Show(this, "Saved Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                if (MsgBox.Show("Failure!! Please click On Retry otherwise cancel ant try to save again", "Failure", MsgBox.Buttons.RetryCancel, MsgBox.Icon.Info, MsgBox.AnimateStyle.ZoomIn) == System.Windows.Forms.DialogResult.Retry)
                {
                    transaction.Commit();
                    ClearTextData();
                }
                else
                {
                    transaction.Rollback();
                    MsgBox.Show("Failure!! Please Check your Network", "Error", MsgBox.Buttons.OK, MsgBox.Icon.Error, MsgBox.AnimateStyle.ZoomIn);
                }
            }
            finally
            {
                // con.Close();
            }
            return LastQuestionID;
        }


        private void ClearTextData()
        {
            timer1.Start();
            //English Question and QuestionDetail
            editor.Clear();
            editorEN1.Clear();
            editorEN2.Clear();
            editorEN3.Clear();
            editorEN4.Clear();

            //Hindi Question and QuestionDetail
            editor1.Clear();
            editorHI1.Clear();
            editorHI2.Clear();
            editorHI3.Clear();
            editorHI4.Clear();
            UpdateLanguage();
        }



        public string GetImage(string path)
        {

            using (Image image = Image.FromFile(path, true))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return "data:image/jpg;base64," + base64String;
                }
            }
        }


        private void formulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogform = new GetFormulaPopup();
            if (dialogform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //HtmlElement userimage = editor.webBrowser1.Document.CreateElement("img");
                //userimage.SetAttribute("src", Path.Combine(Path.GetTempPath(), "Eq2ImgWinForms.gif"));
                //userimage.Id = Guid.NewGuid().ToString();
                Point p = new Point();
                GetCaretPos(ref p);
                // StreamReader sm = new StreamReader(Path.Combine(dialogform.tempGifFilePath, ""));

                string aImg = "<IMG border=0 hspace=0 alt='' src='" + GetImage(dialogform.tempGifFilePath) + "'align=baseline>";

                switch (myenum)
                {
                    case MyEnum.EnglishQuestion:
                        var CurrentSelectedsLocation = (mshtml.IHTMLTxtRange)editor.doc.selection.createRange();
                        CurrentSelectedsLocation.pasteHTML(aImg);
                        //  HtmlElement currentElement = editor.webBrowser1.Document.GetElementFromPoint(p);
                        // currentElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, (HtmlElement)aImg);
                        //editor.webBrowser1.Document.Body.AppendChild(userimage);
                        //editor.BodyHtml = editor.BodyHtml + aImg;
                        break;
                    case MyEnum.EnglishOption1:
                        var CurrentSelectedsLocationEN1 = (mshtml.IHTMLTxtRange)editorEN1.doc.selection.createRange();
                        CurrentSelectedsLocationEN1.pasteHTML(aImg);
                        // editorEN1.BodyHtml = editorEN1.BodyHtml + aImg;
                        //  editorEN1.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption2:
                        var CurrentSelectedsLocationEN2 = (mshtml.IHTMLTxtRange)editorEN2.doc.selection.createRange();
                        CurrentSelectedsLocationEN2.pasteHTML(aImg);
                        // editorEN2.BodyHtml = editorEN2.BodyHtml + aImg;
                        // editorEN2.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption3:
                        var CurrentSelectedsLocationEN3 = (mshtml.IHTMLTxtRange)editorEN3.doc.selection.createRange();
                        CurrentSelectedsLocationEN3.pasteHTML(aImg);
                        //editorEN3.BodyHtml = editorEN3.BodyHtml + aImg;
                        //editorEN3.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption4:
                        var CurrentSelectedsLocationEN4 = (mshtml.IHTMLTxtRange)editorEN4.doc.selection.createRange();
                        CurrentSelectedsLocationEN4.pasteHTML(aImg);
                        // editorEN4.BodyHtml = editorEN4.BodyHtml + aImg;
                        // editorEN4.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiQuestion:
                        // HtmlElement currentElement1 = editor1.webBrowser1.Document.GetElementFromPoint(p);
                        //currentElement1.Id
                        // .InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, userimage);
                        // editor1.webBrowser1.Document.Body.AppendChild(userimage);
                        var CurrentSelectedsLocationHI = (mshtml.IHTMLTxtRange)editor.doc.selection.createRange();
                        CurrentSelectedsLocationHI.pasteHTML(aImg);

                        //editor1.BodyHtml = editor1.BodyHtml + aImg;
                        break;
                    case MyEnum.HindiOption1:

                        var CurrentSelectedsLocationHI1 = (mshtml.IHTMLTxtRange)editorHI1.doc.selection.createRange();
                        CurrentSelectedsLocationHI1.pasteHTML(aImg);
                        //editorHI1.BodyHtml = editorHI1.BodyHtml + aImg;

                        // editorHI1.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption2:
                        var CurrentSelectedsLocationHI2 = (mshtml.IHTMLTxtRange)editorHI2.doc.selection.createRange();
                        CurrentSelectedsLocationHI2.pasteHTML(aImg);
                        //editorHI2.BodyHtml = editorHI2.BodyHtml + aImg;
                        //editorHI2.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption3:
                        var CurrentSelectedsLocationHI3 = (mshtml.IHTMLTxtRange)editorHI3.doc.selection.createRange();
                        CurrentSelectedsLocationHI3.pasteHTML(aImg);
                        //editorHI3.BodyHtml = editorHI3.BodyHtml + aImg;
                        // editorHI3.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption4:
                        var CurrentSelectedsLocationHI4 = (mshtml.IHTMLTxtRange)editorHI4.doc.selection.createRange();
                        CurrentSelectedsLocationHI4.pasteHTML(aImg);
                        //editorHI4.BodyHtml = editorHI4.BodyHtml + aImg;
                        //editorHI4.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    default:
                        MsgBox.Show("Please Select a Question or Answer first", "No selected Box Fount", MsgBox.Buttons.OK, MsgBox.Icon.Info, MsgBox.AnimateStyle.ZoomIn);
                        break;
                }



            }
        }
        #region DetectCurrent Editor
        private void editor_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.EnglishQuestion;
        }

        private void editor1_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.HindiQuestion;
        }




        private void editorEN1_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.EnglishOption1;
        }

        private void editorEN2_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.EnglishOption2;
        }

        private void editorEN3_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.EnglishOption3;
        }

        private void editorEN4_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.EnglishOption4;
        }

        private void editorHI1_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.HindiOption1;
        }

        private void editorHI3_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.HindiOption3;
        }

        private void editorHI2_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.HindiOption2;
        }

        private void editorHI4_MouseClick(object sender, MouseEventArgs e)
        {
            myenum = MyEnum.HindiOption4;
        }

        private void editor_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.EnglishQuestion;
        }

        private void editor_Click(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiQuestion;
        }

        private void editor1_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiQuestion;
        }

        private void editorEN1_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.EnglishOption1;
        }

        private void editorEN2_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.EnglishOption2;
        }

        private void editorEN3_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.EnglishOption3;
        }

        private void editorEN4_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.EnglishOption4;
        }

        private void editorHI1_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiOption1;
        }

        private void editorHI2_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiOption2;
        }

        private void editorHI3_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiOption3;
        }

        private void editorHI4_Enter(object sender, EventArgs e)
        {
            myenum = MyEnum.HindiOption4;
        }
        #endregion

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulaToolStripMenuItem_Click(null, null);
        }

        private void pasteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            var aa1 = iData.GetData("PNG");
            if (aa1 != null)
            {
                string ImageData = @"data:image/jpg;base64," + Convert.ToBase64String(((MemoryStream)aa1).ToArray());
                var aImg = "<IMG border=0 hspace=0 alt='' src='" + ImageData + "'align='baseline'>";
                Clipboard.SetText(aImg, TextDataFormat.Html);
            }
            var aa2 = iData.GetData("System.String", true);
            var HindiFontStart = "<FONT face=SHREE-DEV-0708E>";
            var HindiFontEnd = "</FONT>";

            switch (myenum)
            {
                case MyEnum.EnglishQuestion:
                    editor.Paste();
                    break;
                case MyEnum.EnglishOption1:
                    editorEN1.Paste();
                    break;
                case MyEnum.EnglishOption2:
                    editorEN2.Paste();
                    break;
                case MyEnum.EnglishOption3:
                    editorEN3.Paste();
                    break;
                case MyEnum.EnglishOption4:
                    editorEN4.Paste();
                    break;
                case MyEnum.HindiQuestion:
                    if (aa2 != null)
                    {
                        Clipboard.SetText(HindiFontStart + aa2.ToString() + HindiFontEnd, TextDataFormat.Html);
                    }
                    editor1.Paste();
                    break;
                case MyEnum.HindiOption1:
                    if (aa2 != null)
                    {
                        Clipboard.SetText(HindiFontStart + aa2.ToString() + HindiFontEnd, TextDataFormat.Html);
                    }
                    editorHI1.Paste();
                    break;
                case MyEnum.HindiOption2:
                    if (aa2 != null)
                    {
                        Clipboard.SetText(HindiFontStart + aa2.ToString() + HindiFontEnd, TextDataFormat.Html);
                    }
                    editorHI2.Paste();
                    break;
                case MyEnum.HindiOption3:
                    if (aa2 != null)
                    {
                        Clipboard.SetText(HindiFontStart + aa2.ToString() + HindiFontEnd, TextDataFormat.Html);
                    }
                    editorHI3.Paste();
                    break;
                case MyEnum.HindiOption4:
                    if (aa2 != null)
                    {
                        Clipboard.SetText(HindiFontStart + aa2.ToString() + HindiFontEnd, TextDataFormat.Html);
                    }
                    editorHI4.Paste();
                    break;
                default:

                    break;
            }

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

        private void comboBox_MainSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearSubSubjectCombo();
            fillSubSubjests();
        }

        private void clearSubSubjectCombo()
        {
            comboBox_SubSubject.DataSource = null;
        }

        private void fillSubSubjests()
        {
            int SelectedSubject;

            if (int.TryParse(comboBox_MainSubject.SelectedValue.ToString(), out SelectedSubject))
            {
                SqlDataAdapter dap = new SqlDataAdapter("select distinct SubSubjectID,SubSubjectName from SubSubjectMaster where SubSubjectID=" + SelectedSubject, con);
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                dap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    comboBox_SubSubject.DataSource = dt;
                    comboBox_SubSubject.ValueMember = "SubSubjectID";

                    //comboBox_MainSubject.Items.Insert(0, "--Select Subject--");
                    //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    //{
                    //    comboBox_MainSubject.Items.Add(dt.Rows[i][1].ToString());

                    //}
                    comboBox_SubSubject.DisplayMember = "SubSubjectName";
                }
            }
        }

        private void buttonCopyOptions_Click(object sender, EventArgs e)
        {
            editorHI1.BodyHtml = editorEN1.BodyHtml;
            editorHI2.BodyHtml = editorEN2.BodyHtml;
            editorHI3.BodyHtml = editorEN3.BodyHtml;
            editorHI4.BodyHtml = editorEN4.BodyHtml;
        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.EnableAutoSizePanels)
            {
                Properties.Settings.Default.SplitContainer1Height = e.SplitX;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer2Height = e.SplitX;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer3Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Properties.Settings.Default.SplitContainer4Height = splitContainer4.Height;
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer4Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer5Height = e.SplitX;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer6_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer6Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer7_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.SaveAllSplitEnabled)
            {
                Properties.Settings.Default.SplitContainer7Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }
        private void splitContainer8_SplitterMoved(object sender, SplitterEventArgs e)
        {

            if (Properties.Settings.Default.EnableAutoSizePanels)
            {
                Properties.Settings.Default.SplitContainer8Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }

        private void splitContainer9_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (Properties.Settings.Default.EnableAutoSizePanels)
            {
                Properties.Settings.Default.SplitContainer9Height = e.SplitY;
                Properties.Settings.Default.Save();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            #region Hindi
            var HindiFont = Properties.Settings.Default.DefaultHindiFont;
            var HindiFontSize = Math.Round((HindiFont.Size / 3.0)).ToString();
            var HindiFontName = HindiFont.FontFamily.GetName(0).ToString();

            editor1.Document.ExecCommand("SelectAll", false, "null");
            editor1.Document.ExecCommand("FontName", false, HindiFontName);
            editor1.Document.ExecCommand("FontSize", false, HindiFontSize);
            editor1.Document.ExecCommand("Unselect", false, "null");


            editorHI1.Document.ExecCommand("SelectAll", false, "null");
            editorHI1.Document.ExecCommand("FontName", false, HindiFontName);
            editorHI1.Document.ExecCommand("FontSize", false, HindiFontSize);
            editorHI1.Document.ExecCommand("Unselect", false, "null");


            editorHI2.Document.ExecCommand("SelectAll", false, "null");
            editorHI2.Document.ExecCommand("FontName", false, HindiFontName);
            editorHI2.Document.ExecCommand("FontSize", false, HindiFontSize);
            editorHI2.Document.ExecCommand("Unselect", false, "null");


            editorHI3.Document.ExecCommand("SelectAll", false, "null");
            editorHI3.Document.ExecCommand("FontName", false, HindiFontName);
            editorHI3.Document.ExecCommand("FontSize", false, HindiFontSize);
            editorHI3.Document.ExecCommand("Unselect", false, "null");

            editorHI4.Document.ExecCommand("SelectAll", false, "null");
            editorHI4.Document.ExecCommand("FontName", false, HindiFontName);
            editorHI4.Document.ExecCommand("FontSize", false, HindiFontSize);
            editorHI4.Document.ExecCommand("Unselect", false, "null");
            #endregion

            #region English

            var EngFont = Properties.Settings.Default.DefaultEnglishFont;
            var EngFontSize = Math.Round((EngFont.Size / 2.5)).ToString();
            var EngFontName = EngFont.FontFamily.GetName(0).ToString();

            editor.Document.ExecCommand("SelectAll", false, "null");
            editor.Document.ExecCommand("FontName", false, EngFontName);
            editor.Document.ExecCommand("FontSize", false, EngFontSize);
            editor.Document.ExecCommand("Unselect", false, "null");


            editorEN1.Document.ExecCommand("SelectAll", false, "null");
            editorEN1.Document.ExecCommand("FontName", false, EngFontName);
            editorEN1.Document.ExecCommand("FontSize", false, EngFontSize);
            editorEN1.Document.ExecCommand("Unselect", false, "null");


            editorEN2.Document.ExecCommand("SelectAll", false, "null");
            editorEN2.Document.ExecCommand("FontName", false, EngFontName);
            editorEN2.Document.ExecCommand("FontSize", false, EngFontSize);
            editorEN2.Document.ExecCommand("Unselect", false, "null");


            editorEN3.Document.ExecCommand("SelectAll", false, "null");
            editorEN3.Document.ExecCommand("FontName", false, EngFontName);
            editorEN3.Document.ExecCommand("FontSize", false, EngFontSize);
            editorEN3.Document.ExecCommand("Unselect", false, "null");

            editorEN4.Document.ExecCommand("SelectAll", false, "null");
            editorEN4.Document.ExecCommand("FontName", false, EngFontName);
            editorEN4.Document.ExecCommand("FontSize", false, EngFontSize);
            editorEN4.Document.ExecCommand("Unselect", false, "null");
            #endregion

            timer1.Stop();




            //HtmlElement head = editor.webBrowser1.Document.GetElementsByTagName("head")[0];
            //HtmlElement scriptEl = editor.webBrowser1.Document.CreateElement("script");
            //IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            //element.text = "function sayHello() { alert('hello') }";
            //head.AppendChild(scriptEl);
            //editor.webBrowser1.Document.InvokeScript("sayHello");
            //// editor.webBrowser1.Document.Write("<script>alert('s');</script>");

            //HtmlDocument doc = editor.webBrowser1.Document;
            //HtmlElement head = doc.GetElementsByTagName("head")[0];
            //HtmlElement s = doc.CreateElement("script");
            //s.SetAttribute("text", "function sayHello() { alert('hello'); }");
            //head.AppendChild(s);

            //editor.webBrowser1.Document.InvokeScript("sayHello();");
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {

                panel_paragraphPopup.Visible = true;

            }
            else
            {
                panel_paragraphPopup.Visible = false;
                //editor_Paragraph.Delete();
            }
            resetDefaults();
        }

        private void resetDefaults()
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                BtnSave.Visible = false;
                button_closeParagraphQuestion.Visible = true;
                buttonSaveParagraphQuestionsAndNexe.Visible = true;
            }
            else
            {
                BtnSave.Visible = true;
                button_closeParagraphQuestion.Visible = false;
                buttonSaveParagraphQuestionsAndNexe.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox1_CheckedChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* editor_Paragraph.Delete();*/

        }

        private void button_paragraphSave_Click(object sender, EventArgs e)
        {
            panel_paragraphPopup.Visible = false;
            if (con.State == ConnectionState.Closed) { con.Open(); }
            transaction = con.BeginTransaction();
            var SQL = "insert into QuestionParagraph(ParagraphText) values(@QuestionParagraphText) select @@IDENTITY";
            SqlCommand cmd = con.CreateCommand();

            cmd.Transaction = transaction;
            cmd.CommandText = SQL;
            cmd.Parameters.AddWithValue("@QuestionParagraphText", ""/*editor_Paragraph.BodyHtml*/);
            QuestionParagraphId = Convert.ToInt16(cmd.ExecuteScalar());

        }
        private void buttonSaveParagraphQuestionsAndNexe_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (QuestionParagraphId != 0)
            {
                if (checkBox1.CheckState == CheckState.Checked && editor.BodyHtml == null && editor1.BodyHtml == null && editorEN1.BodyHtml == null && editorEN2.BodyHtml == null && editorEN3.BodyHtml == null && editorEN4.BodyHtml == null)
                {
                    if (MsgBox.Show("It seens that you are creating an Paragrap question. \r\n but you are trying to save Empty Options and questions.so do you want to save{press YES} till last inserted Questions or want to add more{press NO}.", "Allert", MsgBox.Buttons.YesNo, MsgBox.Icon.Question) == DialogResult.Yes)
                    {
                        transaction.Commit();
                        /*editor_Paragraph.Delete();*/
                        checkBox1.Checked = false;
                        QuestionParagraphId = 0;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    var id = SaveQuestion(QuestionParagraphId);
                    if (id > 0)
                    {

                        if (id > 0)
                            transaction.Commit();
                        /*editor_Paragraph.Delete();*/
                        checkBox1.Checked = false;
                        QuestionParagraphId = 0;
                        ClearTextData();
                    }
                }
            }

        }
        private void button_closeParagraphQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (QuestionParagraphId != 0)
                {
                    if (checkBox1.CheckState == CheckState.Checked && editor.BodyHtml == null && editor1.BodyHtml == null && editorEN1.BodyHtml == null && editorEN2.BodyHtml == null && editorEN3.BodyHtml == null && editorEN4.BodyHtml == null)
                    {
                        if (MsgBox.Show("It seens that you are creating an Paragrap question. \r\n but you are trying to save Empty Options and questions.so do you want to save{press YES} till last inserted Questions or want to add more{press NO}.", "Allert", MsgBox.Buttons.YesNo, MsgBox.Icon.Question) == DialogResult.Yes)
                        {
                            transaction.Commit();
                            /* editor_Paragraph.Delete();*/
                            checkBox1.Checked = false;
                            QuestionParagraphId = 0;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        var id = SaveQuestion(QuestionParagraphId);
                        if (id > 0)
                            transaction.Commit();
                        /*editor_Paragraph.Delete();*/
                        checkBox1.Checked = false;
                        QuestionParagraphId = 0;

                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                con.Close();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Are you Sure Want to Clear all Questions answers including paragraph", "", MsgBox.Buttons.YesNo, MsgBox.Icon.Question, MsgBox.AnimateStyle.SlideDown) == System.Windows.Forms.DialogResult.Yes)
            {
                ClearTextData();
                /* editor_Paragraph.Delete();*/
                checkBox1.Checked = false;
                checkBox1_CheckedChanged(sender, e);
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string TableStart = "<table>";
            string TableRowStart = "<tr>";
            string TableDataStart = "<dt>";
            string TableDataEnd = "</dt>";
            string TableRowEnd = "</tr>";
            string TableEnd = "</tr></table>";

            var HtmlTable = TableStart
                + TableRowStart
                + TableDataStart + "" + TableEnd
                + TableDataStart + "" + TableEnd
                + TableDataStart + "" + TableEnd
                + TableRowEnd
                + TableEnd;

            //mshtml.HTMLTable table = new HTMLTable(); 
            //mshtml.HTMLTableRow tr = new HTMLTableRow();
            //table.cols = 2;
            //mshtml.HTMLTableRow tableRow;
            //for (int idxRow = 0; idxRow < numberRows; idxRow++)
            //{
            //    tableRow = (mshtml.HTMLTableRow)table.insertRow();
            //    // add the new columns to the end of each row
            //    for (int idxCol = 0; idxCol < numberCols; idxCol++)
            //    {
            //        tableRow.insertCell();
            //    }
            //}


            var bb = System.Web.HttpUtility.HtmlDecode(editor1.webBrowser1.Document.Body.InnerHtml);
            var aa = KrutitoUnicode(bb);
        }

        #region Concert to UNICODE
        private string UnicodetoKruti(string strInput)
        {
            string strOutPut = "";
            HtmlElementCollection theElementCollection;
            theElementCollection = webBrowser1.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if ((curElement.GetAttribute("id").ToString() == "unicode_text"))
                {
                    curElement.SetAttribute("Value", strInput);
                }

            }
            theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("id").Equals("converttoshree"))
                {
                    curElement.InvokeMember("click");
                    //  javascript has a click method for we need to invoke on button and hyperlink elements.
                }
            }

            theElementCollection = webBrowser1.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if ((curElement.GetAttribute("id").ToString() == "legacy_text"))
                {
                    strOutPut = curElement.GetAttribute("Value");
                }

            }
            return strOutPut;
        }

        //this function will convert kruti text to unicode
        private string KrutitoUnicode(string strInput)
        {
            string strOutPut = "";
            HtmlElementCollection theElementCollection;
            theElementCollection = webBrowser1.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if ((curElement.GetAttribute("id").ToString() == "legacy_text"))
                {
                    curElement.SetAttribute("Value", strInput);
                }
            }
            theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("id").Equals("converttounicode"))
                {
                    curElement.InvokeMember("click");
                    //  javascript has a click method for we need to invoke on button and hyperlink elements.
                }
            }
            theElementCollection = webBrowser1.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if ((curElement.GetAttribute("id").ToString() == "unicode_text"))
                {
                    strOutPut = curElement.GetAttribute("Value");
                }
            }
            return strOutPut;
        }
        #endregion
        #region PDF
        private void button2_Click_1(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(GeneratePDF));
            string htmlEnglish = editor.BodyHtml;
            string htmlEnglishOption1 = editorEN1.BodyHtml;
            string htmlEnglishOption2 = editorEN2.BodyHtml;
            string htmlEnglishOption3 = editorEN3.BodyHtml;
            string htmlEnglishOption4 = editorEN4.BodyHtml;





            string htmlHindi1 = KrutitoUnicode(editor1.Html);
            string htmlHindi = editor1.BodyHtml;
            string htmlHindiOption1 = editorHI1.BodyHtml;
            string htmlHindiOption2 = editorHI2.BodyHtml;
            string htmlHindiOption3 = editorHI3.BodyHtml;
            string htmlHindiOption4 = editorHI4.BodyHtml;
            var OptionFormateTextStart = "<TABLE class=MsoNormalTable style='BORDER-COLLAPSE: collapse; mso-table-layout-alt: fixed; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 0in 0in 0in' cellSpacing=0 cellPadding=0 width=322 border=0>" +
"<TBODY>" +
"<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes; mso-yfti-lastrow: yes'>" +
"<TD style='BORDER-TOP: #f0f0f0; BORDER-RIGHT: #f0f0f0; WIDTH: 22.5pt; BORDER-BOTTOM: #f0f0f0; PADDING-BOTTOM: 0in; PADDING-TOP: 0in; PADDING-LEFT: 0in; BORDER-LEFT: #f0f0f0; PADDING-RIGHT: 0in; BACKGROUND-COLOR: transparent' vAlign=top width=30>" +
"<P class=ttA style='MARGIN: 1pt 0in 0pt'><FONT size=2>";
            var OptionFormateTextMiddle = "</FONT><B style='mso-bidi-font-weight: normal'><?xml:namespace prefix = 'o' /><o:p></o:p></B></P></TD>" +
"<TD style='BORDER-TOP: #f0f0f0; BORDER-RIGHT: #f0f0f0; WIDTH: 81pt; BORDER-BOTTOM: #f0f0f0; PADDING-BOTTOM: 0in; PADDING-TOP: 0in; PADDING-LEFT: 0in; BORDER-LEFT: #f0f0f0; PADDING-RIGHT: 0in; BACKGROUND-COLOR: transparent' vAlign=top width=108>" +
"<P class=ttAtxtE style='MARGIN: 1pt 0in 0pt'><?xml:namespace prefix = 'v' ns = 'urn:schemas-microsoft-com:vml' /><v:shapetype id=_x0000_t75 coordsize='21600,21600' o:spt='75' o:preferrelative='t' path='m@4@5l@4@11@9@11@9@5xe' filled='f' stroked='f'><v:stroke joinstyle='miter'></v:stroke><v:formulas><v:f eqn='if lineDrawn pixelLineWidth 0'></v:f><v:f eqn='sum @0 1 0'></v:f><v:f eqn='sum 0 0 @1'></v:f><v:f eqn='prod @2 1 2'></v:f><v:f eqn='prod @3 21600 pixelWidth'></v:f><v:f eqn='prod @3 21600 pixelHeight'></v:f><v:f eqn='sum @0 0 1'></v:f><v:f eqn='prod @6 1 2'></v:f><v:f eqn='prod @7 21600 pixelWidth'></v:f><v:f eqn='sum @8 21600 0'></v:f><v:f eqn='prod @7 21600 pixelHeight'></v:f><v:f eqn='sum @10 21600 0'></v:f></v:formulas><v:path o:extrusionok='f' gradientshapeok='t' o:connecttype='rect'></v:path><o:lock v:ext='edit' aspectratio='t'></o:lock></v:shapetype><o:p>";
            var OptionFormateTextEnd = "</o:p></P></TD></TR></TBODY></TABLE>";
            var html = string.Format("Question 1.{0} <br /> " + OptionFormateTextStart + "a)" + OptionFormateTextMiddle + "{1}" + OptionFormateTextEnd + " &emsp;&emsp; " + OptionFormateTextStart + "b)" + OptionFormateTextMiddle + "{2}" + OptionFormateTextEnd + "  <br /> " + OptionFormateTextStart + "c) " + OptionFormateTextMiddle + "{3}" + OptionFormateTextEnd + " &emsp;&emsp; " + OptionFormateTextStart + "d)" + OptionFormateTextMiddle + "{4}" + OptionFormateTextEnd + "", htmlEnglish, htmlEnglishOption1, htmlEnglishOption2, htmlEnglishOption3, htmlEnglishOption4);
            var htmHindi = string.Format("Question 1.{0} <br /> a){1} &emsp;&emsp; b){2} <br /> c) {3} &emsp;&emsp; d){4}", htmlHindi1, htmlHindiOption1, htmlHindiOption2, htmlHindiOption3, htmlHindiOption4);
            var Final_HTML = string.Concat(html, htmlHindi);
            th.Start(htmlHindi1);
        }
        private void GeneratePDF(object obj)
        {
            var htmlContent = obj.ToString();
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            var filename = "Question.pdf";

            var tempFolder = System.IO.Path.GetTempPath();
            filename = System.IO.Path.Combine(tempFolder, filename);
            System.IO.File.WriteAllBytes(filename, pdfBytes);
            System.Diagnostics.Process.Start(filename);
        }

        #endregion
    }
}