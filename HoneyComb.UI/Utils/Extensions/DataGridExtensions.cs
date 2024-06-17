using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.Utils.Extensions
{
    public static class DataGridExtensions
    {
        public static void Populate(this IEnumerable<DataGridViewCell> targetRow, IEnumerable<object> values)
        {
            var cellSource = targetRow.GetEnumerator();
            var valueSource = values.GetEnumerator();

            while (cellSource.MoveNext() & valueSource.MoveNext())
            {
                (cellSource.Current as DataGridViewCell)!.Value = valueSource.Current;
            }
        }

        public static IEnumerable<IEnumerable<DataGridViewCell>> OrderByPosition (this DataGridViewSelectedCellCollection target)
        {
            var temp = (from DataGridViewCell cell in target select cell).ToArray();

            return temp.
                GroupBy(cell => cell.RowIndex).
                OrderBy(row => row.Key).
                Select(row => 
                    row.OrderBy(cell => cell.ColumnIndex)
                );
                
        }
    }

}
