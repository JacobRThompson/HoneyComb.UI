using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.Utils;
namespace Honeycomb.UI
{
    public interface ISelectable
    {
        public bool Selectable { get; set; }


        public void WndProc(ref Message m)
        {
            if (!Selectable & m.Msg == NativeMethods.WM_SETFOCUS)
            {
                m.Msg = NativeMethods.WM_KILLFOCUS;
            }
        }
    }
}
