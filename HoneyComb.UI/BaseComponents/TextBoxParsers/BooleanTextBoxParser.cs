using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxParsers
{
    public class BooleanTextBoxParser : ITextBoxParser<bool>
    {
        public const string TRUE_LABEL_DEFAULT = "Yes";
        public const string FALSE_LABEL_DEFAULT = "No";

        private readonly IAffixer<bool> _affixer;

        public BooleanTextBoxParser()
        {
            _affixer = new Affixer<bool>();         
        }

        public string TrueLabel { get; set; } = TRUE_LABEL_DEFAULT;
        public string FalseLabel { get; set; } = FALSE_LABEL_DEFAULT;

        public string Suffix
        {
            get => _affixer.Suffix;
            set => _affixer.Suffix = value;
        }
        public string Prefix
        {
            get => _affixer.Prefix;
            set => _affixer.Prefix = value;
        }

        public string ConvertToString(in bool value)
        {
            return _affixer.AddAffixes(value ? TrueLabel : FalseLabel);
        }

        public bool TryParse(in string text, out bool result)
        {
            string unaffixedText = _affixer.StripAffixes(text);

            if(unaffixedText == TrueLabel)
            {
                result = true;
                return true;
            }
            else if (unaffixedText == FalseLabel)
            {
                result = false;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
