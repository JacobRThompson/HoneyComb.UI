using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Interfaces
{
    public interface IInvokeValidation
    {

        public void InvokeValidation(CancelEventArgs? e);
    }
}
