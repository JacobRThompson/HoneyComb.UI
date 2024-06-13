using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Honeycomb.UI.Utils
{
    public static class ControlExtensions
    {
        public static void SwapIndices(this Control.ControlCollection controls, int index1, int index2)
        {

            if (index1 < 0 || index1 >= controls.Count)
                throw new ArgumentOutOfRangeException(nameof(index1), $"Index must be between 0 and {controls.Count - 1}");
            if (index2 < 0 || index2 >= controls.Count)
                throw new ArgumentOutOfRangeException(nameof(index2), $"Index must be between 0 and {controls.Count - 1}");

            if (index1 == index2)
                return;

            Control control1 = controls[index1];
            Control control2 = controls[index2];


            if (index1 > index2)
            {
                controls.SetChildIndex(control1, index2);
                controls.SetChildIndex(control2, index1);
            }
            else
            {
                controls.SetChildIndex(control2, index1);
                controls.SetChildIndex(control1, index2);
            }
        }

        public static void SwapIndices(this ToolStripItemCollection items, int index1, int index2)
        {

            if (index1 < 0 || index1 >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index1), $"Index must be between 0 and {items.Count - 1}");
            if (index2 < 0 || index2 >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index2), $"Index must be between 0 and {items.Count - 1}");

            if (index1 == index2)
                return;

            ToolStripItem item1 = items[index1];
            ToolStripItem item2 = items[index2];

            items.Remove(item1);
            items.Remove(item2);

            if (index1 > index2)
            {
                items.Insert(index2, item1);
                items.Insert(index1, item2);
            }
            else
            {
                items.Insert(index1, item2);
                items.Insert(index2, item1);
            }
        }

        public static bool HasMouse(this Control control, Rectangle clientRegion) => clientRegion.Contains(control.PointToClient(Cursor.Position));
        public static bool HasMouse(this Control control) => control.HasMouse(control.ClientRectangle);

    }
}
