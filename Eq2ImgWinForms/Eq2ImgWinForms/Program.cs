using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.Run(new Workspace());
          //Application.Run(new QuestionsListing());
              Application.Run(new EditorForm());
        }
    }
}
