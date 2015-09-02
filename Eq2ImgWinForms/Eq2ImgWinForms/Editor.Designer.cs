namespace Astrila.Eq2ImgWinForms
{
    partial class Editor
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
            this.components = new System.ComponentModel.Container();
            this.tsTopToolBar = new System.Windows.Forms.ToolStrip();
            this.cmsHtml = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.resetColumnWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fontComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fontSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tsbItalic = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.colorButton = new System.Windows.Forms.ToolStripButton();
            this.backColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.linkButton = new System.Windows.Forms.ToolStripButton();
            this.imageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbJustifyLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyRight = new System.Windows.Forms.ToolStripButton();
            this.tsbJustifyFull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInsertOrderedList = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertUnorderedList = new System.Windows.Forms.ToolStripButton();
            this.outdentButton = new System.Windows.Forms.ToolStripButton();
            this.indentButton = new System.Windows.Forms.ToolStripButton();
            this.tsddbInsertTable = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbSuperscript = new System.Windows.Forms.ToolStripButton();
            this.tsbSubscript = new System.Windows.Forms.ToolStripButton();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbSpellCheck = new System.Windows.Forms.ToolStripButton();
            this.btnExportPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.wordDictionary = new NetSpell.SpellChecker.Dictionary.WordDictionary(this.components);
            this.spellCheck = new NetSpell.SpellChecker.Spelling(this.components);
            this.hrulerControl = new Lyquidity.UtilityLibrary.Controls.RulerControl();
            this.rulerWord = new Lyquidity.UtilityLibrary.Controls.RulerControl();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tsTopToolBar.SuspendLayout();
            this.cmsHtml.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTopToolBar
            // 
            this.tsTopToolBar.ContextMenuStrip = this.cmsHtml;
            this.tsTopToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTopToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontComboBox,
            this.fontSizeComboBox,
            this.toolStripSeparator1,
            this.tsbBold,
            this.tsbItalic,
            this.tsbUnderline,
            this.toolStripSeparator4,
            this.colorButton,
            this.backColorButton,
            this.toolStripSeparator2,
            this.linkButton,
            this.imageButton,
            this.toolStripSeparator3,
            this.tsbJustifyLeft,
            this.tsbJustifyCenter,
            this.tsbJustifyRight,
            this.tsbJustifyFull,
            this.toolStripSeparator5,
            this.tsbInsertOrderedList,
            this.tsbInsertUnorderedList,
            this.outdentButton,
            this.indentButton,
            this.tsddbInsertTable,
            this.tsbSuperscript,
            this.tsbSubscript,
            this.tsbPreview,
            this.tsbSpellCheck,
            this.btnExportPDF});
            this.tsTopToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsTopToolBar.Name = "tsTopToolBar";
            this.tsTopToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsTopToolBar.Size = new System.Drawing.Size(718, 25);
            this.tsTopToolBar.TabIndex = 1;
            this.tsTopToolBar.Text = "toolStrip1";
            // 
            // cmsHtml
            // 
            this.cmsHtml.AllowDrop = true;
            this.cmsHtml.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTable,
            this.tsmiSelectAll,
            this.tsmiCopy,
            this.tsmiCut,
            this.tsmiPaste,
            this.tsmiDelete,
            this.tsmiFind,
            this.tsmiRemoveFormat,
            this.toolStripSeparator6,
            this.tsmiSave});
            this.cmsHtml.Name = "contextMenuWeb";
            this.cmsHtml.Size = new System.Drawing.Size(164, 208);
            // 
            // tsmiTable
            // 
            this.tsmiTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTableModify,
            this.tsmiTableInsertRow,
            this.tsmiTableDeleteRow,
            this.resetColumnWidthToolStripMenuItem});
            this.tsmiTable.Name = "tsmiTable";
            this.tsmiTable.Size = new System.Drawing.Size(163, 22);
            this.tsmiTable.Tag = "Table";
            this.tsmiTable.Text = "Form";
            // 
            // tsmiTableModify
            // 
            this.tsmiTableModify.Name = "tsmiTableModify";
            this.tsmiTableModify.Size = new System.Drawing.Size(181, 22);
            this.tsmiTableModify.Tag = "TableModify";
            this.tsmiTableModify.Text = "Edit table properties";
            this.tsmiTableModify.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiTableInsertRow
            // 
            this.tsmiTableInsertRow.Name = "tsmiTableInsertRow";
            this.tsmiTableInsertRow.Size = new System.Drawing.Size(181, 22);
            this.tsmiTableInsertRow.Tag = "TableInsertRow";
            this.tsmiTableInsertRow.Text = "Insert Row";
            this.tsmiTableInsertRow.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiTableDeleteRow
            // 
            this.tsmiTableDeleteRow.Name = "tsmiTableDeleteRow";
            this.tsmiTableDeleteRow.Size = new System.Drawing.Size(181, 22);
            this.tsmiTableDeleteRow.Tag = "TableDeleteRow";
            this.tsmiTableDeleteRow.Text = "Remove row";
            this.tsmiTableDeleteRow.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // resetColumnWidthToolStripMenuItem
            // 
            this.resetColumnWidthToolStripMenuItem.Name = "resetColumnWidthToolStripMenuItem";
            this.resetColumnWidthToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.resetColumnWidthToolStripMenuItem.Tag = "Resetcolumn ";
            this.resetColumnWidthToolStripMenuItem.Text = "Reset column Width";
            this.resetColumnWidthToolStripMenuItem.ToolTipText = "Resetcolumn ";
            this.resetColumnWidthToolStripMenuItem.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(163, 22);
            this.tsmiSelectAll.Tag = "SelectAll";
            this.tsmiSelectAll.Text = "select all";
            this.tsmiSelectAll.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(163, 22);
            this.tsmiCopy.Tag = "Copy";
            this.tsmiCopy.Text = "Copy";
            this.tsmiCopy.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(163, 22);
            this.tsmiCut.Tag = "Cut";
            this.tsmiCut.Text = "Cut";
            this.tsmiCut.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(163, 22);
            this.tsmiPaste.Tag = "Paste";
            this.tsmiPaste.Text = "Paste";
            this.tsmiPaste.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(163, 22);
            this.tsmiDelete.Tag = "Delete";
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiFind
            // 
            this.tsmiFind.Name = "tsmiFind";
            this.tsmiFind.Size = new System.Drawing.Size(163, 22);
            this.tsmiFind.Tag = "Find";
            this.tsmiFind.Text = "Find";
            this.tsmiFind.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // tsmiRemoveFormat
            // 
            this.tsmiRemoveFormat.Name = "tsmiRemoveFormat";
            this.tsmiRemoveFormat.Size = new System.Drawing.Size(163, 22);
            this.tsmiRemoveFormat.Tag = "RemoveFormat";
            this.tsmiRemoveFormat.Text = "Clear Formatting";
            this.tsmiRemoveFormat.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(163, 22);
            this.tsmiSave.Tag = "Save";
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.ContextEditorClick);
            // 
            // fontComboBox
            // 
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(140, 25);
            this.fontComboBox.ToolTipText = "Font";
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(75, 25);
            this.fontSizeComboBox.ToolTipText = "Font Size";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBold
            // 
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.bold;
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(23, 22);
            this.tsbBold.Text = "toolStripButton1";
            this.tsbBold.ToolTipText = "Bold";
            this.tsbBold.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // tsbItalic
            // 
            this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItalic.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.italic;
            this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItalic.Name = "tsbItalic";
            this.tsbItalic.Size = new System.Drawing.Size(23, 22);
            this.tsbItalic.Text = "toolStripButton2";
            this.tsbItalic.ToolTipText = "Italic";
            this.tsbItalic.Click += new System.EventHandler(this.italicButton_Click);
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.underscore;
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsbUnderline.Text = "toolStripButton3";
            this.tsbUnderline.ToolTipText = "Underline";
            this.tsbUnderline.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // colorButton
            // 
            this.colorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.color;
            this.colorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(23, 22);
            this.colorButton.Text = "toolStripButton3";
            this.colorButton.ToolTipText = "Font Color";
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backColorButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.backcolor;
            this.backColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(23, 22);
            this.backColorButton.Text = "toolStripButton3";
            this.backColorButton.ToolTipText = "Back Color";
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // linkButton
            // 
            this.linkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.linkButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.link;
            this.linkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.linkButton.Name = "linkButton";
            this.linkButton.Size = new System.Drawing.Size(23, 22);
            this.linkButton.Text = "toolStripButton3";
            this.linkButton.ToolTipText = "Hyperlink";
            this.linkButton.Click += new System.EventHandler(this.linkButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imageButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.image;
            this.imageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(23, 22);
            this.imageButton.Text = "toolStripButton3";
            this.imageButton.ToolTipText = "Image";
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbJustifyLeft
            // 
            this.tsbJustifyLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyLeft.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.lj;
            this.tsbJustifyLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyLeft.Name = "tsbJustifyLeft";
            this.tsbJustifyLeft.Size = new System.Drawing.Size(23, 22);
            this.tsbJustifyLeft.Tag = "JustifyLeft";
            this.tsbJustifyLeft.Text = "Left-aligned";
            this.tsbJustifyLeft.ToolTipText = "Justify Left";
            this.tsbJustifyLeft.Click += new System.EventHandler(this.justifyLeftButton_Click);
            // 
            // tsbJustifyCenter
            // 
            this.tsbJustifyCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyCenter.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.cj;
            this.tsbJustifyCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyCenter.Name = "tsbJustifyCenter";
            this.tsbJustifyCenter.Size = new System.Drawing.Size(23, 22);
            this.tsbJustifyCenter.Tag = "JustifyCenter";
            this.tsbJustifyCenter.Text = "Align 0";
            this.tsbJustifyCenter.ToolTipText = "Align 0";
            this.tsbJustifyCenter.Click += new System.EventHandler(this.justifyCenterButton_Click);
            // 
            // tsbJustifyRight
            // 
            this.tsbJustifyRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyRight.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.rj;
            this.tsbJustifyRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyRight.Name = "tsbJustifyRight";
            this.tsbJustifyRight.Size = new System.Drawing.Size(23, 22);
            this.tsbJustifyRight.Tag = "JustifyRight";
            this.tsbJustifyRight.Text = "Align Right";
            this.tsbJustifyRight.ToolTipText = "Justify Right";
            this.tsbJustifyRight.Click += new System.EventHandler(this.justifyRightButton_Click);
            // 
            // tsbJustifyFull
            // 
            this.tsbJustifyFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbJustifyFull.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.fj;
            this.tsbJustifyFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJustifyFull.Name = "tsbJustifyFull";
            this.tsbJustifyFull.Size = new System.Drawing.Size(23, 22);
            this.tsbJustifyFull.Tag = "JustifyFull";
            this.tsbJustifyFull.Text = "Justify";
            this.tsbJustifyFull.ToolTipText = "Justify";
            this.tsbJustifyFull.Click += new System.EventHandler(this.justifyFullButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbInsertOrderedList
            // 
            this.tsbInsertOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertOrderedList.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.ol;
            this.tsbInsertOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertOrderedList.Name = "tsbInsertOrderedList";
            this.tsbInsertOrderedList.Size = new System.Drawing.Size(23, 22);
            this.tsbInsertOrderedList.Tag = "InsertOrderedList";
            this.tsbInsertOrderedList.Text = "Insert an ordered list";
            this.tsbInsertOrderedList.ToolTipText = "Ordered List";
            this.tsbInsertOrderedList.Click += new System.EventHandler(this.orderedListButton_Click);
            // 
            // tsbInsertUnorderedList
            // 
            this.tsbInsertUnorderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertUnorderedList.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.uol;
            this.tsbInsertUnorderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertUnorderedList.Name = "tsbInsertUnorderedList";
            this.tsbInsertUnorderedList.Size = new System.Drawing.Size(23, 22);
            this.tsbInsertUnorderedList.Tag = "InsertUnorderedList";
            this.tsbInsertUnorderedList.Text = "Insert an unordered list";
            this.tsbInsertUnorderedList.ToolTipText = "Unordered List";
            this.tsbInsertUnorderedList.Click += new System.EventHandler(this.unorderedListButton_Click);
            // 
            // outdentButton
            // 
            this.outdentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outdentButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.outdent;
            this.outdentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outdentButton.Name = "outdentButton";
            this.outdentButton.Size = new System.Drawing.Size(23, 22);
            this.outdentButton.Text = "toolStripButton3";
            this.outdentButton.ToolTipText = "Outdent";
            this.outdentButton.Click += new System.EventHandler(this.outdentButton_Click);
            // 
            // indentButton
            // 
            this.indentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.indentButton.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.indent;
            this.indentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.indentButton.Name = "indentButton";
            this.indentButton.Size = new System.Drawing.Size(23, 22);
            this.indentButton.Text = "toolStripButton4";
            this.indentButton.ToolTipText = "Indent";
            this.indentButton.Click += new System.EventHandler(this.indentButton_Click);
            // 
            // tsddbInsertTable
            // 
            this.tsddbInsertTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbInsertTable.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.InsertTable;
            this.tsddbInsertTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbInsertTable.Name = "tsddbInsertTable";
            this.tsddbInsertTable.Size = new System.Drawing.Size(29, 22);
            this.tsddbInsertTable.Text = "toolStripButton3";
            // 
            // tsbSuperscript
            // 
            this.tsbSuperscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSuperscript.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.Superscript_;
            this.tsbSuperscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSuperscript.Name = "tsbSuperscript";
            this.tsbSuperscript.Size = new System.Drawing.Size(23, 22);
            this.tsbSuperscript.Tag = "Superscript";
            this.tsbSuperscript.Text = "Superscript";
            this.tsbSuperscript.Click += new System.EventHandler(this.tsbSuperscript_Click);
            // 
            // tsbSubscript
            // 
            this.tsbSubscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSubscript.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.Subscript_;
            this.tsbSubscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSubscript.Name = "tsbSubscript";
            this.tsbSubscript.Size = new System.Drawing.Size(23, 22);
            this.tsbSubscript.Tag = "Subscript";
            this.tsbSubscript.Text = "Subscript";
            this.tsbSubscript.Click += new System.EventHandler(this.tsbSubscript_Click);
            // 
            // tsbPreview
            // 
            this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreview.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.Preview;
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(23, 22);
            this.tsbPreview.Tag = "Preview";
            this.tsbPreview.Text = "Preview";
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tsbSpellCheck
            // 
            this.tsbSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpellCheck.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.SpellCheck;
            this.tsbSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpellCheck.Name = "tsbSpellCheck";
            this.tsbSpellCheck.Size = new System.Drawing.Size(23, 20);
            this.tsbSpellCheck.Tag = "SpellCheck";
            this.tsbSpellCheck.Text = "Spell Checking";
            this.tsbSpellCheck.Click += new System.EventHandler(this.tsbSpellCheck_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportPDF.Image = global::Astrila.Eq2ImgWinForms.Properties.Resources.pdf;
            this.btnExportPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(23, 20);
            this.btnExportPDF.Tag = "Export PDF";
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem2
            // 
            this.pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            this.pasteToolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.pasteToolStripMenuItem1.Text = "Paste";
            // 
            // wordDictionary
            // 
            this.wordDictionary.DictionaryFile = "en-US.dic";
            this.wordDictionary.DictionaryFolder = "dic";
            // 
            // spellCheck
            // 
            this.spellCheck.Dictionary = this.wordDictionary;
            // 
            // hrulerControl
            // 
            this.hrulerControl.ActualSize = true;
            this.hrulerControl.BackColor = System.Drawing.Color.Khaki;
            this.hrulerControl.DivisionMarkFactor = 5;
            this.hrulerControl.Divisions = 10;
            this.hrulerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.hrulerControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrulerControl.Location = new System.Drawing.Point(0, 25);
            this.hrulerControl.MajorInterval = 1;
            this.hrulerControl.MiddleMarkFactor = 3;
            this.hrulerControl.MouseTrackingOn = true;
            this.hrulerControl.Name = "hrulerControl";
            this.hrulerControl.Orientation = Lyquidity.UtilityLibrary.Controls.enumOrientation.orHorizontal;
            this.hrulerControl.RulerAlignment = Lyquidity.UtilityLibrary.Controls.enumRulerAlignment.raBottomOrRight;
            this.hrulerControl.ScaleMode = Lyquidity.UtilityLibrary.Controls.enumScaleMode.smCentimetres;
            this.hrulerControl.Size = new System.Drawing.Size(718, 16);
            this.hrulerControl.StartValue = 0D;
            this.hrulerControl.TabIndex = 3;
            this.hrulerControl.VerticalNumbers = false;
            this.hrulerControl.ZoomFactor = 1D;
            // 
            // rulerWord
            // 
            this.rulerWord.ActualSize = true;
            this.rulerWord.DivisionMarkFactor = 10;
            this.rulerWord.Divisions = 5;
            this.rulerWord.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rulerWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulerWord.ForeColor = System.Drawing.Color.Black;
            this.rulerWord.Location = new System.Drawing.Point(0, 135);
            this.rulerWord.MajorInterval = 36;
            this.rulerWord.MiddleMarkFactor = 8;
            this.rulerWord.MouseTrackingOn = true;
            this.rulerWord.Name = "rulerWord";
            this.rulerWord.Orientation = Lyquidity.UtilityLibrary.Controls.enumOrientation.orHorizontal;
            this.rulerWord.RulerAlignment = Lyquidity.UtilityLibrary.Controls.enumRulerAlignment.raMiddle;
            this.rulerWord.ScaleMode = Lyquidity.UtilityLibrary.Controls.enumScaleMode.smPoints;
            this.rulerWord.Size = new System.Drawing.Size(718, 15);
            this.rulerWord.StartValue = -72D;
            this.rulerWord.TabIndex = 14;
            this.rulerWord.Text = "rulerControl1";
            this.rulerWord.VerticalNumbers = false;
            this.rulerWord.ZoomFactor = 1D;
            // 
            // webBrowser1
            // 
            this.webBrowser1.ContextMenuStrip = this.cmsHtml;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(718, 125);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("http://-", System.UriKind.Absolute);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rulerWord);
            this.Controls.Add(this.hrulerControl);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.tsTopToolBar);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(718, 150);
            this.tsTopToolBar.ResumeLayout(false);
            this.tsTopToolBar.PerformLayout();
            this.cmsHtml.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip tsTopToolBar;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private System.Windows.Forms.ToolStripButton tsbItalic;
        public System.Windows.Forms.ToolStripComboBox fontComboBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripComboBox fontSizeComboBox;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripButton colorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton linkButton;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton imageButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton outdentButton;
        private System.Windows.Forms.ToolStripButton indentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton backColorButton;
        private System.Windows.Forms.ToolStripButton tsbInsertOrderedList;
        private System.Windows.Forms.ToolStripButton tsbInsertUnorderedList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbJustifyLeft;
        private System.Windows.Forms.ToolStripButton tsbJustifyCenter;
        private System.Windows.Forms.ToolStripButton tsbJustifyRight;
        private System.Windows.Forms.ToolStripButton tsbJustifyFull;
        private System.Windows.Forms.ToolStripDropDownButton tsddbInsertTable;
        private System.Windows.Forms.ContextMenuStrip cmsHtml;
        private System.Windows.Forms.ToolStripMenuItem tsmiTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableModify;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableInsertRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiFind;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripButton tsbSuperscript;
        private System.Windows.Forms.ToolStripButton tsbSubscript;
        private System.Windows.Forms.ToolStripButton tsbPreview;
        private System.Windows.Forms.ToolStripMenuItem resetColumnWidthToolStripMenuItem;
        private NetSpell.SpellChecker.Dictionary.WordDictionary wordDictionary;
        private NetSpell.SpellChecker.Spelling spellCheck;
        private System.Windows.Forms.ToolStripButton tsbSpellCheck;
        private System.Windows.Forms.ToolStripButton btnExportPDF;
        private Lyquidity.UtilityLibrary.Controls.RulerControl hrulerControl;
        private Lyquidity.UtilityLibrary.Controls.RulerControl rulerWord;

    }
}

