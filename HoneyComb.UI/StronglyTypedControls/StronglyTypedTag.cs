using HoneyComb.UI.BaseComponents.MultiSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.StronglyTypedControls
{
    public class StronglyTypedTag : IExcelPasteTarget
    {
        public bool PasteableFromExcel { get; set; } = true;
    }
}
