using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using mshtml;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;


namespace Astrila.Eq2ImgWinForms
{
    public partial class EditorForm : Hlpr
    {
        private string _filename = null;
        //private static AutoCompleteStringCollection MainSubject = new AutoCompleteStringCollection();

        public EditorForm()
        {
            InitializeComponent();
            editor.Tick += new Editor.TickDelegate(editor_Tick);
        }
        private void EditorForm_Load(object sender, EventArgs e)
        {

            RegisterHotKey(Handle, 42, 0, (int)Keys.F1);
            RegisterHotKey(Handle, 42, 0, (int)Keys.F3);

            //= "SHREE-DEV7-0708E";
            FillAutoCompleteMainSubject();

            #region Load Defaults

            UpdateLanguage();
            #endregion

        }

        private void UpdateLanguage()
        {
            try
            {
                splitContainer1.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;
                splitContainer8.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;
                splitContainer9.IsSplitterFixed = !Properties.Settings.Default.EnableAutoSizePanels;

                //var FontFaimly = new FontFamily("SHREE-DEV7-0708E");
                ////Hindi Question Form
                ////  editor1.fontComboBox.SelectedIndex = 230;
                //editor1.fontComboBox.SelectedText = FontFaimly.Name;
                //editor1.fontComboBox_TextChanged(editor1.fontComboBox, null);
                //editor1.FontName = FontFaimly;
                //editor1.webBrowser1.Document.Encoding = "UTF-8";

                ////Hindi Question Form
                //// editorHI1.fontComboBox.SelectedIndex = 230;
                //editorHI1.fontComboBox.SelectedText = FontFaimly.Name;
                //editorHI1.fontComboBox_TextChanged(editorHI1.fontComboBox, null);
                //editorHI1.FontName = FontFaimly;
                //editorHI1.webBrowser1.Document.Encoding = "UTF-8";

                ////Hindi Question Form
                //// editorHI2.fontComboBox.SelectedIndex = 230;
                //editorHI2.fontComboBox.SelectedText = FontFaimly.Name;
                //editorHI2.fontComboBox_TextChanged(editorHI2.fontComboBox, null);
                //editorHI2.FontName = FontFaimly;
                //editorHI2.webBrowser1.Document.Encoding = "UTF-8";

                ////Hindi Question Form
                ////  editorHI3.fontComboBox.SelectedIndex = 230;
                //editorHI3.fontComboBox.SelectedText = FontFaimly.Name;
                //editorHI3.fontComboBox_TextChanged(editorHI3.fontComboBox, null);
                //editorHI3.FontName = FontFaimly;
                //editorHI3.webBrowser1.Document.Encoding = "UTF-8";

                ////Hindi Question Form
                ////  editorHI4.fontComboBox.SelectedIndex = 230;
                //editorHI4.fontComboBox.SelectedText = FontFaimly.Name;
                //editorHI4.fontComboBox_TextChanged(editorHI4.fontComboBox, null);
                //editorHI4.FontName = FontFaimly;
                //editorHI4.webBrowser1.Document.Encoding = "UTF-8";





            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using (TextInsertForm form = new TextInsertForm(editor.BodyHtml))
            {
                form.ShowDialog(this);
                if (form.Accepted)
                {
                    editor.BodyHtml = form.HTML;
                }
            }
        }

        private void paragraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertParagraph();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertImage();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editor.ToMailMessage());
            form.ShowDialog();
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
            SqlTransaction transaction = null;
            var aaa = Encoding.UTF8.GetBytes(editor1.BodyHtml.ToString());
            // return;
            // var sss1 = this.editor.BodyHtml;
            //var sss2 = this.editor1.Html;// by path
            var MainSubjectID = Convert.ToInt16(comboBox_MainSubject.SelectedValue);
            var SubjectTopicID = Convert.ToInt16(comboBox_SubSubject.SelectedValue);
            try
            {

                if (con.State == ConnectionState.Closed) { con.Open(); }
                transaction = con.BeginTransaction();
                var SQL = "insert into QuestionMaster(QueSubjectID,QueSubSubjectID,QueTitleEng,QueTitleHindi,QueIsActive,QueIsApproved,QueCreateBy) values(" + MainSubjectID + "," + SubjectTopicID + ",@ques,@quesHI11111,1,0,1) select @@IDENTITY";
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@ques", this.editor.BodyHtml.ToString());
                cmd.Parameters.AddWithValue("@quesHI11111", this.editor1.BodyHtml ?? "");

                var LastQuestionID = cmd.ExecuteScalar();


                #region English,Hindi
                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN1,@quesHI1,1)";
                cmd.Parameters.AddWithValue("@quesEN1", this.editorEN1.BodyHtml ?? "");
                cmd.Parameters.AddWithValue("@quesHI1", this.editorHI1.BodyHtml ?? "");

                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN2,@quesHI2,2)";
                cmd.Parameters.AddWithValue("@quesEN2", this.editorEN2.BodyHtml ?? "");
                cmd.Parameters.AddWithValue("@quesHI2", this.editorHI2.BodyHtml ?? "");
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN3,@quesHI3,3)";
                cmd.Parameters.AddWithValue("@quesEN3", this.editorEN3.BodyHtml ?? "");
                cmd.Parameters.AddWithValue("@quesHI3", this.editorHI3.BodyHtml ?? "");
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into QuestionDetail(QueOption_QuestionID,QueOption_Eng,QueOption_Hindi,QueOption_Sqn) values(" + LastQuestionID + ",@quesEN4,@quesHI4,4)";
                cmd.Parameters.AddWithValue("@quesEN4", this.editorEN4.BodyHtml ?? "");
                cmd.Parameters.AddWithValue("@quesHI4", this.editorHI4.BodyHtml ?? "");
                cmd.ExecuteNonQuery();
                #endregion

                transaction.Commit();
                MessageBox.Show(this, "Saved Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                ClearTextData();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                if (MessageBox.Show(this, "Failure!! Please click On Retry otherwise cancel ant try to save again", "Success", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Retry)
                {
                    transaction.Commit();
                    ClearTextData();
                }
                else
                {
                    transaction.Rollback();
                    MessageBox.Show(this, "Failure!! Please Check your Network", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void ClearTextData()
        {
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

                var aImg = "<IMG border=0 hspace=0 alt='' src='" + GetImage(dialogform.tempGifFilePath) + "'align=baseline>";

                switch (myenum)
                {
                    case MyEnum.EnglishQuestion:
                        // HtmlElement currentElement = editor.webBrowser1.Document.GetElementFromPoint(p);
                        // currentElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, userimage);
                        //editor.webBrowser1.Document.Body.AppendChild(userimage);
                        editor.BodyHtml = editor.BodyHtml + aImg;
                        break;
                    case MyEnum.EnglishOption1:
                        editorEN1.BodyHtml = editorEN1.BodyHtml + aImg;
                        //  editorEN1.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption2:
                        editorEN2.BodyHtml = editorEN2.BodyHtml + aImg;
                        // editorEN2.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption3:
                        editorEN3.BodyHtml = editorEN3.BodyHtml + aImg;
                        //editorEN3.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.EnglishOption4:
                        editorEN4.BodyHtml = editorEN4.BodyHtml + aImg;
                        // editorEN4.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiQuestion:
                        // HtmlElement currentElement1 = editor1.webBrowser1.Document.GetElementFromPoint(p);
                        //currentElement1.Id
                        // .InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, userimage);
                        // editor1.webBrowser1.Document.Body.AppendChild(userimage);
                        editor1.BodyHtml = editor1.BodyHtml + aImg;
                        break;
                    case MyEnum.HindiOption1:
                        editorHI1.BodyHtml = editorHI1.BodyHtml + aImg;
                        // editorHI1.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption2:
                        editorHI2.BodyHtml = editorHI2.BodyHtml + aImg;
                        //editorHI2.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption3:
                        editorHI3.BodyHtml = editorHI3.BodyHtml + aImg;
                        // editorHI3.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    case MyEnum.HindiOption4:
                        editorHI4.BodyHtml = editorHI4.BodyHtml + aImg;
                        //editorHI4.webBrowser1.Document.Body.AppendChild(userimage);
                        break;
                    default:
                        MessageBox.Show("Please Select a Question or Answer first");
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
                MessageBox.Show("Changed Successfully!!");
                MessageBox.Show(this, "Changed Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
    }
}