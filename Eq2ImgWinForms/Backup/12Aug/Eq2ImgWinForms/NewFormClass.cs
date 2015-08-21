using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Astrila.Eq2ImgWinForms
{
    class NewFormClass
    {

        private static Form _defaultInstance_EditorForm;


        public Form DefaultInstance_EditorForm
        {

            get
            {
                if (_defaultInstance_EditorForm == null || _defaultInstance_EditorForm.IsDisposed)
                {
                    _defaultInstance_EditorForm = new EditorForm();

                }
                return _defaultInstance_EditorForm;
            }
        }

    }
}
