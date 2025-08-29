using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using HoneyComb.UI.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.BaseComponents.TextBoxVerifiers
{
    public static class CouldParseVerifier
    {
        public static readonly Guid TypeId = Guid.NewGuid();
        public const string COULD_NOT_PARSE_MSG = "Could not parse value";
        public static ErrorProvider? CouldParseProvider { get; set; }

    }

    public sealed class CouldParseVerifier<T> : IControlVerifier<T>
        where T: struct
    {
        public CouldParseVerifier(bool enabled) 
        { 
            Enabled = enabled;
        }

        public Guid TypeId => RequiredControlVerifier.TypeId;
        public bool Enabled { get; set; }

        public Control? Parent { get; set; }

        public bool Verify(in (bool couldParse, T parsedValue) parseResult)
        {
        
            string errorText = parseResult.couldParse ? string.Empty : CouldParseVerifier.COULD_NOT_PARSE_MSG;

            if (CouldParseVerifier.CouldParseProvider != null && Parent != null &&
                CouldParseVerifier.CouldParseProvider.GetError(Parent) != errorText)
            {
                CouldParseVerifier.CouldParseProvider.SetErrorWithInterface(Parent, errorText);
            }

            return parseResult.couldParse;
        }
    }
}
