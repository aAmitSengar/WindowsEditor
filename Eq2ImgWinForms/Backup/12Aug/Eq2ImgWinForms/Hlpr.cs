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

    }
}
