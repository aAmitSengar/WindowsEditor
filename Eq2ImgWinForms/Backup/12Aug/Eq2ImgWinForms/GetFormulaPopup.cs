using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    public partial class GetFormulaPopup : Form
    {
        public string tempGifFilePath { get; set; }
        public GetFormulaPopup()
        {
            InitializeComponent();
            radioButton1.Checked = Properties.Settings.Default.AutoUpdateFormula;
            //this.editor1.toolStrip1.Visible = false;
            // Synchronize some private members with the form's values.
            _ZoomFactor = trbZoomFactor.Value;
            _BackColor = pictureBox1.BackColor;

            // Set the sizemode of both pictureboxes. These modes are important
            // to the functionality and should not be changed.
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            picZoom.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #region Private members

        /// <summary>
        /// Stores the zoomfactor of the picZoom picturebox
        /// </summary>
        private int _ZoomFactor;
        /// <summary>
        /// Stores the color used to fill any areas not covered by an image
        /// </summary>
        private Color _BackColor;
        /// <summary>
        /// Stores an instance of the originally loaded image
        /// </summary>
        private Image _OriginalImage;

        #endregion // Private members
        #region Resize Image
        public void ResizeAndDisplayImage()
        {

            // Set the backcolor of the pictureboxes

            pictureBox1.BackColor = _BackColor;
            picZoom.BackColor = _BackColor;

            // If _OriginalImage is null, then return. This situation can occur

            // when a new backcolor is selected without an image loaded.

            if (_OriginalImage == null)
                return;

            // sourceWidth and sourceHeight store
            // the original image's width and height

            // targetWidth and targetHeight are calculated
            // to fit into the pictureBox1 picturebox.

            int sourceWidth = _OriginalImage.Width;
            int sourceHeight = _OriginalImage.Height;
            int targetWidth;
            int targetHeight;
            double ratio;

            // Calculate targetWidth and targetHeight, so that the image will fit into

            // the pictureBox1 picturebox without changing the proportions of the image.

            if (sourceWidth > sourceHeight)
            {
                // Set the new width

                targetWidth = pictureBox1.Width;
                // Calculate the ratio of the new width against the original width

                ratio = (double)targetWidth / sourceWidth;
                // Calculate a new height that is in proportion with the original image

                targetHeight = (int)(ratio * sourceHeight);
            }
            else if (sourceWidth < sourceHeight)
            {
                // Set the new height

                targetHeight = pictureBox1.Height;
                // Calculate the ratio of the new height against the original height

                ratio = (double)targetHeight / sourceHeight;
                // Calculate a new width that is in proportion with the original image

                targetWidth = (int)(ratio * sourceWidth);
            }
            else
            {
                // In this case, the image is square and resizing is easy

                targetHeight = pictureBox1.Height;
                targetWidth = pictureBox1.Width;
            }

            // Calculate the targetTop and targetLeft values, to center the image

            // horizontally or vertically if needed

            int targetTop = (pictureBox1.Height - targetHeight) / 2;
            int targetLeft = (pictureBox1.Width - targetWidth) / 2;

            // Create a new temporary bitmap to resize the original image

            // The size of this bitmap is the size of the pictureBox1 picturebox.

            Bitmap tempBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height,
                                           PixelFormat.Format24bppRgb);

            // Set the resolution of the bitmap to match the original resolution.

            tempBitmap.SetResolution(_OriginalImage.HorizontalResolution,
                                     _OriginalImage.VerticalResolution);

            // Create a Graphics object to further edit the temporary bitmap

            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // First clear the image with the current backcolor

            bmGraphics.Clear(_BackColor);

            // Set the interpolationmode since we are resizing an image here

            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the original image on the temporary bitmap, resizing it using

            // the calculated values of targetWidth and targetHeight.

            bmGraphics.DrawImage(_OriginalImage,
                                 new Rectangle(targetLeft, targetTop, targetWidth, targetHeight),
                                 new Rectangle(0, 0, sourceWidth, sourceHeight),
                                 GraphicsUnit.Pixel);

            // Dispose of the bmGraphics object

            bmGraphics.Dispose();

            // Set the image of the pictureBox1 picturebox to the temporary bitmap

            pictureBox1.Image = tempBitmap;
        }
        private void UpdateZoomedImage(MouseEventArgs e)
        { // Calculate the width and height of the portion of the image we want

            // to show in the picZoom picturebox. This value changes when the zoom

            // factor is changed.

            int zoomWidth = picZoom.Width / _ZoomFactor;
            int zoomHeight = picZoom.Height / _ZoomFactor;

            // Calculate the horizontal and vertical midpoints for the crosshair

            // cursor and correct centering of the new image

            int halfWidth = zoomWidth / 2;
            int halfHeight = zoomHeight / 2;

            // Create a new temporary bitmap to fit inside the picZoom picturebox

            Bitmap tempBitmap = new Bitmap(zoomWidth, zoomHeight,
                                           PixelFormat.Format24bppRgb);

            // Create a temporary Graphics object to work on the bitmap

            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // Clear the bitmap with the selected backcolor

            bmGraphics.Clear(_BackColor);

            // Set the interpolation mode

            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the portion of the main image onto the bitmap

            // The target rectangle is already known now.

            // Here the mouse position of the cursor on the main image is used to

            // cut out a portion of the main image.

            bmGraphics.DrawImage(pictureBox1.Image,
                                 new Rectangle(0, 0, zoomWidth, zoomHeight),
                                 new Rectangle(e.X - halfWidth, e.Y - halfHeight,
                                 zoomWidth, zoomHeight), GraphicsUnit.Pixel);

            // Draw the bitmap on the picZoom picturebox

            picZoom.Image = tempBitmap;

            // Draw a crosshair on the bitmap to simulate the cursor position

            bmGraphics.DrawLine(Pens.Black, halfWidth + 1,
                                halfHeight - 4, halfWidth + 1, halfHeight - 1);
            bmGraphics.DrawLine(Pens.Black, halfWidth + 1, halfHeight + 6,
                                halfWidth + 1, halfHeight + 3);
            bmGraphics.DrawLine(Pens.Black, halfWidth - 4, halfHeight + 1,
                                halfWidth - 1, halfHeight + 1);
            bmGraphics.DrawLine(Pens.Black, halfWidth + 6, halfHeight + 1,
                                halfWidth + 3, halfHeight + 1);

            // Dispose of the Graphics object

            bmGraphics.Dispose();

            // Refresh the picZoom picturebox to reflect the changes

            picZoom.Refresh();
        }
        /// <summary>
        /// Set the _ZoomFactor value to match the trbZoomFactor control's value
        /// and display the selected value to the user
        /// </summary>
        private void trbZoomFactor_ValueChanged(object sender, EventArgs e)
        {
            _ZoomFactor = trbZoomFactor.Value;
            lblZoomFactor.Text = string.Format("x{0}", _ZoomFactor);
        }
        /// <summary>
        /// When the mouse is moved over the picImage picturebox, the picZoom
        /// picturebox must reflect the change and adjust its image to the portion
        /// of the image the mouse is over
        /// </summary>
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            // If no picture is loaded, return
            if (pictureBox1.Image == null)
                return;

            UpdateZoomedImage(e);
        }
        #endregion


        private void GetFormulaPopup_Load(object sender, EventArgs e)
        {
            WriteEquation(textBoxEquation.Text);
        }



        private string GetGifFilePath()
        {
            var path1 = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.FormulaImages);
            var FileName = Guid.NewGuid().ToString() + ".gif";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            return Path.Combine(path1, FileName);
            //return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".gif");
        }
        private void WriteEquation(string equation)
        {
            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
            }
            if (equation.Length > 0)
            {
                tempGifFilePath = GetGifFilePath();
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

        private void textBoxEquation_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (string.IsNullOrEmpty(textBoxEquation.Text.Trim()))
                { }
                else
                {
                    WriteEquation(textBoxEquation.Text);
                }

            }
        }

        #region  Calc Button
        private void button12_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\sqrt[]{}";
        }

        private void LeftBracket_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\left( ";
        }

        private void RightBracket_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\right) ";
        }

        private void LeftCurlyBresess_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\left\\{ ";
        }

        private void RightCurlyBresess_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\right} ";
        }

        private void LeftMerti_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\left| ";
        }


        private void RightMerti_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\right| ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"y=\left\{ {x/2\mbox{ if x even} \atop (x+1)/2\text{ if odd}}      \right.";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\left.   {\text{this}\atop \text{that}}   \right\}   =   y ";
        }

        private void btnVector_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"vec{x}";
        }

        private void btnOmega_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\omega";
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\frac x2 ";
        }

        private void btnDevide_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\div";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

        }

        private void btnPlusMinuse_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\pm";
        }

        private void btnSqrtRoot_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\sqrt[2]{2}";
        }

        private void btnintegration_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\int\limits_{x_i}^{x_{i+1}}\left\{\right\}dx";
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnNotEqualsto_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\not=";
        }

        private void btnPI_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\pi{2}";
        }

        private void btnSummession_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\displaystyle\sum_{i=1}^n i ";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\cdot";
        }
        private void btnDelta_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\Delta";
        }
        private void btnalpha_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\alpha";

        }
        private void btnBeta_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\beta";
        }

        private void bnGama_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\gamma";
        }

        private void btnDentaSymbol_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\delta";
        }
        private void btnEpsilon_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\epsilon";
        }
        private void btnMu_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\mu";
        }
        private void btnPiBig_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\PI";
        }
        private void btnpsi_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\Psi";
        }
        private void btnTheta_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\theta";
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\lim_{x\to\infty}(\frac1{x})=0";
        }
        private void btnOverline_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\overline{x}";
        }
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\underline{x}";
        }
        private void btnSin_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\sin";
        }
        private void btnSinh_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\sinh";
        }
        private void btnCos_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\cos";
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\cosh";
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\tan";
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\tanh";
        }
        private void btnExp_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\exp";
        }
        private void btnInfty_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\infty";
        }
        private void btnMatrix_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @" \begin{pmatrix} a&b\c&d \end{pmatrix}";
        }
        private void btnMathbb_Click(object sender, EventArgs e)
        {
            textBoxEquation.Text = textBoxEquation.Text + @"\mathbb{R}";
        }
        #endregion

        private void buttonShow_Click(object sender, EventArgs e)
        {
            WriteEquation(textBoxEquation.Text);
        }

        private void Select_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BtnSaveFormulaImage_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog1.FileName);
        }


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpdateFormula = radioButton1.Checked;
            Properties.Settings.Default.Save();
        }







































    }
}
