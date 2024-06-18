using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoneyComb.UI.Utils.Extensions;
using static HoneyComb.UI.BaseComponents.MultiSelect.Algorithms;
namespace HoneyComb.UI.BaseComponents.MultiSelect
{
    public static class Algorithms
    {
        public static List<Control[]> GenerateRows(IEnumerable<Control> selectedControls)
        {
            var unsortedControls = selectedControls
                .Select(ctrl => new MeomoizedControl(ctrl, new Rectangle(ctrl.PointToScreen(default), ctrl.Size)))
                .OrderBy(ctrl => ctrl.ScreenBounds.X)
                .ToList();

            List<Control[]> results = [];
            LinkedList<Control> currentRow = [];

            MeomoizedControl currentItem;
            MeomoizedControl prevItem;
            while (unsortedControls.Count > 0)
            {

                var rowRoot = unsortedControls.MinBy(ctrl => ctrl.ScreenBounds.Y);
                int rootIndex = unsortedControls.IndexOf(rowRoot);
                unsortedControls.RemoveAt(rootIndex);
                currentRow.AddFirst(rowRoot.Control);


                //Generate right half of row
                prevItem = rowRoot;
                int i = rootIndex;
                while( i<unsortedControls.Count)
                {
                    currentItem = unsortedControls[i];
                    if (currentItem.ScreenBounds.Top <= prevItem.ScreenBounds.Bottom &&
                        currentItem.ScreenBounds.Bottom >= prevItem.ScreenBounds.Top)
                    {
                        prevItem = currentItem;
                        currentRow.AddLast(currentItem.Control);
                        unsortedControls.Remove(currentItem);
                    }
                    else
                    {
                        i++;
                    }
                }

                //Generate left half of row
                prevItem = rowRoot;
                i = rootIndex;
                while (0 < i)
                {
                    i--;
                    currentItem = unsortedControls[i];
                    if (currentItem.ScreenBounds.Top <= prevItem.ScreenBounds.Bottom &&
                        currentItem.ScreenBounds.Bottom >= prevItem.ScreenBounds.Top)
                    {
                        prevItem = currentItem;
                        currentRow.AddFirst(currentItem.Control);
                        unsortedControls.Remove(currentItem);
                    }
                }

                results.Add(currentRow.ToArray());
                currentRow.Clear();
            }

            return results;
        }

        /// <summary>
        /// A struct that contains the following:
        ///     <list type="number">
        ///     <item>A control </item>
        ///     <item>The bounds of the passed control as measured from the screen</item>
        ///     </list>
        /// </summary>
        /// <remarks>
        /// Used to reduce the number of times the passed control is measured in screen-space
        /// </remarks>
        public readonly record struct MeomoizedControl(Control Control, Rectangle ScreenBounds);

    }
}
