using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public static class Globals
    {
        internal const bool SHOW_BASE_COMPONENTS_IN_TOOLBOX = true;

        public const bool SELECT_ALL_ON_ENTER_FOCUS = true;

        public const string TYPED_CONTROL_ROOT_CATEGORY = "Strongly-Typed Control";

        public static ErrorProvider? IsRequiredErrorProvider { get; set; }
        public static ErrorProvider? RangeErrorProvider { get; set; }


        public static Action<Control, String> SetErrorValidationFailed { get; set; } = delegate { };
        public static Action<Control, String> SetErrorRequiredLocally { get; set; } = delegate { };
        public static Action<Control, String> SetErrorRequiredGlobally { get; set; } = delegate { };

        public static string RequiredLocallyMsg { get; set; } = "This field is required for this section";
        public static string RequiredGloballyMsg { get; set; } = "This field is required to generate a final rate";
    }
}
