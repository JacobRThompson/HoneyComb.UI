using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ControlHost
{
    public interface IComboBoxHost<TControl, T>: IValuedControlHost<TControl, T>
        where TControl : ComboBox, new()
        where T : struct, IEquatable<T>
    {
        public ComboBoxHostExtension<TControl, T> ListExtension { get; }

       
    }
}
