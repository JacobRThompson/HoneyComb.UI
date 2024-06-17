using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.Utils.Extensions
{
    public static class ErrorProviderExtensions
    {
        public static void SetErrorWithInterface(this ErrorProvider target, Control control, string errorText)
        {
            if (target is IErrorProvider iTarget)
            {
                iTarget.SetError(control, errorText);
            }
            else
            {
                target.SetError(control, errorText);
            }
        }


    }
}
