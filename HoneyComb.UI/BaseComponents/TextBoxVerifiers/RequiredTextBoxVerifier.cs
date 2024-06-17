using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.UI.Utils.Extensions;

namespace Honeycomb.UI.BaseComponents.TextBoxVerifiers
{
    public static class RequiredTextBoxVerifier
    {
        public static readonly Guid TypeId = Guid.NewGuid();
        public const bool IS_REQUIRED_DEFAULT = false;
        public const string IS_REQUIRED_MSG = "This field is required";
        public static ErrorProvider? IsRequiredProvider { get; set; }
    }

    public sealed class RequiredTextBoxVerifier<T>: ITextBoxVerifier<T>
        where T: struct
    {
        public RequiredTextBoxVerifier(bool enabled)
        {
            Enabled = enabled;
        }

        public Guid TypeId => RequiredTextBoxVerifier.TypeId;
        public bool Enabled { get; set; }

        public Control? Parent { get;  set; }
        public bool IsRequired { get; set; } = RequiredTextBoxVerifier.IS_REQUIRED_DEFAULT;

        

        public bool Verify( in (bool couldParse, T parsedValue) parseResult)
        {
            bool isValid = parseResult.couldParse || !IsRequired;

            string errorText = parseResult.couldParse ? string.Empty : RequiredTextBoxVerifier.IS_REQUIRED_MSG;

            if (RequiredTextBoxVerifier.IsRequiredProvider != null && Parent!= null &&
                RequiredTextBoxVerifier.IsRequiredProvider.GetError(Parent) != errorText)
            {
                RequiredTextBoxVerifier.IsRequiredProvider.SetErrorWithInterface(Parent, errorText);
            }

            return isValid;
        }
    }
}
