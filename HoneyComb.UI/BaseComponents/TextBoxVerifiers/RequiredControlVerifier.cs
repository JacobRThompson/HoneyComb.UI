using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.UI.Utils.Extensions;

namespace Honeycomb.UI.BaseComponents.TextBoxVerifiers
{
    public static class RequiredControlVerifier
    {
        public static readonly Guid TypeId = Guid.NewGuid();
        public const bool IS_REQUIRED_DEFAULT = false;
        public const string IS_REQUIRED_MSG = "This field is required";
        public static ErrorProvider? IsRequiredProvider { get; set; }
    }

    public sealed class RequiredControlVerifier<T>: IControlVerifier<T>
        where T: struct
    {
        public RequiredControlVerifier(bool enabled)
        {
            Enabled = enabled;
        }

        public Guid TypeId => RequiredControlVerifier.TypeId;
        public bool Enabled { get; set; }

        public Control? Parent { get;  set; }
        public bool IsRequired { get; set; } = RequiredControlVerifier.IS_REQUIRED_DEFAULT;

        

        public bool Verify( in (bool couldParse, T parsedValue) parseResult)
        {
            bool isValid = parseResult.couldParse || !IsRequired;

            string errorText = parseResult.couldParse ? string.Empty : RequiredControlVerifier.IS_REQUIRED_MSG;

            if (RequiredControlVerifier.IsRequiredProvider != null && Parent!= null &&
                RequiredControlVerifier.IsRequiredProvider.GetError(Parent) != errorText)
            {
                RequiredControlVerifier.IsRequiredProvider.SetErrorWithInterface(Parent, errorText);
            }

            return isValid;
        }
    }
}
