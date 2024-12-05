using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using Honeycomb.UI.BaseComponents;
namespace Honeycomb.UI.StronglyTypedControls.TextBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class IntTextBox : NumericControlHost<ValidateOnEnterTextBox, int>
    {
        public IntTextBox() : base(
           (in string? s, NumberStyles style, IFormatProvider? provider, out int result) => int.TryParse(s, style, provider, out result),
           (x) => x / 100)
        {

        }

    }
}
