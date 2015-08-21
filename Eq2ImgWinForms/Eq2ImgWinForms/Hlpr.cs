using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Astrila.Eq2ImgWinForms.Database;

namespace Astrila.Eq2ImgWinForms
{
    public class Hlpr : Form
    {
        public static SqlConnection con = new SqlConnection(DataAccess.connection);
        public MyEnum myenum;

        private const int MOD_ALT = 0x1;
        private const int MOD_CONTROL = 0x2;
        private const int MOD_SHIFT = 0x4;
        private const int MOD_WIN = 0x8;
        private const int WM_HOTKEY = 0x312;

        [DllImport("user32.dll")]
        public static extern bool GetCaretPos(ref Point pt);


        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32")]
        public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool a = UnregisterHotKey(Handle, 42);
            base.OnClosing(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256)
            {
                if (keyData == (Keys.Escape))
                {
                    this.Close();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnFormClosing(e);
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                if (!Visible)
                    Visible = true;
                Activate();
                Keys vk = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int fsModifiers = ((int)m.LParam & 0xFFFF);

                if (vk == Keys.F1 && fsModifiers == 0)
                {
                    //   toolStripTextBox1.TextBox.Clear();
                    // fill_grid();
                }
                if (vk == Keys.F3 && fsModifiers == 0)
                {
                    // this.ActiveControl = toolStripButton3.TextBox;
                }
            }
        }
        protected void convert_to_Shreedev0702()
        {
            var array_one = new string[]{"–",
            "के", "ङे", "छे", "टे", "ठे", "डे", "ढे", "ळे", "हे", "ऊँ",
            "क़", "ख़", "ग़", "ज़", "ड़", "ढ़", "फ़", // one-byte varnas               //07
            //"ं©",  "ै©","ैं©","ी©","ीं©", "े©", "ें©",
            "ॐ", "ऽ", "।", "‘", "’",                                          //05
            "क्ष्", "क्ष", "ज्ञ", "श्र", "त्र", "त्र्", "त्त", "त्त्",                                   //07
            "्रु", "्रू", "रु", "रू",                                           //04

            "ञ्च्", "ज्ज्", "च्च", "ल्ल", "ह्ण", "ह्ल", "ह्व", //"्व",                           //08
            "ङ्क", "ङ्ख", "ङ्ग", "ङ्घ", "ङ्क्ष", "ह्न", "ड्ढ", "श्व",                          //08
            "ङ्म", "क्क", "क्व", "क्त", "ख्र", "झ्र", "ग्न", "ट्ट", "ट्ठ", "ठ्ठ", "ड्ड", "ड्ढ",  //13 "्न",
            "द्र", "दृ", "द्ग", "द्घ", "द्द", "द्ध", "द्न", "द्ब", "द्भ", "द्म", "द्य", "द्व", "न्न", "प्र", "प्त", "ष्ट", "ष्ठ",     //17
            "स्र", "स्त्र", "ह्र", "हृ", "ह्म", "ह्य", "श्च", "श्न",                         //08

            "छ्र", "ट्र", "ड्र", "ढ्र",                                             //04
             "्र",                                                //02

            "क्", "ख्", "ग्", "घ्", "क", "ख", "ग", "घ", "ङ",                           //09
            "च्", "ज्", "झ्", "ञ्", "च", "छ", "ज", "झ",                               //08
            "ट", "ठ", "ड", "ढ", "ण्", "ण",                                       //06
            "त्", "थ्", "ध्", "न्", "त", "थ", "द", "ध", "न",                            //09
            "प्", "फ्", "ब्", "भ्", "म्", "प", "फ", "ब", "भ", "म",                         //10

            "य्", "ल्", "व्", "श्", "ष्", "ळ्", "श्", "स्", "ह्",                         //09
            "य", "र", "ल", "ल", "व", "श", "ष", "स", "ह", "ळ",                          //10
            "्य",
            "औ", "ओ", "ऑ", "आ", "अ", "ई", "इ", "उ", "ऊ", "ऋ", "ॠ", "ऐ", "ए",              //13

            "ौ", "ो", "ॉ", "ा", "ी", "ु", "ू", "ृ", "ॄ", "े", "ै", "ँ", "ं", "ः", "्", "ॅ", "़",    //17

            "०", "१", "२", "३", "४", "५", "६", "७", "८", "९"};
            var array_two = new string[]{"", "", "{", "{", "\"", "'",
            "क़", "ख़्", "ख़", "ग़", "ज़", "ड़", "ढ़", "फ़", // one-byte varnas
            "ं©", "ै©", "ैं©", "ी©", "ीं©", "े©", "ें©",
            "ॐ", "ऽ", "।", "‘", "’",
            "क्ष्", "क्ष", "ज्ञ", "श्र", "त्र", "त्र्", "त्त्",
            "्रु", "्रू", "रु", "रू",

            "ञ्च्", "ज्ज्", "च्च", "ल्ल", "ह्ण", "ह्ल", "ह्व", "्व",
            "ङ्क", "ङ्ख", "ङ्ग", "ङ्घ", "ङ्क्ष", "ह्न", "ड्ढ", "श्व",
            "्न", "ङ्म", "क्क", "क्व", "क्त", "ख्र", "झ्र", "ग्न", "ट्ट", "ट्ठ", "ठ्ठ", "ड्ड", "ड्ढ",
            "द्र", "दृ", "द्ग", "द्घ", "द्द", "द्ध", "द्न", "द्ब", "द्भ", "द्म", "द्य", "द्व", "न्न", "प्र", "प्त", "ष्ट", "ष्ठ",
            "स्र", "स्त्र", "ह्र", "हृ", "ह्म", "ह्य", "श्च", "श्न",
            "्य", "्र", "्र", "्र",

            "क्", "ख्", "ग्", "घ्", "क", "ख", "ग", "घ", "ङ",
            "च्", "ज्", "झ्", "ञ्", "च", "छ", "ज", "झ",
            "ट", "ठ", "ड", "ढ", "ण्", "ण",
            "त्", "थ्", "ध्", "न्", "त", "थ", "द", "ध", "न",
            "प्", "फ्", "ब्", "भ्", "म्", "प", "फ", "ब", "भ", "म",

            "य्", "ल्", "व्", "श्", "ष्", "ळ्", "श्", "स्", "ह्",
            "य", "र", "ल", "ल", "व", "श", "ष", "स", "ह", "ळ",

            "औ", "ओ", "ऑ", "आ", "अ", "ई", "इ", "उ", "ऊ", "ऋ", "ॠ", "ऐ", "ए",

            "ा", "ी", "ी", "ीं", "ु", "ु", "ू", "ू", "ृ", "ॄ", "ें", "े", "ै", "ैं", "ः", "ं", "ं", "़",
            "ु", "ू", "ॅ", "ँ", "्",

            "०", "१", "२", "३", "४", "५", "६", "७", "८", "९",

            "", "े", "ै", "ओ", "आ", "औ", "ओ", "ो", "ॉ", "ॉ", "ो",
            "ुं", "े", "अ‍ै", "ो", "अ‍े", "ां", "अ‍ॅ", "ौ", "ौ", "ृं",
            "ाँ", "ूँ", "ो", "ें", "ों", "ँ", "ँ", " :", "ूं"};     // Remove typing mistakes in the original file

            //**************************************************************************************
            //
            // Punctuation marks incorporated at the end
            //
            //**************************************************************************************
            // The following two characters are to be replaced through proper checking of locations:
            //**************************************************************************************
            //   "{",
            //   "ि",
            //
            //   "©",
            //   "र्" (reph)
            //
            //**************************************************************************************

        }
    }

}

