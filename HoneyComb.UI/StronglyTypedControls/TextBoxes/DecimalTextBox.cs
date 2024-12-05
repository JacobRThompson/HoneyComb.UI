using Honeycomb.UI.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using HoneyComb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;

namespace Honeycomb.UI.StronglyTypedControls.TextBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class DecimalTextBox : NumericControlHost<ValidateOnEnterTextBox, decimal>
    {
        public DecimalTextBox() : base(
            (in string? s, NumberStyles style, IFormatProvider? provider, out decimal result) => decimal.TryParse(s, style, provider, out result),
            (x) => x / 100)
        {
        }
    }
}
