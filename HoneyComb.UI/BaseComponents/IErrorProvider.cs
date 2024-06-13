using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    public interface IErrorProvider
    {
        void SetError(Control control, string errorText);
    }
}
