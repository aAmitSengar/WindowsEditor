using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace Astrila.Eq2ImgWinForms
{
    public partial class QuestionsListing : Hlpr
    {
        public QuestionsListing()
        {
            InitializeComponent();
          //  this.dataGridView1.CellToolTipTextNeeded += dataGridView1_CellToolTipTextNeeded;
        }
        //private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        //{
           
        //    e.ToolTipText = @"<P style='MARGIN: 2pt 0in 1pt 15.85pt' class=qnoh11pt><SPAN><?xml:namespace prefix = o ns = 'urn:schemas-microsoft-com:office:office' /><o:p><SPAN style='FONT-FAMILY: 'Times New Roman','serif'; FONT-SIZE: 8pt; mso-bidi-font-family: 'Courier New'; mso-fareast-font-family: 'Times New Roman'; mso-fareast-language: EN-US; mso-ansi-language: EN-US; mso-bidi-language: AR-SA'><FONT size=2 face='New Century Schoolbook'>‘‘Mobile phones and wireless communication devices are completely banned in the examination halls/rooms. Candidates are advised not to keep mobile phones/any other wireless communication devices with them even switching it off, in their own interest. Failing to comply with this provision will be considered as using unfair means in the examination and action will be taken against them including cancellation of their candidature.’’</FONT></SPAN></o:p></SPAN></P>";
        //}
        private void QuestionsListing_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dap = new SqlDataAdapter("SELECT  QuestionID,QueTitleEng FROM    QuestionMaster", con);
            DataTable dt1 = new DataTable();
            if (con.State == ConnectionState.Closed) { con.Open(); }

            dap.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();


            //HTMLDocument doc = new HTMLDocument();
            //IHTMLDocument2 doc2 = (IHTMLDocument2)doc;


            //HtmlElement nn;
            //nn.InnerHtml = "kjlkjkl";
            //DataGridView dgv = new DataGridView();
            //this.panel1.Controls.Add(dgv);



            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("colBestBefore", typeof(HtmlElement)));

            //    dt.Columns.Add(new DataColumn("colStatus", typeof(string)));

            // dt.Columns["colStatus"].Expression = String.Format("IIF(colBestBefore < #{0}#, 'Ok','Not ok')", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //dt.Rows.Add(nn);
            // dt.Rows.Add("");
            // dt.Rows.Add("");
            // dt.Rows.Add(DateTime.Now.AddDays(-2).ToString());



            //dgv.DataSource = dt;
            //dgv.Update();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex >= 1 & e.RowIndex >= 0)
            //{//if (e.ColumnIndex == dataGridView1.Columns[nameOrIndexOfYourImageColumn].Index)
            //    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
            //    // another cell in the same row (see my note below).
            //    cell.ToolTipText = cell.Value.ToString();
            //}
        }
        private DataTable HtmlTableToDgv(HtmlElement HtmlTable)
        {
            DataTable table = new DataTable();
            HtmlElementCollection rows = HtmlTable.GetElementsByTagName("tr");
            bool hExists = false;
            if (rows[0].InnerHtml.ToUpper().Contains("<TH"))
            {
                HtmlElementCollection headers = rows[0].GetElementsByTagName("th");
                foreach (HtmlElement header in headers)
                {
                    table.Columns.Add(header.InnerText, Type.GetType("System.String"));
                }
                hExists = true;
            }
            else
            {
                HtmlElementCollection fColumns = rows[0].GetElementsByTagName("td");
                foreach (HtmlElement fColumn in fColumns)
                {
                    table.Columns.Add(null, Type.GetType("System.String"));
                }
            }
            for (int rNumber = 0; rNumber <= (rows.Count + Convert.ToInt32(hExists)) - 1; rNumber++)
            {
                table.Rows.Add();
                HtmlElementCollection columns = rows[rNumber - Convert.ToInt32(hExists)].GetElementsByTagName("td");
                for (int cNumber = 0; cNumber <= columns.Count - 1; cNumber++)
                {
                    table.Rows[rNumber][cNumber] = columns[cNumber].InnerText;
                }
            }
            return table;
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex == -1)
            {

               // e.PaintContent(Rectangle.FromLTRB(5, 12, 200, 200));
               // e.Handled = true;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.CurrentCell;
            var cellDisplayRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var aa = System.Web.HttpUtility.HtmlAttributeEncode("<b>amit</b>");

            toolTip1.Show(string.Format(System.Web.HttpUtility.HtmlEncode("<b>amit</b>") + "this is cell {0},{1}", e.ColumnIndex, e.RowIndex),
                          dataGridView1,
                          cellDisplayRect.X + cell.Size.Width / 2,
                          cellDisplayRect.Y + cell.Size.Height / 2,
                          2000);
            
            dataGridView1.ShowCellToolTips = false;
        }

    }

}