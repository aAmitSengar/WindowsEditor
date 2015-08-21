using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using mshtml;
using mshtmlTable = mshtml.IHTMLTable;
using mshtmlTableCaption = mshtml.IHTMLTableCaption;
using mshtmlTableRow = mshtml.IHTMLTableRow;
using mshtmlTableCell = mshtml.IHTMLTableCell;
using mshtmlTableRowMetrics = mshtml.IHTMLTableRowMetrics;
using mshtmlTableColumn = mshtml.IHTMLTableCol;
using mshtmlElementCollection = mshtml.IHTMLElementCollection;


using mshtmlSelection = mshtml.IHTMLSelectionObject;
using mshtmlControlRange = mshtml.IHTMLControlRange;
using mshtmlElement = mshtml.IHTMLElement;
using mshtmlStyle = mshtml.IHTMLStyle;
using mshtmlDomNode = mshtml.IHTMLDOMNode;

using mshtmlDocument = mshtml.HTMLDocument;
using mshtmlBody = mshtml.HTMLBody;
using mshtmlStyleSheet = mshtml.IHTMLStyleSheet;
using mshtmlStyleElement = mshtml.IHTMLStyleElement;


using mshtmlDomTextNode = mshtml.IHTMLDOMTextNode;
using mshtmlTextRange = mshtml.IHTMLTxtRange;
using mshtmlScriptElement = mshtml.IHTMLScriptElement;
using Astrila.Eq2ImgWinForms.Helper;


using Pavonis.COM;
using Pavonis.COM.IOleCommandTarget;
using System.IO.Compression;
using Astrila.Eq2ImgWinForms.Properties;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.Threading;


namespace Astrila.Eq2ImgWinForms
{
    public interface SearchableBrowser
    {
        bool Search(string text, bool forward, bool matchWholeWord, bool matchCase);
    }
    [Docking(DockingBehavior.Ask), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch), ToolboxBitmap(typeof(Editor), "Resources.HTML.bmp")]
    public partial class Editor : UserControl, SearchableBrowser
    {
        /// <summary>
        /// Public event that is raised if an internal processing exception is found
        /// </summary>
        [Category("Exception"), Description("An Internal Processing Exception was encountered")]
        public event HtmlExceptionEventHandler HtmlException;

        /// <summary>
        /// Public event that is raised if navigation event is captured
        /// </summary>
        [Category("Navigation"), Description("A Navigation Event was encountered")]
        public event HtmlNavigationEventHandler HtmlNavigation;
        #region Constant Defintions

        // general constants
        private const int HTML_BUFFER_SIZE = 256;
        private const byte DEFAULT_BORDER_SIZE = 2;

        // define the tags being used by the application
        private const string BODY_TAG = "BODY";
        private const string SCRIPT_TAG = "SCRIPT";
        private const string STYLE_TAG = "STYLE";
        private const string ANCHOR_TAG = "A";
        private const string FONT_TAG = "FONT";
        private const string BOLD_TAG = "STRONG";
        private const string UNDERLINE_TAG = "U";
        private const string ITALIC_TAG = "EM";
        private const string STRIKE_TAG = "STRIKE";
        private const string SUBSCRIPT_TAG = "SUB";
        private const string SUPERSCRIPT_TAG = "SUP";
        private const string HEAD_TAG = "HEAD";
        private const string IMAGE_TAG = "IMG";
        private const string TABLE_TAG = "TABLE";
        private const string TABLE_ROW_TAG = "TR";
        private const string TABLE_CELL_TAG = "TD";
        private const string TABLE_HEAD_TAG = "TH";
        private const string SPAN_TAG = "SPAN";
        private const string OPEN_TAG = "<";
        private const string CLOSE_TAG = ">";
        private const string SELECT_TYPE_TEXT = "text";
        private const string SELECT_TYPE_CONTROL = "control";
        private const string SELECT_TYPE_NONE = "none";

        // define commands for mshtml execution execution
        private const string HTML_COMMAND_INSERT_UNORDERED_LIST = "InsertUnorderedList";
        private const string HTML_COMMAND_INSERT_ORDERED_LIST = "InsertOrderedList";
        private const string HTML_COMMAND_OVERWRITE = "OverWrite";
        private const string HTML_COMMAND_BOLD = "Bold";
        private const string HTML_COMMAND_UNDERLINE = "Underline";
        private const string HTML_COMMAND_ITALIC = "Italic";
        private const string HTML_COMMAND_SUBSCRIPT = "Subscript";
        private const string HTML_COMMAND_SUPERSCRIPT = "Superscript";
        private const string HTML_COMMAND_STRIKE_THROUGH = "StrikeThrough";
        private const string HTML_COMMAND_FONT_NAME = "FontName";
        private const string HTML_COMMAND_FONT_SIZE = "FontSize";
        private const string HTML_COMMAND_FORE_COLOR = "ForeColor";
        private const string HTML_COMMAND_INSERT_FORMAT_BLOCK = "FormatBlock";
        private const string HTML_COMMAND_REMOVE_FORMAT = "RemoveFormat";
        private const string HTML_COMMAND_JUSTIFY_LEFT = "JustifyLeft";
        private const string HTML_COMMAND_JUSTIFY_CENTER = "JustifyCenter";
        private const string HTML_COMMAND_JUSTIFY_RIGHT = "JustifyRight";
        private const string HTML_COMMAND_INDENT = "Indent";
        private const string HTML_COMMAND_OUTDENT = "Outdent";
        private const string HTML_COMMAND_INSERT_LINE = "InsertHorizontalRule";
        private const string HTML_COMMAND_INSERT_LIST = "Insert{0}List"; // replace with (Un)Ordered
        private const string HTML_COMMAND_INSERT_IMAGE = "InsertImage";
        private const string HTML_COMMAND_INSERT_LINK = "CreateLink";
        private const string HTML_COMMAND_REMOVE_LINK = "Unlink";
        private const string HTML_COMMAND_TEXT_CUT = "Cut";
        private const string HTML_COMMAND_TEXT_COPY = "Copy";
        private const string HTML_COMMAND_TEXT_PASTE = "Paste";
        private const string HTML_COMMAND_TEXT_DELETE = "Delete";
        private const string HTML_COMMAND_TEXT_UNDO = "Undo";
        private const string HTML_COMMAND_TEXT_REDO = "Redo";
        private const string HTML_COMMAND_TEXT_SELECT_ALL = "SelectAll";
        private const string INTERNAL_COMMAND_WORDCOUNT = "WordCount";
        private const string HTML_COMMAND_TEXT_UNSELECT = "Unselect";
        private const string HTML_COMMAND_TEXT_PRINT = "Print";
        private const string HTML_FORMATTED_PRE = "Formatted";
        private const string HTML_FORMATTED_NORMAL = "Normal";
        private const string HTML_FORMATTED_HEADING = "Heading";
        private const string HTML_FORMATTED_HEADING1 = "Heading 1";
        private const string HTML_FORMATTED_HEADING2 = "Heading 2";
        private const string HTML_FORMATTED_HEADING3 = "Heading 3";
        private const string HTML_FORMATTED_HEADING4 = "Heading 4";
        private const string HTML_FORMATTED_HEADING5 = "Heading 5";

        // internal command constants
        private const string INTERNAL_COMMAND_NEW = "New";
        private const string INTERNAL_COMMAND_OPEN = "Open";
        private const string INTERNAL_COMMAND_PRINT = "Print";
        private const string INTERNAL_COMMAND_SAVE = "Save";
        private const string INTERNAL_COMMAND_PREVIEW = "Preview";
        private const string INTERNAL_COMMAND_SHOWHTML = "ShowHTML";
        private const string INTERNAL_COMMAND_COPY = "Copy";
        private const string INTERNAL_COMMAND_PASTE = "Paste";
        private const string INTERNAL_COMMAND_CUT = "Cut";
        private const string INTERNAL_COMMAND_DELETE = "Delete";
        private const string INTERNAL_COMMAND_UNDO = "Undo";
        private const string INTERNAL_COMMAND_REDO = "Redo";
        private const string INTERNAL_COMMAND_FIND = "Find";
        private const string INTERNAL_COMMAND_REMOVE_FORMAT = "RemoveFormat";
        private const string INTERNAL_COMMAND_JUSTIFYCENTER = "JustifyCenter";
        private const string INTERNAL_COMMAND_JUSTIFYFULL = "JustifyFull";
        private const string INTERNAL_COMMAND_JUSTIFYLEFT = "JustifyLeft";
        private const string INTERNAL_COMMAND_JUSTIFYRIGHT = "JustifyRight";
        private const string INTERNAL_COMMAND_UNDERLINE = "Underline";
        private const string INTERNAL_COMMAND_ITALIC = "Italic";
        private const string INTERNAL_COMMAND_BOLD = "Bold";
        private const string INTERNAL_COMMAND_BACKCOLOR = "BackColor";
        private const string INTERNAL_COMMAND_FORECOLOR = "ForeColor";
        private const string INTERNAL_COMMAND_STRIKETHROUGH = "StrikeThrough";
        private const string INTERNAL_COMMAND_CREATELINK = "CreateLink";
        private const string INTERNAL_COMMAND_UNLINK = "Unlink";
        private const string INTERNAL_COMMAND_INSERTTABLE = "InsertTable";
        private const string INTERNAL_COMMAND_TABLEPROPERTIES = "TableModify";
        private const string INTERNAL_COMMAND_TABLEPROPERTIES_CELLWIDTH = "Resetcolumn ";
        private const string INTERNAL_COMMAND_TABLEINSERTROW = "TableInsertRow";
        private const string INTERNAL_COMMAND_TABLEDELETEROW = "TableDeleteRow";
        private const string INTERNAL_COMMAND_INSERTIMAGE = "InsertImage";
        private const string INTERNAL_COMMAND_INSERTHORIZONTALRULE = "InsertHorizontalRule";
        private const string INTERNAL_COMMAND_OUTDENT = "Outdent";
        private const string INTERNAL_COMMAND_INDENT = "Indent";
        private const string INTERNAL_COMMAND_INSERTUNORDEREDLIST = "InsertUnorderedList";
        private const string INTERNAL_COMMAND_INSERTORDEREDLIST = "InsertOrderedList";
        private const string INTERNAL_COMMAND_SUPERSCRIPT = "Superscript";
        private const string INTERNAL_COMMAND_SUBSCRIPT = "Subscript";
        private const string INTERNAL_COMMAND_SELECTALL = "SelectAll";

        private const string INTERNAL_COMMAND_INSERTDATE = "InsertDate";
        private const string INTERNAL_COMMAND_INSERTTIME = "InsertTime";
        private const string INTERNAL_COMMAND_CLEARWORD = "ClearWord";
        private const string INTERNAL_COMMAND_AUTOLAYOUT = "AutoLayout";
        private const string INTERNAL_COMMAND_ABOUT = "About";

        // browser html constan expressions
        private const string EMPTY_SPACE = @"&nbsp;";
        private const string EMPTY_URL = @"";
        private const string BLANK_HTML_PAGE = "about:blank";
        private const string TARGET_WINDOW_NEW = "_BLANK";
        private const string TARGET_WINDOW_SAME = "_SELF";

        // constants for displaying the HTML dialog
        private const string HTML_TITLE_EDIT = "Edit Html";
        private const string HTML_TITLE_VIEW = "View Html";
        private const string PASTE_TITLE_HTML = "Enter Html";
        private const string PASTE_TITLE_TEXT = "Enter Text";
        private const string HTML_TITLE_OPENFILE = "Open Html File";
        private const string HTML_TITLE_SAVEFILE = "Save Html File";
        private const string HTML_FILTER = "Html files (*.html,*.htm)|*.html;*htm|All files (*.*)|*.*";
        private const string HTML_EXTENSION = "html";
        private const string CONTENT_EDITABLE_INHERIT = "inherit";
        private const string DEFAULT_HTML_TEXT = "";

        // constants for regular expression work
        // BODY_INNER_TEXT_PARSE = @"(<)/*\w*/*(>)";
        // HREF_TEST_EXPRESSION = @"(http|ftp|https):\/\/[\w]+(.[\w]+)([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?";
        // BODY_PARSE_EXPRESSION = @"(?<preBody>.*)(?<bodyOpen><body.*?>)(?<innerBody>.*)(?<bodyClose></body>)(?<afterBody>.*)";
        private const string HREF_TEST_EXPRESSION = @"mailto\:|(news|(ht|f)tp(s?))\:\/\/[\w]+(.[\w]+)([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?";
        private const string BODY_PARSE_PRE_EXPRESSION = @"(<body).*?(</body)";
        private const string BODY_PARSE_EXPRESSION = @"(?<bodyOpen>(<body).*?>)(?<innerBody>.*?)(?<bodyClose>(</body\s*>))";
        private const string BODY_DEFAULT_TAG = @"<Body></Body>";
        private const string BODY_TAG_PARSE_MATCH = @"${bodyOpen}${bodyClose}";
        private const string BODY_INNER_PARSE_MATCH = @"${innerBody}";
        private const string CONTENTTYPE_PARSE_EXPRESSION = @"^(?<mainType>\w+)(\/?)(?<subType>\w*)((\s*;\s*charset=)?)(?<charSet>.*)";
        private const string CONTENTTYPE_PARSE_MAINTYPE = @"${mainType}";
        private const string CONTENTTYPE_PARSE_SUBTYPE = @"${subType}";
        private const string CONTENTTYPE_PARSE_CHARSET = @"${charSet}";

        #endregion

        # region Initialization Code

        // browser constants and commands
        private object EMPTY_PARAMETER;

        // acceptable formatting commands
        // in case order to enable binary search
        private readonly string[] formatCommands = new String[] { "Formatted", "Heading 1", "Heading 2", "Heading 3", "Heading 4", "Heading 5", "Normal" };

        // document and body elements
        private mshtmlDocument document;
        private mshtmlBody body;
        private mshtmlStyleSheet stylesheet;
        private mshtmlScriptElement script;
        private volatile bool loading = false;
        private volatile bool codeNavigate = false;
        private volatile bool rebaseUrlsNeeded = false;

        // default values used to reset values
        private Color _defaultBodyBackColor;
        private Color _defaultBodyForeColor;
        private Color _defaultBackColor;
        //private HtmlFontProperty _defaultFont;

        // internal property values
        private bool _readOnly;
        private bool _toolbarVisible;
        private DockStyle _toolbarDock;
        private string _bodyText;
        private string _bodyHtml;
        private string _bodyUrl;

        // internal body property values
        private Color _bodyBackColor;
        private Color _bodyForeColor;
        //private HtmlFontProperty _bodyFont;
        private int[] _customColors;
        private string _imageDirectory;
        private string _htmlDirectory;
        // private NavigateActionOption _navigateWindow;
        //private DisplayScrollBarOption _scrollBars;
        private string _baseHref;
        private bool _autoWordWrap;
        private byte _borderSize;

        // find and replace internal text range
        private mshtmlTextRange _findRange;





        /// <summary>
        /// Defines all the body attributes once a document has been loaded
        /// </summary>
        private void DefineBodyAttributes()
        {
            // define the body colors based on the new body html
            if (body.bgColor == null)
            {
                _bodyBackColor = _defaultBodyBackColor;
            }
            else
            {
                _bodyBackColor = ColorTranslator.FromHtml((string)body.bgColor);
            }
            if (body.text == null)
            {
                _bodyForeColor = _defaultBodyForeColor;
            }
            else
            {
                _bodyForeColor = ColorTranslator.FromHtml((string)body.text);
            }

            // define the font object based on current font of new document
            // deafult used unless a style on the body modifies the value
            mshtmlStyle bodyStyle = body.style;
            if (bodyStyle != null)
            {
                // string fontName = _bodyFont.Name;
                // HtmlFontSize fontSize = _bodyFont.Size;
                // bool fontBold = _bodyFont.Bold;
                // bool fontItalic = _bodyFont.Italic;
                //bool fontUnderline = _bodyFont.Underline;
                // define the font name if defined in the style
                //if (bodyStyle.fontFamily != null) fontName = bodyStyle.fontFamily;
                // if (bodyStyle.fontSize != null) fontSize = HtmlFontConversion.StyleSizeToHtml(bodyStyle.fontSize.ToString());
                // if (bodyStyle.fontWeight != null) fontBold = HtmlFontConversion.IsStyleBold(bodyStyle.fontWeight);
                // if (bodyStyle.fontStyle != null) fontItalic = HtmlFontConversion.IsStyleItalic(bodyStyle.fontStyle);
                //fontUnderline = bodyStyle.textDecorationUnderline;
                // define the new font object and set the property
                // _bodyFont = new HtmlFontProperty(fontName, fontSize, fontBold, fontItalic, fontUnderline);
                //this.BodyFont = _bodyFont;
            }

            // define the content based on the current value
            // this.ReadOnly = _readOnly;
            //this.ScrollBars = _scrollBars;
            //this.AutoWordWrap = _autoWordWrap;

        } //DefineBodyAttributes

        #endregion
        //public IHTMLDocument2 doc;
        public mshtmlDocument doc;
        private bool updatingFontName = false;
        private bool updatingFontSize = false;
        private bool setup = false;
        private bool init_timer = false;
        public string language = "hi";

        public delegate void TickDelegate();

        public class EnterKeyEventArgs : EventArgs
        {
            private bool _cancel = false;

            public bool Cancel
            {
                get { return _cancel; }
                set { _cancel = value; }
            }

        }

        public event TickDelegate Tick;

        public event WebBrowserNavigatedEventHandler Navigated;

        public event EventHandler<EnterKeyEventArgs> EnterKeyEvent;

        public Editor()
        {
#if TRIAL
            var form = new SplashForm();
            form.ShowDialog();
#endif
            Load += new EventHandler(Editor_Load);
            InitializeComponent();
            SetupEvents();
            SetupTimer();
            SetupBrowser();
            SetupFontComboBox();
            SetupFontSizeComboBox();
            tsbBold.CheckedChanged += delegate
            {
                if (BoldChanged != null)
                    BoldChanged();
            };
            tsbItalic.CheckedChanged += delegate
            {
                if (ItalicChanged != null)
                    ItalicChanged();
            };
            tsbUnderline.CheckedChanged += delegate
            {
                if (UnderlineChanged != null)
                    UnderlineChanged();
            };
            tsbInsertOrderedList.CheckedChanged += delegate
            {
                if (OrderedListChanged != null)
                    OrderedListChanged();
            };
            tsbInsertUnorderedList.CheckedChanged += delegate
            {
                if (UnorderedListChanged != null)
                    UnorderedListChanged();
            };
            tsbJustifyLeft.CheckedChanged += delegate
            {
                if (JustifyLeftChanged != null)
                    JustifyLeftChanged();
            };
            tsbJustifyCenter.CheckedChanged += delegate
            {
                if (JustifyCenterChanged != null)
                    JustifyCenterChanged();
            };
            tsbJustifyRight.CheckedChanged += delegate
            {
                if (JustifyRightChanged != null)
                    JustifyRightChanged();
            };
            tsbJustifyFull.CheckedChanged += delegate
            {
                if (JustifyFullChanged != null)
                    JustifyFullChanged();
            };
            linkButton.CheckedChanged += delegate
            {
                if (IsLinkChanged != null)
                    IsLinkChanged();
            };
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            timer.Start();
            InitUi();

        }

        private void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
            ParentForm.FormClosed -= new FormClosedEventHandler(ParentForm_FormClosed);
        }

        /// <summary>
        /// Setup navigation and focus event handlers.
        /// </summary>
        private void SetupEvents()
        {
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            webBrowser1.GotFocus += new EventHandler(webBrowser1_GotFocus);
            if (webBrowser1.Version.Major >= 9)
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Write(webBrowser1.DocumentText);
            doc.designMode = "On";
            webBrowser1.Document.Body.SetAttribute("contentEditable", "true");

        }



        /// <summary>
        /// When this control receives focus, it transfers focus to the 
        /// document body.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void webBrowser1_GotFocus(object sender, EventArgs e)
        {
            SuperFocus();
        }

        /// <summary>
        /// This is called when the initial html/body framework is set up, 
        /// or when document.DocumentText is set.  At this point, the 
        /// document is editable.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">navigation args</param>
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetBackgroundColor(BackColor);
            if (Navigated != null)
            {
                Navigated(this, e);
            }
        }

        /// <summary>
        /// Setup timer with 200ms interval
        /// </summary>
        private void SetupTimer()
        {
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
        }

        /// <summary>
        /// Add document body, turn on design mode on the whole document, 
        /// and overred the context menu
        /// </summary>
        private void SetupBrowser()
        {
            webBrowser1.DocumentText = "<html lang='" + language + "'><body></body></html>";
            doc =
                webBrowser1.Document.DomDocument as mshtmlDocument;
            doc.designMode = "On";
            webBrowser1.Document.ContextMenuShowing +=
                new HtmlElementEventHandler(Document_ContextMenuShowing);
        }

        /// <summary>
        /// Set the focus on the document body.  
        /// </summary>
        private void SuperFocus()
        {

            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.Focus();
        }

        /// <summary>
        /// Get/Set the background color of the editor.
        /// Note that if this is called before the document is rendered and 
        /// complete, the navigated event handler will set the body's 
        /// background color based on the state of BackColor.
        /// </summary>
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (ReadyState == ReadyState.Complete)
                {
                    SetBackgroundColor(value);
                }
            }
        }

        /// <summary>
        /// Set the background color of the body by setting it's CSS style
        /// </summary>
        /// <param name="value">the color to use for the background</param>
        private void SetBackgroundColor(Color value)
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.Style =
                    string.Format("background-color: {0}", value.Name);
        }

        /// <summary>
        /// Clear the contents of the document, leaving the body intact.
        /// </summary>
        public void Clear()
        {
            if (webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.InnerHtml = "";
        }

        /// <summary>
        /// Get the web browser component's document
        /// </summary>
        public HtmlDocument Document
        {
            get { return webBrowser1.Document; }
        }

        /// <summary>
        /// Document text should be used to load/save the entire document, 
        /// including html and body start/end tags.
        /// </summary>
        [Browsable(false)]
        public string DocumentText
        {
            get
            {
                string html = webBrowser1.DocumentText;
                if (html != null)
                {
                    html = ReplaceFileSystemImages(html);
                }
                return html;
            }
            set
            {
                webBrowser1.DocumentText = value;
            }
        }

        /// <summary>
        /// Get the html document title from document.
        /// </summary>
        [Browsable(false)]
        public string DocumentTitle
        {
            get
            {
                return webBrowser1.DocumentTitle;
            }
        }

        /// <summary>
        /// Get/Set the contents of the document Body, in html.
        /// </summary>
        [Browsable(false)]
        public string BodyHtml
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    string html = webBrowser1.Document.Body.InnerHtml;
                    if (html != null)
                    {
                        html = ReplaceFileSystemImages(html);
                    }
                    return html;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerHtml = value;
            }
        }

        public MailMessage ToMailMessage()
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
            {
                string html = webBrowser1.Document.Body.InnerHtml;
                if (html != null)
                {
                    return LinkImages(html);
                }
                var msg = new MailMessage();
                msg.IsBodyHtml = true;
                return msg;
            }
            else
            {
                var msg = new MailMessage();
                msg.IsBodyHtml = true;
                msg.Body = string.Empty;
                return msg;
            }
        }

        private MailMessage LinkImages(string html)
        {
            var msg = new MailMessage();
            msg.IsBodyHtml = true;
            var matches = Regex.Matches(html, @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            var img_list = new List<LinkedResource>();
            var cid = 1;
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        var res = new LinkedResource(src);
                        res.ContentId = string.Format("img{0}.{1}", cid++, ext);
                        res.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        res.ContentType.MediaType = string.Format("image/{0}", ext);
                        res.ContentType.Name = res.ContentId;
                        img_list.Add(res);
                        src = string.Format("'cid:{0}'", res.ContentId);
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            var view = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);
            foreach (var img in img_list)
            {
                view.LinkedResources.Add(img);
            }
            msg.AlternateViews.Add(view);
            return msg;
        }

        private string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(html, @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        src = string.Format("'data:image/{0};base64,{1}'", ext, Convert.ToBase64String(File.ReadAllBytes(src)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            return html;
        }

        /// <summary>
        /// Get/Set the documents body as text.
        /// </summary>
        [Browsable(false)]
        public string BodyText
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerText;
                }
                else
                    return string.Empty;
            }
            set
            {
                Document.OpenNew(false);
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerText = HttpUtility.HtmlEncode(value);
            }
        }

        [Browsable(false)]
        public string Html
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerHtml;
                }
                else
                    return string.Empty;
            }
            set
            {
                Document.OpenNew(true);
                IHTMLDocument2 dom = Document.DomDocument as IHTMLDocument2;
                try
                {
                    if (value == null)
                        dom.clear();
                    else
                        dom.write(value);
                }
                finally
                {
                    dom.close();
                }
            }
        }

        /// <summary>
        /// Determine the status of the Undo command in the document editor.
        /// </summary>
        /// <returns>whether or not an undo operation is currently valid</returns>
        public bool CanUndo()
        {
            return doc.queryCommandEnabled("Undo");
        }

        /// <summary>
        /// Determine the status of the Redo command in the document editor.
        /// </summary>
        /// <returns>whether or not a redo operation is currently valid</returns>
        public bool CanRedo()
        {
            return doc.queryCommandEnabled("Redo");
        }

        /// <summary>
        /// Determine the status of the Cut command in the document editor.
        /// </summary>
        /// <returns>whether or not a cut operation is currently valid</returns>
        public bool CanCut()
        {
            return doc.queryCommandEnabled("Cut");
        }

        /// <summary>
        /// Determine the status of the Copy command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanCopy()
        {
            return doc.queryCommandEnabled("Copy");
        }

        /// <summary>
        /// Determine the status of the Paste command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanPaste()
        {
            return doc.queryCommandEnabled("Paste");
        }

        /// <summary>
        /// Determine the status of the Delete command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanDelete()
        {
            return doc.queryCommandEnabled("Delete");
        }

        /// <summary>
        /// Determine whether the current block is left justified.
        /// </summary>
        /// <returns>true if left justified, otherwise false</returns>
        public bool IsJustifyLeft()
        {
            return doc.queryCommandState("JustifyLeft");
        }

        /// <summary>
        /// Determine whether the current block is right justified.
        /// </summary>
        /// <returns>true if right justified, otherwise false</returns>
        public bool IsJustifyRight()
        {
            return doc.queryCommandState("JustifyRight");
        }

        /// <summary>
        /// Determine whether the current block is center justified.
        /// </summary>
        /// <returns>true if center justified, false otherwise</returns>
        public bool IsJustifyCenter()
        {
            return doc.queryCommandState("JustifyCenter");
        }

        /// <summary>
        /// Determine whether the current block is full justified.
        /// </summary>
        /// <returns>true if full justified, false otherwise</returns>
        public bool IsJustifyFull()
        {
            return doc.queryCommandState("JustifyFull");
        }

        /// <summary>
        /// Determine whether the current selection is in Bold mode.
        /// </summary>
        /// <returns>whether or not the current selection is Bold</returns>
        public bool IsBold()
        {
            return doc.queryCommandState("Bold");
        }

        /// <summary>
        /// Determine whether the current selection is in Italic mode.
        /// </summary>
        /// <returns>whether or not the current selection is Italicized</returns>
        public bool IsItalic()
        {
            return doc.queryCommandState("Italic");
        }

        /// <summary>
        /// Determine whether the current selection is in Underline mode.
        /// </summary>
        /// <returns>whether or not the current selection is Underlined</returns>
        public bool IsUnderline()
        {
            return doc.queryCommandState("Underline");
        }

        /// <summary>
        /// Determine whether the current paragraph is an ordered list.
        /// </summary>
        /// <returns>true if current paragraph is ordered, false otherwise</returns>
        public bool IsOrderedList()
        {
            return doc.queryCommandState("InsertOrderedList");
        }

        /// <summary>
        /// Determine whether the current paragraph is an unordered list.
        /// </summary>
        /// <returns>true if current paragraph is ordered, false otherwise</returns>
        public bool IsUnorderedList()
        {
            return doc.queryCommandState("InsertUnorderedList");
        }

        /// <summary>
        /// Called when the editor context menu should be displayed.
        /// The return value of the event is set to false to disable the 
        /// default context menu.  A custom context menu (contextMenuStrip1) is 
        /// shown instead.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            tsmiCut.Enabled = CanCut();
            tsmiCopy.Enabled = CanCopy();
            tsmiPaste.Enabled = CanPaste();
            tsmiDelete.Enabled = CanDelete();
            // if in readonly mode display the standard context menu
            // otherwise display the editing context menu
            if (!_readOnly)
            {
                // should disable inappropriate commands
                tsmiTable.Visible = IsParentTable();

                // display the text processing context menu
                cmsHtml.Show(this, e.MousePosition);

                // cancel the standard menu and event bubbling
                e.BubbleEvent = false;
                e.ReturnValue = false;
            }

            //cmsHtml.Show(this, e.ClientMousePosition);
        }
        /// <summary>
        /// Method to determine if the insertion point or selection is a table
        /// </summary>
        private bool IsParentTable()
        {
            // see if a table selected or insertion point inside a table
            mshtmlTable htmlTable = GetTableElement();

            // process according to table being defined
            if (htmlTable.IsNull())
            {
                return false;
            }
            return true;
        } //IsParentTable
        /// <summary>
        /// Populate the font size combobox.
        /// Add text changed and key press handlers to handle input and update 
        /// the editor selection font size.
        /// </summary>
        private void SetupFontSizeComboBox()
        {
            for (int x = 1; x <= 7; x++)
            {
                fontSizeComboBox.Items.Add(x.ToString());
            }
            fontSizeComboBox.TextChanged += new EventHandler(fontSizeComboBox_TextChanged);
            fontSizeComboBox.KeyPress += new KeyPressEventHandler(fontSizeComboBox_KeyPress);
        }

        /// <summary>
        /// Called when a key is pressed on the font size combo box.
        /// The font size in the boxy box is set to the key press value.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    fontSizeComboBox.Text = e.KeyChar.ToString();
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Set editor's current selection to the value of the font size combo box.
        /// Ignore if the timer is currently updating the font size to synchronize 
        /// the font size combo box with the editor's current selection.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontSize) return;
            switch (fontSizeComboBox.Text.Trim())
            {
                case "1":
                    FontSize = FontSize.One;
                    break;
                case "2":
                    FontSize = FontSize.Two;
                    break;
                case "3":
                    FontSize = FontSize.Three;
                    break;
                case "4":
                    FontSize = FontSize.Four;
                    break;
                case "5":
                    FontSize = FontSize.Five;
                    break;
                case "6":
                    FontSize = FontSize.Six;
                    break;
                case "7":
                    FontSize = FontSize.Seven;
                    break;
                default:
                    FontSize = FontSize.Seven;
                    break;
            }
        }

        /// <summary>
        /// Populate the font combo box and autocomplete handlers.
        /// Add a text changed handler to the font combo box to handle new font selections.
        /// </summary>
        private void SetupFontComboBox()
        {
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontComboBox.Items.Add(fam.Name);
                ac.Add(fam.Name);
            }
            fontComboBox.Leave += new EventHandler(fontComboBox_TextChanged);
            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            fontComboBox.AutoCompleteCustomSource = ac;
        }

        /// <summary>
        /// Called when the font combo box has changed.
        /// Ignores the event when the timer is updating the font combo Box 
        /// to synchronize the editor selection with the font combo box.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        public void fontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontName) return;
            FontFamily ff;
            try
            {
                ff = new FontFamily(fontComboBox.Text);
            }
            catch (Exception)
            {
                updatingFontName = true;
                fontComboBox.Text = FontName.GetName(0);
                updatingFontName = false;
                return;
            }
            FontName = ff;
        }

        private void UpdateImageSizes()
        {
            foreach (HTMLImg image in doc.images)
            {
                if (image != null)
                {
                    if (image.height != image.style.pixelHeight && image.style.pixelHeight != 0)
                        image.height = image.style.pixelHeight;
                    if (image.width != image.style.pixelWidth && image.style.pixelWidth != 0)
                        image.width = image.style.pixelWidth;
                }
            }
        }

        public event MethodInvoker BoldChanged;
        public event MethodInvoker ItalicChanged;
        public event MethodInvoker UnderlineChanged;
        public event MethodInvoker OrderedListChanged;
        public event MethodInvoker UnorderedListChanged;
        public event MethodInvoker JustifyLeftChanged;
        public event MethodInvoker JustifyCenterChanged;
        public event MethodInvoker JustifyRightChanged;
        public event MethodInvoker JustifyFullChanged;
        public event MethodInvoker IsLinkChanged;
        public event MethodInvoker HtmlFontChanged;
        public event MethodInvoker HtmlFontSizeChanged;

        private DateTime lastSplash = DateTime.Now;

        /// <summary>
        /// Called when the timer fires to synchronize the format buttons 
        /// with the text editor current selection.
        /// SetupKeyListener if necessary.
        /// Set bold, italic, underline and link buttons as based on editor state.
        /// Synchronize the font combo box and the font size combo box.
        /// Finally, fire the Tick event to allow external components to synchronize 
        /// their state with the editor.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!init_timer)
            {
                ParentForm.FormClosed += new FormClosedEventHandler(ParentForm_FormClosed);
                init_timer = true;
                lastSplash = DateTime.Now;
            }

            // don't process until browser is in ready state.
            if (ReadyState != ReadyState.Complete)
                return;

#if TRIAL
            if (DateTime.Now.Subtract(lastSplash).TotalMinutes > 10)
            {
                lastSplash = DateTime.Now;
                var dlg = new SplashForm();
                dlg.ShowDialog();
            }
#endif
            SetupKeyListener();
            tsbBold.Checked = IsBold();
            tsbItalic.Checked = IsItalic();
            tsbUnderline.Checked = IsUnderline();
            tsbInsertOrderedList.Checked = IsOrderedList();
            tsbInsertUnorderedList.Checked = IsUnorderedList();
            tsbJustifyLeft.Checked = IsJustifyLeft();
            tsbJustifyCenter.Checked = IsJustifyCenter();
            tsbJustifyRight.Checked = IsJustifyRight();
            tsbJustifyFull.Checked = IsJustifyFull();

            linkButton.Enabled = CanInsertLink();

            UpdateFontComboBox();
            UpdateFontSizeComboBox();
            UpdateImageSizes();

            if (Tick != null)
                Tick();
        }

        /// <summary>
        /// Update the font size combo box.
        /// Sets a flag to indicate that the combo box is updating, and should 
        /// not update the editor's selection.
        /// </summary>
        private void UpdateFontSizeComboBox()
        {
            if (!fontSizeComboBox.Focused)
            {
                int foo;
                switch (FontSize)
                {
                    case FontSize.One:
                        foo = 1;
                        break;
                    case FontSize.Two:
                        foo = 2;
                        break;
                    case FontSize.Three:
                        foo = 3;
                        break;
                    case FontSize.Four:
                        foo = 4;
                        break;
                    case FontSize.Five:
                        foo = 5;
                        break;
                    case FontSize.Six:
                        foo = 6;
                        break;
                    case FontSize.Seven:
                        foo = 7;
                        break;
                    case FontSize.NA:
                        foo = 0;
                        break;
                    default:
                        foo = 7;
                        break;
                }
                string fontsize = Convert.ToString(foo);
                if (fontsize != fontSizeComboBox.Text)
                {
                    updatingFontSize = true;
                    fontSizeComboBox.Text = fontsize;
                    if (HtmlFontSizeChanged != null)
                        HtmlFontSizeChanged();
                    updatingFontSize = false;
                }
            }
        }

        /// <summary>
        /// Update the font combo box.
        /// Sets a flag to indicate that the combo box is updating, and should 
        /// not update the editor's selection.
        /// </summary>
        private void UpdateFontComboBox()
        {
            if (!fontComboBox.Focused)
            {
                FontFamily fam = FontName;
                if (fam != null)
                {
                    string fontname = fam.Name;
                    if (fontname != fontComboBox.Text)
                    {
                        updatingFontName = true;
                        fontComboBox.Text = fontname;
                        if (HtmlFontChanged != null)
                            HtmlFontChanged();
                        updatingFontName = false;
                    }
                }
            }
        }

        public Color BodyBackgroundColor
        {
            get
            {
                if (doc.body != null && doc.body.style != null && doc.body.style.backgroundColor != null)
                    return ConvertToColor(doc.body.style.backgroundColor.ToString());
                return Color.White;
            }
            set
            {
                if (ReadyState == ReadyState.Complete)
                {
                    if (doc.body != null && doc.body.style != null)
                    {
                        string colorstr =
                            string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                        doc.body.style.backgroundColor = colorstr;
                    }
                }
            }
        }

        /// <summary>
        /// Set up a key listener on the body once.
        /// The key listener checks for specific key strokes and takes 
        /// special action in certain cases.
        /// </summary>
        private void SetupKeyListener()
        {
            if (!setup)
            {
                webBrowser1.Document.Body.KeyDown += new HtmlElementEventHandler(Body_KeyDown);
                setup = true;
            }
        }

        /// <summary>
        /// If the user hits the enter key, and event will fire (EnterKeyEvent), 
        /// and the consumers of this event can cancel the projecessing of the 
        /// enter key by cancelling the event.
        /// This is useful if your application would like to take some action 
        /// when the enter key is pressed, such as a submission to a web service.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Body_KeyDown(object sender, HtmlElementEventArgs e)
        {
            if (e.KeyPressedCode == 13 && !e.ShiftKeyPressed)
            {
                // handle enter code cancellation
                bool cancel = false;
                if (EnterKeyEvent != null)
                {
                    EnterKeyEventArgs args = new EnterKeyEventArgs();
                    EnterKeyEvent(this, args);
                    cancel = args.Cancel;
                }
                e.ReturnValue = !cancel;
            }
        }

        /// <summary>
        /// Embed a break at the current selection.
        /// This is a placeholder for future functionality.
        /// </summary>
        public void EmbedBr()
        {
            IHTMLTxtRange range =
                doc.selection.createRange() as IHTMLTxtRange;
            range.pasteHTML("<br/>");
            range.collapse(false);
            range.select();
        }

        /// <summary>
        /// Paste the clipboard text into the current selection.
        /// This is a placeholder for future functionality.
        /// </summary>
        private void SuperPaste()
        {
            if (Clipboard.ContainsText())
            {
                IHTMLTxtRange range =
                    doc.selection.createRange() as IHTMLTxtRange;
                range.pasteHTML(Clipboard.GetText(TextDataFormat.Text));
                range.collapse(false);
                range.select();
            }
        }

        /// <summary>
        /// Print the current document
        /// </summary>
        public void Print()
        {
            webBrowser1.Document.ExecCommand("Print", true, null);
        }

        /// <summary>
        /// Insert a paragraph break
        /// </summary>
        public void InsertParagraph()
        {
            webBrowser1.Document.ExecCommand("InsertParagraph", false, null);
        }

        /// <summary>
        /// Insert a horizontal rule
        /// </summary>
        public void InsertBreak()
        {
            webBrowser1.Document.ExecCommand("InsertHorizontalRule", false, null);
        }

        /// <summary>
        /// Select all text in the document.
        /// </summary>
        public void SelectAll()
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
        }

        /// <summary>
        /// Undo the last operation
        /// </summary>
        public void Undo()
        {
            webBrowser1.Document.ExecCommand("Undo", false, null);
        }

        /// <summary>
        /// Redo based on the last Undo
        /// </summary>
        public void Redo()
        {
            webBrowser1.Document.ExecCommand("Redo", false, null);
        }

        /// <summary>
        /// Cut the current selection and place it in the clipboard.
        /// </summary>
        public void Cut()
        {
            webBrowser1.Document.ExecCommand("Cut", false, null);
        }

        /// <summary>
        /// Paste the contents of the clipboard into the current selection.
        /// </summary>
        public void Paste()
        {
            webBrowser1.Document.ExecCommand("Paste", false, null);
        }

        /// <summary>
        /// Copy the current selection into the clipboard.
        /// </summary>
        public void Copy()
        {
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }

        /// <summary>
        /// Toggle the ordered list property for the current paragraph.
        /// </summary>
        public void OrderedList()
        {
            webBrowser1.Document.ExecCommand("InsertOrderedList", false, null);
        }

        /// <summary>
        /// Toggle the unordered list property for the current paragraph.
        /// </summary>
        public void UnorderedList()
        {
            webBrowser1.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        /// <summary>
        /// Toggle the left justify property for the currnet block.
        /// </summary>
        public void JustifyLeft()
        {
            webBrowser1.Document.ExecCommand("JustifyLeft", false, null);
        }

        /// <summary>
        /// Toggle the right justify property for the current block.
        /// </summary>
        public void JustifyRight()
        {
            webBrowser1.Document.ExecCommand("JustifyRight", false, null);
        }

        /// <summary>
        /// Toggle the center justify property for the current block.
        /// </summary>
        public void JustifyCenter()
        {
            webBrowser1.Document.ExecCommand("JustifyCenter", false, null);
        }

        /// <summary>
        /// Toggle the full justify property for the current block.
        /// </summary>
        public void JustifyFull()
        {
            webBrowser1.Document.ExecCommand("JustifyFull", false, null);
        }

        /// <summary>
        /// Toggle bold formatting on the current selection.
        /// </summary>
        public void Bold()
        {
            webBrowser1.Document.ExecCommand("Bold", false, null);
        }

        /// <summary>
        /// Toggle italic formatting on the current selection.
        /// </summary>
        public void Italic()
        {
            webBrowser1.Document.ExecCommand("Italic", false, null);
        }

        /// <summary>
        /// Toggle underline formatting on the current selection.
        /// </summary>
        public void Underline()
        {
            webBrowser1.Document.ExecCommand("Underline", false, null);
        }

        /// <summary>
        /// Delete the current selection.
        /// </summary>
        public void Delete()
        {
            webBrowser1.Document.ExecCommand("Delete", false, null);
        }

        /// <summary>
        /// Insert an imange.
        /// </summary>
        public void InsertImage()
        {
            webBrowser1.Document.ExecCommand("InsertImage", true, null);

        }

        /// <summary>
        /// Indent the current paragraph.
        /// </summary>
        public void Indent()
        {
            webBrowser1.Document.ExecCommand("Indent", false, null);
        }

        /// <summary>
        /// Outdent the current paragraph.
        /// </summary>
        public void Outdent()
        {
            webBrowser1.Document.ExecCommand("Outdent", false, null);
        }

        /// <summary>
        /// Insert a link at the current selection.
        /// </summary>
        /// <param name="url">The link url</param>
        public void InsertLink(string url)
        {
            webBrowser1.Document.ExecCommand("CreateLink", false, url);
        }
        /// <summary>
        /// Insert Table 
        /// </summary>
        private void insertHtml()
        {
            mshtmlTable table = GetFirstControl() as mshtmlTable;
            ProcessTablePrompt(table);
        }

        /// <summary>
        /// Method to present to the user the table properties dialog
        /// Uses all the default properties for the table based on an insert operation
        /// </summary>
        private void ProcessTablePrompt(mshtmlTable table)
        {
            using (var dialog = new TablePropertyForm())
            {
                // define the base set of table properties
                HtmlTableProperty tableProperties = GetTableProperties(table);

                // set the dialog properties
                dialog.TableProperties = tableProperties;
                DefineDialogProperties(dialog);
                // based on the user interaction perform the neccessary action
                if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    tableProperties = dialog.TableProperties;
                    if (table.IsNull()) TableInsert(tableProperties);
                    else ProcessTable(table, tableProperties);
                }
            }



        } // ProcessTablePrompt
        /// <summary>
        /// Method to create a table class
        /// Insert method then works on this table
        /// </summary>
        public void TableInsert(HtmlTableProperty tableProperties)
        {
            // call the private insert table method with a null table entry
            ProcessTable(null, tableProperties);

        } //TableInsert
        /// <summary>
        /// Method to ensure dialog resembles the user form characteristics
        /// </summary>
        private void DefineDialogProperties(Form dialog)
        {
            // set ambient control properties
            if (!ParentForm.IsNull())
            {
                dialog.Font = ParentForm.Font;
                dialog.ForeColor = ParentForm.ForeColor;
                dialog.BackColor = ParentForm.BackColor;
                dialog.Cursor = ParentForm.Cursor;
                dialog.RightToLeft = ParentForm.RightToLeft;
            }

            // define location and control style as system
            dialog.StartPosition = FormStartPosition.CenterParent;

        } //DefineDialogProperties
        /// <summary>
        /// Given an Html Table Element determines the table properties
        /// Returns the properties as an HtmlTableProperty class
        /// </summary>
        private HtmlTableProperty GetTableProperties(mshtmlTable table)
        {
            // define a set of base table properties
            var tableProperties = new HtmlTableProperty(true);

            // if user has selected a table extract those properties
            if (!table.IsNull())
            {
                try
                {
                    // have a table so extract the properties
                    mshtmlTableCaption caption = table.caption;
                    // if have a caption persist the values
                    if (!caption.IsNull())
                    {
                        tableProperties.CaptionText = ((mshtmlElement)table.caption).innerText;
                        if (!caption.align.IsNull()) tableProperties.CaptionAlignment = (HorizontalAlignOption)typeof(HorizontalAlignOption).TryParseEnum(caption.align, HorizontalAlignOption.Default);
                        if (!caption.vAlign.IsNull()) tableProperties.CaptionLocation = (VerticalAlignOption)typeof(VerticalAlignOption).TryParseEnum(caption.vAlign, VerticalAlignOption.Default);
                    }
                    // look at the table properties
                    if (!GeneralUtil.IsNull(table.border)) tableProperties.BorderSize = GeneralUtil.TryParseByte(table.border.ToString(), tableProperties.BorderSize);
                    if (!table.align.IsNull()) tableProperties.TableAlignment = (HorizontalAlignOption)typeof(HorizontalAlignOption).TryParseEnum(table.align, HorizontalAlignOption.Default);
                    // define the table rows and columns
                    int rows = Math.Min(table.rows.length, Byte.MaxValue);
                    int cols = Math.Min(table.cols, Byte.MaxValue);
                    if (cols == 0 && rows > 0)
                    {
                        // cols value not set to get the maxiumn number of cells in the rows
                        foreach (mshtmlTableRow tableRow in table.rows)
                        {
                            cols = Math.Max(cols, tableRow.cells.length);
                        }
                    }
                    tableProperties.TableRows = (byte)Math.Min(rows, byte.MaxValue);
                    tableProperties.TableColumns = (byte)Math.Min(cols, byte.MaxValue);
                    // define the remaining table properties
                    if (!GeneralUtil.IsNull(table.cellPadding)) tableProperties.CellPadding = GeneralUtil.TryParseByte(table.cellPadding.ToString(), tableProperties.CellPadding);
                    if (!GeneralUtil.IsNull(table.cellSpacing)) tableProperties.CellSpacing = GeneralUtil.TryParseByte(table.cellSpacing.ToString(), tableProperties.CellSpacing);
                    if (!GeneralUtil.IsNull(table.width))
                    {
                        string tableWidth = table.width.ToString();
                        if (tableWidth.TrimEnd(null).EndsWith("%"))
                        {
                            tableProperties.TableWidth = tableWidth.Remove(tableWidth.LastIndexOf("%", StringComparison.Ordinal), 1).TryParseUshort(tableProperties.TableWidth);
                            tableProperties.TableWidthMeasurement = MeasurementOption.Percent;
                        }
                        else
                        {
                            tableProperties.TableWidth = tableWidth.TryParseUshort(tableProperties.TableWidth);
                            tableProperties.TableWidthMeasurement = MeasurementOption.Pixel;
                        }
                    }
                    else
                    {
                        tableProperties.TableWidth = 0;
                        tableProperties.TableWidthMeasurement = MeasurementOption.Pixel;
                    }
                }
                catch (Exception ex)
                {
                    // throw an exception indicating table structure change be determined
                    throw new HtmlEditorException("Unable to determine Html Table properties.", "GetTableProperties", ex);
                }
            }

            // return the table properties
            return tableProperties;

        } //GetTableProperties
        /// <summary>
        /// Method to insert a basic table
        /// Will honour the existing table if passed in
        /// </summary>
        private void ProcessTable(mshtmlTable table, HtmlTableProperty tableProperties)
        {
            try
            {
                // obtain a reference to the body node and indicate table present
                var bodyNode = (mshtmlDomNode)doc.body;
                bool tableCreated = false;

                // ensure a table node has been defined to work with
                if (table.IsNull())
                {
                    // create the table and indicate it was created
                    table = (mshtmlTable)doc.createElement(TABLE_TAG);
                    tableCreated = true;
                }

                // define the table border, width, cell padding and spacing
                table.border = tableProperties.BorderSize;
                //Removed
                // if (tableProperties.TableWidth > 0) 
                //     table.width = (tableProperties.TableWidthMeasurement == MeasurementOption.Pixel) ? string.Format("{0}", tableProperties.TableWidth) : string.Format("{0}%", tableProperties.TableWidth);
                //else table.width = string.Empty;
                table.width = string.Format("{0}", tableProperties.TableWidth);
                table.align = tableProperties.TableAlignment != HorizontalAlignOption.Default ? tableProperties.TableAlignment.ToString().ToLower() : string.Empty;
                table.cellPadding = tableProperties.CellPadding.ToString(CultureInfo.InvariantCulture);
                table.cellSpacing = tableProperties.CellSpacing.ToString(CultureInfo.InvariantCulture);

                // define the given table caption and alignment
                string caption = tableProperties.CaptionText;
                mshtmlTableCaption tableCaption = table.caption;
                if (!caption.IsNullOrEmpty())
                {
                    // ensure table caption correctly defined
                    if (tableCaption.IsNull()) tableCaption = table.createCaption();
                    ((mshtmlElement)tableCaption).innerText = caption;
                    if (tableProperties.CaptionAlignment != HorizontalAlignOption.Default) tableCaption.align = tableProperties.CaptionAlignment.ToString().ToLower();
                    if (tableProperties.CaptionLocation != VerticalAlignOption.Default) tableCaption.vAlign = tableProperties.CaptionLocation.ToString().ToLower();
                }
                else
                {
                    // if no caption specified remove the existing one
                    if (!tableCaption.IsNull())
                    {
                        // prior to deleting the caption the contents must be cleared
                        ((mshtmlElement)tableCaption).innerText = null;
                        table.deleteCaption();
                    }
                }

                // determine the number of rows one has to insert
                int numberRows, numberCols;
                if (tableCreated)
                {
                    numberRows = Math.Max((int)tableProperties.TableRows, 1);
                }
                else
                {
                    numberRows = Math.Max((int)tableProperties.TableRows, 1) - table.rows.length;
                }

                // layout the table structure in terms of rows and columns
                table.cols = tableProperties.TableColumns;
                if (tableCreated)
                {
                    // this section is an optimization based on creating a new table
                    // the section below works but not as efficiently
                    numberCols = Math.Max((int)tableProperties.TableColumns, 1);
                    // insert the appropriate number of rows
                    mshtmlTableRow tableRow;
                    for (int idxRow = 0; idxRow < numberRows; idxRow++)
                    {
                        tableRow = (mshtmlTableRow)table.insertRow();
                        // add the new columns to the end of each row
                        for (int idxCol = 0; idxCol < numberCols; idxCol++)
                        {
                            tableRow.insertCell();
                        }
                    }
                }
                else
                {
                    // if the number of rows is increasing insert the decrepency
                    if (numberRows > 0)
                    {
                        // insert the appropriate number of rows
                        for (int idxRow = 0; idxRow < numberRows; idxRow++)
                        {
                            table.insertRow();
                        }
                    }
                    else
                    {
                        // remove the extra rows from the table
                        for (int idxRow = numberRows; idxRow < 0; idxRow++)
                        {
                            table.deleteRow(table.rows.length - 1);
                        }
                    }
                    // have the rows constructed
                    // now ensure the columns are correctly defined for each row
                    mshtmlElementCollection rows = table.rows;
                    foreach (mshtmlTableRow tableRow in rows)
                    {
                        numberCols = Math.Max((int)tableProperties.TableColumns, 1) - tableRow.cells.length;
                        if (numberCols > 0)
                        {
                            // add the new column to the end of each row
                            for (int idxCol = 0; idxCol < numberCols; idxCol++)
                            {
                                tableRow.insertCell();
                            }
                        }
                        else
                        {
                            // reduce the number of cells in the given row
                            // remove the extra rows from the table
                            for (int idxCol = numberCols; idxCol < 0; idxCol++)
                            {
                                tableRow.deleteCell(tableRow.cells.length - 1);
                            }
                        }
                    }
                }

                // if the table was created then it requires insertion into the DOM
                // otherwise property changes are sufficient
                if (tableCreated)
                {
                    // table processing all complete so insert into the DOM
                    var tableNode = (mshtmlDomNode)table;
                    var tableElement = (mshtmlElement)table;
                    mshtmlTextRange textRange = GetTextRange();
                    // final insert dependant on what user has selected
                    if (!textRange.IsNull())
                    {
                        // text range selected so overwrite with a table
                        try
                        {
                            string selectedText = textRange.text;
                            if (!selectedText.IsNull())
                            {
                                // place selected text into first cell
                                var tableRow = (mshtmlTableRow)table.rows.item(0, null);
                                ((mshtmlElement)tableRow.cells.item(0, null)).innerText = selectedText;
                            }
                            textRange.pasteHTML(tableElement.outerHTML);
                        }
                        catch (Exception ex)
                        {
                            throw new HtmlEditorException("Invalid Text selection for the Insertion of a Table.", "ProcessTable", ex);
                        }
                    }
                    else
                    {
                        mshtmlControlRange controlRange = GetAllControls();
                        if (!controlRange.IsNull())
                        {
                            // overwrite any controls the user has selected
                            try
                            {
                                // clear the selection and insert the table
                                // only valid if multiple selection is enabled
                                for (int idx = 1; idx < controlRange.length; idx++)
                                {
                                    controlRange.remove(idx);
                                }
                                controlRange.item(0).outerHTML = tableElement.outerHTML;
                                // this should work with initial count set to zero
                                // controlRange.add((mshtmlControlElement)table);
                            }
                            catch (Exception ex)
                            {
                                throw new HtmlEditorException("Cannot Delete all previously Controls selected.", "ProcessTable", ex);
                            }
                        }
                        else
                        {
                            // insert the table at the end of the HTML
                            bodyNode.appendChild(tableNode);
                        }
                    }
                }
                else
                {
                    // table has been correctly defined as being the first selected item
                    // need to remove other selected items
                    mshtmlControlRange controlRange = GetAllControls();
                    if (!controlRange.IsNull())
                    {
                        // clear the controls selected other than than the first table
                        // only valid if multiple selection is enabled
                        for (int idx = 1; idx < controlRange.length; idx++)
                        {
                            controlRange.remove(idx);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // throw an exception indicating table structure change error
                throw new HtmlEditorException("Unable to modify Html Table properties.", "ProcessTable", ex);
            }

        } //ProcessTable
        /// <summary>
        /// Gets all the selected Html Controls as a Control Range
        /// </summary>
        /// <returns></returns>
        private mshtmlControlRange GetAllControls()
        {
            // define the selected range object
            mshtmlSelection selection;
            mshtmlControlRange range = null;

            try
            {
                // calculate the first control based on the user selection
                selection = doc.selection;
                if (IsStringEqual(selection.type, SELECT_TYPE_CONTROL))
                {
                    range = (mshtmlControlRange)selection.createRange();
                }
            }
            catch (Exception)
            {
                // have unknow error so set return to null
                range = null;
            }

            return range;

        } //GetAllControls
        /// <summary>
        /// Gets the selected Html Range Element
        /// </summary>
        private mshtmlTextRange GetTextRange()
        {
            // define the selected range object
            mshtmlSelection selection;
            mshtmlTextRange range = null;

            try
            {
                // calculate the text range based on user selection
                selection = doc.selection;
                if (IsStringEqual(selection.type, SELECT_TYPE_TEXT) || IsStringEqual(selection.type, SELECT_TYPE_NONE))
                {
                    range = (mshtmlTextRange)selection.createRange();
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                range = null;
            }

            return range;

        } // GetTextRange
        /// <summary>
        /// Gets the first selected Html Control as an Element
        /// </summary>
        private mshtmlElement GetFirstControl()
        {
            // define the selected range object
            mshtmlSelection selection;
            mshtmlControlRange range;
            mshtmlElement control = null;

            try
            {
                // calculate the first control based on the user selection
                selection = doc.selection;
                if (IsStringEqual(selection.type, SELECT_TYPE_CONTROL))
                {
                    range = (mshtmlControlRange)selection.createRange();
                    if (range.length > 0) control = range.item(0);
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                control = null;
            }

            return control;

        } // GetFirstControl
        /// <summary>
        /// Method to determine if the tag name is of the correct type
        /// A string comparision is made whilst ignoring case
        /// </summary>
        private bool IsStringEqual(string tagText, string tagType)
        {
            return (string.Compare(tagText, tagType, true) == 0) ? true : false;

        } //IsStringEqual














        /// <summary>
        /// Get the ready state of the internal browser component.
        /// </summary>
        public ReadyState ReadyState
        {
            get
            {
                switch (doc.readyState.ToLower())
                {
                    case "uninitialized":
                        return ReadyState.Uninitialized;
                    case "loading":
                        return ReadyState.Loading;
                    case "loaded":
                        return ReadyState.Loaded;
                    case "interactive":
                        return ReadyState.Interactive;
                    case "complete":
                        return ReadyState.Complete;
                    default:
                        return ReadyState.Uninitialized;
                }
            }
        }

        /// <summary>
        /// Get the current selection type.
        /// </summary>
        public SelectionType SelectionType
        {
            get
            {
                var type = doc.selection.type.ToLower();
                switch (type)
                {
                    case "text":
                        return SelectionType.Text;
                    case "control":
                        return SelectionType.Control;
                    case "none":
                        return SelectionType.None;
                    default:
                        return SelectionType.None;
                }
            }
        }
        ///// <summary>
        ///// MAke Zoom in respective to Word Zoom works in dotnet 4.0>
        ///// </summary>
        //private const int OLECMDID_ZOOM = 63;
        //private const int OLECMDEXECOPT_DONTPROMPTUSER = 2;
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="zoom"></param>
        //private void SetZoom(int zoom)
        //{
        //    dynamic obj = webBrowser1.ActiveXInstance;

        //    obj.ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER, zoom, IntPtr.Zero);
        //}
        /// <summary>
        /// Get/Set the current font size.
        /// </summary>
        [Browsable(false)]
        public FontSize FontSize
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return FontSize.NA;
                switch (doc.queryCommandValue("FontSize").ToString())
                {
                    case "1":
                        return FontSize.One;
                    case "2":
                        return FontSize.Two;
                    case "3":
                        return FontSize.Three;
                    case "4":
                        return FontSize.Four;
                    case "5":
                        return FontSize.Five;
                    case "6":
                        return FontSize.Six;
                    case "7":
                        return FontSize.Seven;
                    default:
                        return FontSize.NA;
                }
            }
            set
            {
                int sz;
                switch (value)
                {
                    case FontSize.One:
                        sz = 1;
                        break;
                    case FontSize.Two:
                        sz = 2;
                        break;
                    case FontSize.Three:
                        sz = 3;
                        break;
                    case FontSize.Four:
                        sz = 4;
                        break;
                    case FontSize.Five:
                        sz = 5;
                        break;
                    case FontSize.Six:
                        sz = 6;
                        break;
                    case FontSize.Seven:
                        sz = 7;
                        break;
                    default:
                        sz = 7;
                        break;
                }
                webBrowser1.Document.ExecCommand("FontSize", false, sz.ToString());
                //doc.queryCommandEnabled("FontSize");
                //doc.execCommand("FontSize", false, sz.ToString());
                // SetZoom(2);
            }
        }

        /// <summary>
        /// Get/Set the current font name.
        /// </summary>
        [Browsable(false)]
        public FontFamily FontName
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return null;
                string name = doc.queryCommandValue("FontName") as string;
                if (name == null) return null;
                return new FontFamily(name);
            }
            set
            {
                if (value != null)
                    webBrowser1.Document.ExecCommand("FontName", false, value.Name);
            }
        }

        /// <summary>
        /// Get/Set the editor's foreground (text) color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorForeColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.Black;
                return ConvertToColor(doc.queryCommandValue("ForeColor").ToString());
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("ForeColor", false, colorstr);
            }
        }

        /// <summary>
        /// Get/Set the editor's background color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorBackColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.White;
                return ConvertToColor(doc.queryCommandValue("BackColor").ToString());
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("BackColor", false, colorstr);
            }
        }

        public void SelectBodyColor()
        {
            Color color = BodyBackgroundColor;
            if (ShowColorDialog(ref color))
                BodyBackgroundColor = color;
        }

        /// <summary>
        /// Initiate the foreground (text) color dialog for the current selection.
        /// </summary>
        public void SelectForeColor()
        {
            Color color = EditorForeColor;
            if (ShowColorDialog(ref color))
                EditorForeColor = color;
        }

        /// <summary>
        /// Initiate the background color dialog for the current selection.
        /// </summary>
        public void SelectBackColor()
        {
            Color color = EditorBackColor;
            if (ShowColorDialog(ref color))
                EditorBackColor = color;
        }

        /// <summary>
        /// Convert the custom integer (B G R) format to a color object.
        /// </summary>
        /// <param name="clrs">the custorm color as a string</param>
        /// <returns>the color</returns>
        private static Color ConvertToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                int clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                int clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            Color incolor = Color.FromArgb(red, green, blue);
            return incolor;
        }

        /// <summary>
        /// Called when the cut tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        /// <summary>
        /// Called when the paste tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        /// <summary>
        /// Called when the copy tool strip button on the editor context menu 
        /// is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        /// <summary>
        /// Called when the bold button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void boldButton_Click(object sender, EventArgs e)
        {
            Bold();
        }

        /// <summary>
        /// Called when the italic button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void italicButton_Click(object sender, EventArgs e)
        {
            Italic();
        }

        /// <summary>
        /// Called when the underline button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void underlineButton_Click(object sender, EventArgs e)
        {
            Underline();
        }

        /// <summary>
        /// Called when the foreground color button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            SelectForeColor();
        }

        /// <summary>
        /// Called when the background color button on the tool strip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void backColorButton_Click(object sender, EventArgs e)
        {
            SelectBackColor();
        }

        /// <summary>
        /// Show the interactive Color dialog.
        /// </summary>
        /// <param name="color">the input and output color</param>
        /// <returns>true if dialog accepted, false if dialog cancelled</returns>
        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.SolidColorOnly = true;
                dlg.AllowFullOpen = false;
                dlg.AnyColor = false;
                dlg.FullOpen = false;
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }

        /// <summary>
        /// Called when the link button on the toolstrip is pressed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void linkButton_Click(object sender, EventArgs e)
        {
            SelectLink();
        }

        /// <summary>
        /// Determine if text is selected and only one or no link is selected.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool CanInsertLink()
        {
            //return (SelectionType == SelectionType.Text && !LinksInSelection());
            return (!LinksInSelection());
        }

        /// <summary>
        /// Determine wheter the currently selected text contains two or more links.
        /// </summary>
        /// <returns>true if two links or more links are currently selected, false otherwise</returns>
        private bool LinksInSelection()
        {
            if (SelectionType != Eq2ImgWinForms.SelectionType.Text) return false;
            bool twoOrMoreLinksInSelection = false;
            IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();

            if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
            {
                Regex regex = new Regex("<a href=\"[^\"]+\">[^<]+</a>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                MatchCollection matchCollection = regex.Matches(txtRange.htmlText);

                twoOrMoreLinksInSelection = (matchCollection.Count > 1); // true if more than one link is selected
            }
            if (twoOrMoreLinksInSelection)
            {
                string type = doc.selection.type;
            }
            return twoOrMoreLinksInSelection;
        }

        /// <summary>
        /// Show a custom insert link dialog, and create the link.
        /// </summary>
        public void SelectLink()
        {
            string url = string.Empty;
            switch (SelectionType)
            {
                case Eq2ImgWinForms.SelectionType.Control:
                    {
                        IHTMLControlRange range = doc.selection.createRange() as IHTMLControlRange;
                        if (range != null && range.length > 0)
                        {
                            var elem = range.item(0);
                            if (elem != null && string.Compare(elem.tagName, "img", true) == 0)
                            {
                                elem = elem.parentElement;
                                if (elem != null && string.Compare(elem.tagName, "a", true) == 0)
                                {
                                    url = elem.getAttribute("href") as string;
                                }
                            }
                        }
                    }
                    break;
                case Eq2ImgWinForms.SelectionType.Text:
                    {
                        IHTMLTxtRange txtRange = (IHTMLTxtRange)doc.selection.createRange();
                        if (txtRange != null && !string.IsNullOrEmpty(txtRange.htmlText))
                        {
                            Regex regex = new Regex("^\\s*<a href=\"([^\"]+)\">[^<]+</a>\\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                            Match match = regex.Match(txtRange.htmlText);

                            if (match.Success)
                                url = match.Groups[1].Value;
                        }
                    }
                    break;
            }
            using (LinkDialog dlg = new LinkDialog())
            {
                Uri uri;
                if (Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    dlg.URL = string.Format("{0}{1}", uri.Host, uri.PathAndQuery == null ? null : uri.PathAndQuery.TrimEnd('/'));
                    dlg.Scheme = string.Format("{0}://", uri.Scheme);
                }
                dlg.ShowDialog(this.ParentForm);
                if (!dlg.Accepted) return;
                string link = string.Format("{0}{1}", dlg.Scheme, dlg.URL);
                if (link == null || link.Length == 0)
                {
                    MessageBox.Show(this.ParentForm, "Invalid URL");
                    return;
                }
                InsertLink(link);
            }
        }

        /// <summary>
        /// Called when the image button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void imageButton_Click(object sender, EventArgs e)
        {
            InsertImage();
        }

        /// <summary>
        /// Called when the outdent button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void outdentButton_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        /// <summary>
        /// Called when the indent button on the toolstrip is clicked.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void indentButton_Click(object sender, EventArgs e)
        {
            Indent();
        }

        /// <summary>
        /// Called when the cut button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cut();
        }

        /// <summary>
        /// Called when the copy button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Copy();
        }

        /// <summary>
        /// Called when the paste button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void pasteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Paste();
        }

        /// <summary>
        /// Called when the delete button is clicked on the editor context menu.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        /// <summary>
        /// Search the document from the current selection, and reset the 
        /// the selection to the text found, if successful.
        /// </summary>
        /// <param name="text">the text for which to search</param>
        /// <param name="forward">true for forward search, false for backward</param>
        /// <param name="matchWholeWord">true to match whole word, false otherwise</param>
        /// <param name="matchCase">true to match case, false otherwise</param>
        /// <returns></returns>
        public bool Search(string text, bool forward, bool matchWholeWord, bool matchCase)
        {
            bool success = false;
            if (webBrowser1.Document != null)
            {
                IHTMLDocument2 doc =
                    webBrowser1.Document.DomDocument as IHTMLDocument2;
                IHTMLBodyElement body = doc.body as IHTMLBodyElement;
                if (body != null)
                {
                    IHTMLTxtRange range;
                    if (doc.selection != null)
                    {
                        range = doc.selection.createRange() as IHTMLTxtRange;
                        IHTMLTxtRange dup = range.duplicate();
                        dup.collapse(true);
                        // if selection is degenerate, then search whole body
                        if (range.isEqual(dup))
                        {
                            range = body.createTextRange();
                        }
                        else
                        {
                            if (forward)
                                range.moveStart("character", 1);
                            else
                                range.moveEnd("character", -1);
                        }
                    }
                    else
                        range = body.createTextRange();
                    int flags = 0;
                    if (matchWholeWord) flags += 2;
                    if (matchCase) flags += 4;
                    success =
                        range.findText(text, forward ? 999999 : -999999, flags);
                    if (success)
                    {
                        range.select();
                        range.scrollIntoView(!forward);
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Event handler for the ordered list toolbar button
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void orderedListButton_Click(object sender, EventArgs e)
        {
            OrderedList();
        }

        /// <summary>
        /// Event handler for the unordered list toolbar button
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            UnorderedList();
        }

        /// <summary>
        /// Event handler for the left justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            JustifyLeft();
        }

        /// <summary>
        /// Event handler for the center justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            JustifyCenter();
        }

        /// <summary>
        /// Event handler for the right justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            JustifyRight();
        }

        /// <summary>
        /// Event handler for the full justify toolbar button.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void justifyFullButton_Click(object sender, EventArgs e)
        {
            JustifyFull();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectBodyColor();
        }
        /// <summary>
        /// deleted here for check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            insertHtml();
        }


        private void DropDown_Opening(object sender, CancelEventArgs e)
        {
            var c = tsddbInsertTable.DropDown as ToolStripTableSizeSelector;
            if (c != null)
            {
                c.Selector.SelectedSize = new Size(0, 0);
                c.Selector.VisibleRange = new Size(10, 10);
            }
        }

        private void InitUi()
        {
            //初始化插入表格部分
            var dropDown = new ToolStripTableSizeSelector();
            dropDown.Opening += DropDown_Opening;
            dropDown.Selector.TableSizeSelected += Selector_TableSizeSelected;
            tsddbInsertTable.DropDown = dropDown;
            var tsmiInsertTable = new ToolStripMenuItem
            {
                Image = Resources.InsertTable,
                Name = "tsmiInsertTable",
                Size = new Size(152, 22),
                Text = Resources.strInsertTable,
                Tag = "InsertTable"
            };
            tsmiInsertTable.Click += tsmiInsertTable_Click;
            tsddbInsertTable.DropDownItems.Add(tsmiInsertTable);

            string removeButton = System.Configuration.ConfigurationManager.AppSettings["removeButtons"];
            if (!removeButton.IsNullOrEmpty())
            {
                var removeButtons = removeButton.Split(',');
                foreach (var button in removeButtons)
                {
                    foreach (var item in tsTopToolBar.Items)
                    {
                        if (item is ToolStripButton)
                        {
                            var tsb = item as ToolStripButton;
                            if (String.CompareOrdinal(tsb.Tag.ToString(), button) == 0)
                            {
                                tsb.Visible = false;
                                break;
                            }
                        }
                        else if (item is ToolStripDropDownButton)
                        {
                            var tsddb = item as ToolStripDropDownButton;
                            if (String.CompareOrdinal(tsddb.Tag.ToString(), button) == 0)
                            {
                                tsddb.Visible = false;
                                break;
                            }
                        }
                        //else if (item is ToolStripFontComboBox)
                        //{
                        //    var tsfcb = item as ToolStripFontComboBox;
                        //    if (String.CompareOrdinal(tsfcb.Tag.ToString(), button) == 0)
                        //    {
                        //        tsfcb.Visible = false;
                        //        break;
                        //    }
                        //}
                        else if (item is ToolStripComboBox)
                        {
                            var tscb = item as ToolStripComboBox;
                            if (String.CompareOrdinal(tscb.Tag.ToString(), button) == 0)
                            {
                                tscb.Visible = false;
                                break;
                            }
                        }
                    }
                }
            }
            string removeMenu = ConfigurationManager.AppSettings["removeMenus"];
            if (!string.IsNullOrEmpty(removeMenu))
            {
                var removeMenus = removeMenu.Split(',');
                foreach (var menu in removeMenus)
                {
                    foreach (var item in cmsHtml.Items)
                    {
                        if (item is ToolStripMenuItem)
                        {
                            var tsmi = item as ToolStripMenuItem;
                            if (String.CompareOrdinal(tsmi.Tag.ToString(), menu) == 0)
                            {
                                tsmi.Visible = false;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void tsmiInsertTable_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var command = (string)menuItem.Tag;
            ProcessCommand(command);
        }
        /// <summary>
        /// Method to process the toolbar command and handle error exception
        /// </summary>
        private void ProcessCommand(string command)
        {
            try
            {
                // Evaluate the Button property to determine which button was clicked.
                switch (command)
                {
                    case INTERNAL_COMMAND_NEW:
                        // New document
                        //  New();
                        break;
                    case INTERNAL_COMMAND_OPEN:
                        // Open a selected file
                        // Open();
                        break;
                    case INTERNAL_COMMAND_PRINT:
                        // Print the current document
                        Print();
                        break;
                    case INTERNAL_COMMAND_SAVE:
                        // Saves the current document
                        Save();
                        break;
                    case INTERNAL_COMMAND_PREVIEW:
                        // Preview the html page
                        Preview();
                        break;
                    case INTERNAL_COMMAND_SHOWHTML:
                        // View the html contents
                        //ShowHTML();
                        break;
                    case INTERNAL_COMMAND_COPY:
                        // Browser COPY command
                        Copy();
                        break;
                    case INTERNAL_COMMAND_CUT:
                        // Browser CUT command
                        Cut();
                        break;
                    case INTERNAL_COMMAND_PASTE:
                        // Browser PASTE command
                        Paste();
                        break;
                    case INTERNAL_COMMAND_DELETE:
                        // Browser DELETE command
                        Delete();
                        break;
                    case INTERNAL_COMMAND_UNDO:
                        // Undo the previous editing
                        Undo();
                        break;
                    case INTERNAL_COMMAND_REDO:
                        // Redo the previous undo
                        Redo();
                        break;
                    case INTERNAL_COMMAND_FIND:
                        //Find the string u input
                        // Find();
                        break;
                    case INTERNAL_COMMAND_REMOVE_FORMAT:
                        // Browser REMOVEFORMAT command
                        RemoveFormat();
                        break;
                    case INTERNAL_COMMAND_JUSTIFYCENTER:
                        // Justify Center
                        JustifyCenter();
                        break;
                    case INTERNAL_COMMAND_JUSTIFYFULL:
                        // Justify Full
                        JustifyFull();
                        break;
                    case INTERNAL_COMMAND_JUSTIFYLEFT:
                        // Justify Left
                        JustifyLeft();
                        break;
                    case INTERNAL_COMMAND_JUSTIFYRIGHT:
                        // Justify Right
                        JustifyRight();
                        break;
                    case INTERNAL_COMMAND_UNDERLINE:
                        // Selection UNDERLINE command
                        Underline();
                        break;
                    case INTERNAL_COMMAND_ITALIC:
                        // Selection ITALIC command
                        Italic();
                        break;
                    case INTERNAL_COMMAND_BOLD:
                        // Selection BOLD command
                        Bold();
                        break;
                    case INTERNAL_COMMAND_FORECOLOR:
                        // FORECOLOR style creation
                        // FormatFontColor(tscpForeColor.Color);
                        break;
                    case INTERNAL_COMMAND_BACKCOLOR:
                        // BACKCOLOR style creation
                        //  FormatBackColor(tscpBackColor.Color);
                        break;
                    case INTERNAL_COMMAND_STRIKETHROUGH:
                        // Selection STRIKETHROUGH command
                        // StrikeThrough();
                        break;
                    case INTERNAL_COMMAND_CREATELINK:
                        // Selection CREATELINK command
                        //CreateLink();
                        break;
                    case INTERNAL_COMMAND_UNLINK:
                        // Selection UNLINK command
                        // UnLink();
                        break;
                    case INTERNAL_COMMAND_INSERTTABLE:
                        // Display a dialog to enable the user to insert a table
                        TableInsertPrompt();
                        break;
                    case INTERNAL_COMMAND_TABLEPROPERTIES:
                        // Display a dialog to enable the user to modify a table
                        TableModifyPrompt();
                        break;
                    case INTERNAL_COMMAND_TABLEPROPERTIES_CELLWIDTH:
                        // Added by amit
                        TableCellSizeModifyPrompt();
                        break;
                    case INTERNAL_COMMAND_TABLEINSERTROW:
                        // Display a dialog to enable the user to modify a table
                        TableInsertRow();
                        break;
                    case INTERNAL_COMMAND_TABLEDELETEROW:
                        // Display a dialog to enable the user to modify a table
                        TableDeleteRow();
                        break;
                    case INTERNAL_COMMAND_INSERTIMAGE:
                        // Display a dialog to enable the user to insert a image
                        InsertImage();
                        break;
                    case INTERNAL_COMMAND_INSERTHORIZONTALRULE:
                        // Horizontal Line
                        // InsertLine();
                        break;
                    case INTERNAL_COMMAND_OUTDENT:
                        // Tab Left
                        Outdent();
                        break;
                    case INTERNAL_COMMAND_INDENT:
                        // Tab Right
                        Indent();
                        break;
                    case INTERNAL_COMMAND_INSERTUNORDEREDLIST:
                        // Unordered List
                        InsertUnorderedList();
                        break;
                    case INTERNAL_COMMAND_INSERTORDEREDLIST:
                        // Ordered List
                        InsertOrderedList();
                        break;
                    case INTERNAL_COMMAND_SUPERSCRIPT:
                        // Selection SUPERSCRIPT command
                        Superscript();
                        break;
                    case INTERNAL_COMMAND_SUBSCRIPT:
                        // Selection SUBSCRIPT command
                        Subscript();
                        break;
                    case INTERNAL_COMMAND_SELECTALL:
                        // Selects all document content
                        SelectAll();
                        break;
                    case INTERNAL_COMMAND_WORDCOUNT:
                        // Word count
                        //int wordCount = WordCount();
                        //tsslWordCount.Text = string.Format("字数：{0}", wordCount);
                        break;
                    case INTERNAL_COMMAND_INSERTDATE:
                        // Insert date
                        PasteIntoSelection(DateTime.Now.ToLongDateString());
                        break;
                    case INTERNAL_COMMAND_INSERTTIME:
                        // Insert time
                        PasteIntoSelection(DateTime.Now.ToLongTimeString());
                        break;
                    case INTERNAL_COMMAND_CLEARWORD:
                        // Clear word
                        // if (BodyInnerHTML != null)
                        //  {
                        // Debug.Assert(wb.Document != null, "wb.Document != null");
                        // Debug.Assert(wb.Document.Body != null, "wb.Document.Body != null");
#if VS2010
                            //  wb.Document.Body.InnerHtml = ClearWord(BodyInnerHTML);
#else
                        //  wb.Document.Body.InnerHtml = ClearWordNoDefult(BodyInnerHTML, true, true, true);
#endif
                        // }
                        break;
                    case INTERNAL_COMMAND_AUTOLAYOUT:
                        // Auto Layout
                        // AutoLayout();
                        break;
                    case INTERNAL_COMMAND_ABOUT:
                        if (MessageBox.Show(Resources.AboutInfo, Resources.AboutText, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            // Process.Start("http://tewuapple.github.com/WinHtmlEditor/");
                        }
                        break;
                    default:
                        throw new HtmlEditorException("Unknown Operation Being Performed.", command);
                }
            }
            catch (HtmlEditorException ex)
            {
                // process the html exception
                OnHtmlException(new HtmlExceptionEventArgs(ex.Operation, ex));
            }
            catch (Exception ex)
            {
                // process the exception
                OnHtmlException(new HtmlExceptionEventArgs(null, ex));
            }

            // ensure web browser has the focus after command execution
            Focus();

        }//ProcessCommand

        private bool TableCellSizeModifyPrompt()
        {
            // define the Html Table element
            mshtmlTable table = GetTableElement();

            mshtmlTextRange range = GetTextRange();
            // if a table has been selected then process
            if (!range.IsNull())
            {
                var currentCell = range.parentElement();
                var currentWidthHolds = currentCell.style.width;
                var dialog = new SetColumnWidth(currentWidthHolds);
                dialog.ShowDialog(this);
                var newWidth = dialog.textBoxColumnSize.Text + "px";
                if (dialog.DialogResult == DialogResult.Yes)
                {

                    ((mshtmlElement)currentCell).style.width = newWidth;

                    var tableRow = (mshtmlTableRow)table.rows.item(0, null);
                    for (int i = 0; i < tableRow.cells.length; i++)
                    {
                        if (!tableRow.cells.item(i, null).IsNull())
                        {
                            var currentcellwidth = ((mshtmlElement)tableRow.cells.item(i, null)).style.width;
                            var tableWidth = table.width;
                            var NewCellWidths = (Convert.ToInt16(tableWidth) - Convert.ToInt16(newWidth.Replace("px", ""))) / (tableRow.cells.length - 1);
                            if (currentcellwidth != null && !currentcellwidth.Equals(newWidth))
                            {
                                ((mshtmlElement)tableRow.cells.item(i, null)).style.width = NewCellWidths + "px";
                            }
                        }
                    }





                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// The currently selected text/controls will be replaced by the given HTML code.
        /// If nothing is selected, the HTML code is inserted at the cursor position
        /// </summary>
        /// <param name="sHtml"></param>
        public void PasteIntoSelection(string sHtml)
        {
            //HTMLEditHelper.DOMDocument = doc;
            HTMLEditHelper.PasteIntoSelection(sHtml);
        }
        /// <summary>
        /// Method to insert an unordered list
        /// </summary>
        public void InsertUnorderedList()
        {
            ExecuteCommandRange(HTML_COMMAND_INSERT_UNORDERED_LIST, null);
            FormatSelectionChange();
        } //InsertUnorderedList

        /// <summary>
        /// Method to insert an ordered list
        /// </summary>
        public void InsertOrderedList()
        {
            ExecuteCommandRange(HTML_COMMAND_INSERT_ORDERED_LIST, null);
            FormatSelectionChange();
        } //InsertOrderedList

        /// <summary>
        /// Method to allow the user to preview the html page
        /// </summary>
        public void Preview()
        {
            body = (HTMLBody)doc.body;
            bool isPreview = (body.contentEditable == "true");
            for (int i = 0; i < tsTopToolBar.Items.Count; i++)
            {
                tsTopToolBar.Items[i].Enabled = !isPreview;
            }
            if (isPreview)
            {
                body.contentEditable = "false";
                cmsHtml.Enabled = false;
                tsbPreview.Enabled = true;
            }
            else
            {
                cmsHtml.Enabled = true;
                body.contentEditable = "true";
            }
        }
        /// <summary>
        /// RemoveFormat
        /// </summary>
        public void RemoveFormat()
        {
            ExecuteCommandDocument(HTML_COMMAND_REMOVE_FORMAT);
        } //RemoveFormat

        /// <summary>
        /// Executes the execCommand on the document with a system prompt
        /// </summary>
        private void ExecuteCommandDocument(string command, bool prompt = false)
        {
            try
            {
                // ensure command is a valid command and then enabled for the selection
                if (doc.queryCommandSupported(command))
                {
                    // if (document.queryCommandEnabled(command)) {}
                    // Test fails with a COM exception if command is Print

                    // execute the given command
                    doc.execCommand(command, prompt, null);
                }
            }
            catch (Exception ex)
            {
                // Unknown error so inform user
                throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
            }

        } // ExecuteCommandDocumentPrompt

        /// <summary>
        /// Method to allow the user to persist the Html stream to a file
        /// </summary>
        public void Save()
        {
            using (var dialog = new SaveFileDialog
            {
                FileName = "",
                Filter = Resources.SaveFilter,
                Title = Resources.SaveTitle
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);
                    writer.Write(BodyHtml);
                    writer.Close();
                }
            }
        } //New
        /// <summary>
        /// Method using the document to toggle the selection with a Superscript tag
        /// </summary>
        public void Superscript()
        {
            ExecuteCommandRange(HTML_COMMAND_SUPERSCRIPT, null);
            FormatSelectionChange();

        } //Superscript
        /// <summary>
        /// Ensures the toolbar is correctly displaying state
        /// </summary>
        private void FormatSelectionChange()
        {
            // don't process until bowser is create.
            //if (wb.IsHandleCreated == false)
            //    return;
            SetupKeyListener();
            tsbBold.Checked = IsBold();
            tsbItalic.Checked = IsItalic();
            tsbUnderline.Checked = IsUnderline();
            //tsbStrikeThrough.Checked = IsStrikeThrough();
            tsbInsertOrderedList.Checked = IsOrderedList();
            tsbInsertUnorderedList.Checked = IsUnorderedList();
            tsbJustifyLeft.Checked = IsJustifyLeft();
            tsbJustifyCenter.Checked = IsJustifyCenter();
            tsbJustifyRight.Checked = IsJustifyRight();
            tsbJustifyFull.Checked = IsJustifyFull();
            tsbSubscript.Checked = IsSubscript();
            tsbSuperscript.Checked = IsSuperscript();
            // tsbUndo.Enabled = IsUndo();
            // tsbRedo.Enabled = IsRedo();
            // tsbUnlink.Enabled = IsUnlink();
            // UpdateFontComboBox();
            // UpdateFontSizeComboBox();
        }



        /// <summary>
        /// Method using the document to toggle the selection with a Subscript tag
        /// </summary>
        public void Subscript()
        {
            ExecuteCommandRange(HTML_COMMAND_SUBSCRIPT, null);
            FormatSelectionChange();

        } //Subscript


        /// <summary>
        /// Executes the execCommand on the selected range
        /// </summary>
        private void ExecuteCommandRange(string command, object data)
        {
            // obtain the selected range object and execute command
            mshtmlTextRange range = GetTextRange();
            ExecuteCommandRange(range, command, data);

        } // ExecuteCommandRange
        /// <summary>
        /// Executes the execCommand on the selected range (given the range)
        /// </summary>
        private void ExecuteCommandRange(mshtmlTextRange range, string command, object data)
        {
            try
            {
                if (!range.IsNull())
                {
                    // ensure command is a valid command and then enabled for the selection
                    if (range.queryCommandSupported(command))
                    {
                        if (range.queryCommandEnabled(command))
                        {
                            // mark the selection with the appropriate tag
                            range.execCommand(command, false, data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Unknown error so inform user
                throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
            }

        } // ExecuteCommandRange
        /// <summary>
        /// Method to delete the currently selected row
        /// Operation based on the current user row location
        /// </summary>
        public void TableDeleteRow()
        {
            // see if a table selected or insertion point inside a table
            mshtmlTable table;
            mshtmlTableRow row;
            GetTableElement(out table, out row);

            // process according to table being defined
            if (!table.IsNull() && !row.IsNull())
            {
                try
                {
                    // find the existing row the user is on and perform the deletion
                    int index = row.rowIndex;
                    table.deleteRow(index);
                }
                catch (Exception ex)
                {
                    throw new HtmlEditorException("Unable to delete the selected Row", "TableDeleteRow", ex);
                }
            }
            else
            {
                throw new HtmlEditorException("Row not currently selected within the table", "TableDeleteRow");
            }

        } //TableDeleteRow
        /// <summary>
        /// Method to insert a new row into the table
        /// Based on the current user row and insertion after
        /// </summary>
        public void TableInsertRow()
        {
            // see if a table selected or insertion point inside a table
            mshtmlTable table;
            mshtmlTableRow row;
            GetTableElement(out table, out row);

            // process according to table being defined
            if (!table.IsNull() && !row.IsNull())
            {










                try
                {
                    // find the existing row the user is on and perform the insertion
                    int index = row.rowIndex + 1;
                    var insertedRow = (mshtmlTableRow)table.insertRow(index);

                    // add the new columns to the end of each row
                    int numberCols = row.cells.length;
                    for (int idxCol = 0; idxCol < numberCols; idxCol++)
                    {
                        insertedRow.insertCell();
                    }
                }
                catch (Exception ex)
                {
                    throw new HtmlEditorException("Unable to insert a new Row", "TableinsertRow", ex);
                }
            }
            else
            {
                throw new HtmlEditorException("Row not currently selected within the table", "TableInsertRow");
            }

        } //TableInsertRow
        /// <summary>
        /// Method to present to the user the table properties dialog
        /// Uses all the default properties for the table based on an insert operation
        /// </summary>
        public void TableInsertPrompt()
        {
            // if user has selected a table create a reference
            var table = GetFirstControl() as mshtmlTable;
            ProcessTablePrompt(table);

        } //TableInsertPrompt
        /// <summary>
        /// Method to present to the user the table properties dialog
        /// Ensure a table is currently selected or insertion point is within a table
        /// </summary>
        public bool TableModifyPrompt()
        {
            // define the Html Table element
            mshtmlTable table = GetTableElement();

            // if a table has been selected then process
            if (!table.IsNull())
            {
                ProcessTablePrompt(table);
                return true;
            }
            return false;
        } //TableModifyPrompt
        /// <summary>
        /// Method to determine if the current selection is a table
        /// If found will return the table element
        /// </summary>
        private void GetTableElement(out mshtmlTable table, out mshtmlTableRow row)
        {
            row = null;
            mshtmlTextRange range = GetTextRange();

            try
            {
                // first see if the table element is selected
                table = GetFirstControl() as mshtmlTable;
                // if table not selected then parse up the selection tree
                if (table.IsNull() && !range.IsNull())
                {
                    var element = range.parentElement();
                    // parse up the tree until the table element is found
                    while (!element.IsNull() && table.IsNull())
                    {
                        element = element.parentElement;
                        // extract the Table properties
                        var htmlTable = element as mshtmlTable;
                        if (!htmlTable.IsNull())
                        {
                            table = htmlTable;
                        }
                        // extract the Row  properties
                        var htmlTableRow = element as mshtmlTableRow;
                        if (!htmlTableRow.IsNull())
                        {
                            row = htmlTableRow;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // have unknown error so set return to null
                table = null;
                row = null;
            }

        } //GetTableElement

        /// <summary>
        /// Method to return the currently selected Html Table Element
        /// </summary>
        private mshtmlTable GetTableElement()
        {
            // define the table and row elements and obtain there values
            mshtmlTable table;
            mshtmlTableRow row;
            GetTableElement(out table, out row);

            // return the defined table element
            return table;

        }

        /// <summary>
        /// Determine whether the current selection is in Subscript mode.
        /// </summary>
        /// <returns>whether or not the current selection is Subscript</returns>
        public bool IsSubscript()
        {
            return ExecuteCommandQuery(HTML_COMMAND_SUBSCRIPT);
        }

        /// <summary>
        /// Determine whether the current selection is in Superscript mode.
        /// </summary>
        /// <returns>whether or not the current selection is Superscript</returns>
        public bool IsSuperscript()
        {
            return ExecuteCommandQuery(HTML_COMMAND_SUPERSCRIPT);
        }
        /// <summary>
        /// Performs a query of the command state
        /// </summary>
        private bool ExecuteCommandQuery(string command, bool isEnabled = false)
        {
            // obtain the selected range object and query command
            mshtmlTextRange range = GetTextRange();
            return ExecuteCommandQuery(range, command, isEnabled);

        } //ExecuteCommandQuery

        /// <summary>
        /// Executes the queryCommandState on the selected range (given the range)
        /// </summary>
        private bool ExecuteCommandQuery(mshtmlTextRange range, string command, bool isEnabled = false)
        {
            // set the initial state as false
            bool retValue = false;

            try
            {
                if (!range.IsNull())
                {
                    // ensure command is a valid command and then enabled for the selection
                    if (range.queryCommandSupported(command))
                    {
                        if (isEnabled)
                        {
                            retValue = range.queryCommandEnabled(command);
                        }
                        else
                        {
                            if (range.queryCommandEnabled(command))
                            {
                                // mark the selection with the appropriate tag
                                retValue = range.queryCommandState(command);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Unknown error so inform user
                throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
            }

            // return the value
            return retValue;

        } // ExecuteCommandQuery
        /// <summary>
        /// Method to raise an event if a delegeate is assigned for handling exceptions
        /// </summary>
        private void OnHtmlException(HtmlExceptionEventArgs args)
        {
            if (HtmlException.IsNull())
            {
                // obtain the message and operation
                // concatenate the message with any inner message
                string operation = args.Operation;
                Exception ex = args.ExceptionObject;
                string message = ex.Message;
                if (!ex.InnerException.IsNull())
                {
                    message = string.Format("{0}\n{1}", message, ex.InnerException.Message);
                }
                // define the title for the internal message box
                string title;
                if (operation.IsNullOrEmpty())
                {
                    title = "Unknown Error";
                }
                else
                {
                    title = operation + " Error";
                }
                // display the error message box
                MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HtmlException(this, args);
            }
        }
        private void Selector_TableSizeSelected(object sender, TableSizeEventArgs e)
        {

            // if user has selected a table create a reference
            var table = GetFirstControl() as mshtmlTable;

            // define the base set of table properties
            HtmlTableProperty tableProperties = GetTableProperties(table);
            tableProperties.TableRows = (byte)e.SelectedSize.Height;
            tableProperties.TableColumns = (byte)e.SelectedSize.Width;
            if (table.IsNull()) TableInsert(tableProperties);
            else ProcessTable(table, tableProperties);

        }

        /// <summary>
        /// General Context Meun processing method
        /// Calls the ProcessCommand with the selected command Tag Text
        /// </summary>
        private void ContextEditorClick(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var command = (string)menuItem.Tag;
            ProcessCommand(command);
        } //contextEditorClick


        private void tsbSuperscript_Click(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            var command = (string)button.Tag;
            ProcessCommand(command);
        }

        private void tsbSubscript_Click(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            var command = (string)button.Tag;
            ProcessCommand(command);
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            var command = (string)button.Tag;
            ProcessCommand(command);
        }

        private void tsbSpellCheck_Click(object sender, EventArgs e)
        {
            Debug.Assert(webBrowser1.Document != null, "webBrowser1.Document != null");
            Debug.Assert(webBrowser1.Document.Body != null, "webBrowser1.Document.Body != null");
            spellCheck.Text = webBrowser1.Document.Body.InnerHtml;
            spellCheck.SpellCheck();
        }
        [STAThread]
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(GeneratePDF));
            string html = doc.body.innerHTML;
            th.Start(html);

        }

        private void GeneratePDF(object obj)
        {
            var htmlContent = obj.ToString();
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            var filename = "Amit.pdf";

            var tempFolder = System.IO.Path.GetTempPath();
            filename = System.IO.Path.Combine(tempFolder, filename);
            System.IO.File.WriteAllBytes(filename, pdfBytes);
            System.Diagnostics.Process.Start(filename);
        }


    }

    /// <summary>
    /// Enumeration of possible font sizes for the Editor component
    /// </summary>
    public enum FontSize
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        NA
    }

    public enum SelectionType
    {
        Text,
        Control,
        None
    }

    public enum ReadyState
    {
        Uninitialized,
        Loading,
        Loaded,
        Interactive,
        Complete
    }


}