using HoneyComb.UI.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.BaseComponents.MultiSelect
{
    public class MultiSelectPanel : Panel
    {

        public MultiSelectPanel()
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT

                return cp;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }
            using (Pen pen = new Pen(SystemColors.Highlight, 2))
            {

                var drawnArea = ClientRectangle;
                drawnArea.Deflate(new(3, 3, 4, 4));

                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, drawnArea);
            }


        }
    }
}
