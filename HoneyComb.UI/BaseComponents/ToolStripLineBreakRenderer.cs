using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;


namespace Honeycomb.UI.BaseComponents
{
    public class ToolStripLineBreakRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            
            Pen lineBreakPen = new(SystemColors.InactiveBorder, 1);//new(e.ToolStrip.Parent != null ? e.ToolStrip.Parent.BackColor: e.ToolStrip.BackColor);

            int currentRowY = int.MinValue;  
            foreach (ToolStripItem item in e.ToolStrip.Items)
            {
                if (item.Visible && item.Bounds.Bottom > currentRowY)
                {
                    currentRowY = item.Bounds.Bottom-1;
                    e.Graphics.DrawLine(lineBreakPen, new Point(e.ToolStrip.Left, currentRowY), new Point(e.ToolStrip.Right, currentRowY));
                }
            }
            
        }
        
    }
}
