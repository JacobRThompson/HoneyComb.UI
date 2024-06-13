using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Interfaces
{
    public interface IRequireableControl : IHoneycombControl
    {

        public const bool IS_REQUIRED = false;
        public const string IS_REQUIRED_MSG = "";

        ///<summary> Flag indicating if a control is required</summary>
        public bool IsRequired { get; set; }

        ///<summary> Msg shown via <seealso cref="IsRequiredErrorProvider"/> whenever the requirements needed for a control are not satisfied</summary>     
        public string IsRequiredMsg { get; set; }

        public bool IsRequiredSatisfied { get; }

        public ErrorProvider? IsRequiredErrorProvider { get; }
     
        public void UpdateIsRequiredProvider()
        {
            IsRequiredErrorProvider?.SetError(Control.FromHandle(Handle), IsRequiredSatisfied ?  string.Empty : IsRequiredMsg);
        }

        
    }

   
}
