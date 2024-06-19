using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.BaseComponents.MultiSelect
{
    public interface IExcelPasteTarget
    {
        public bool PasteableFromExcel { get; set; }
    }
}
