using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public  class ValidateOnEnterTextBox: TextBox, ISelectable
    {

        [DefaultValue(true)]
        public bool Selectable { get; set; } = true;

      

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    OnValidating(new());
                    e.Handled = true;
                break;
            }

            base.OnKeyPress(e);
        }

        protected override void WndProc(ref Message m)
        {
            (this as ISelectable).WndProc(ref m);
            base.WndProc(ref m);
        }
    }
}
