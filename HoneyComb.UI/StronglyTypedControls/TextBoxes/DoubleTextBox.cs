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
    public class DoubleTextBox : NumericControlHost<ValidateOnEnterTextBox, double>, ISelectable
    {
        public DoubleTextBox() : base(
          (in string? s, NumberStyles style, IFormatProvider? provider, out double result) => double.TryParse(s, style, provider, out result),
          (x) => x / 100)
        {
        }

        public bool Selectable
        {
            get => Child.Selectable;
            set => Child.Selectable = value;
        }
    }
}




