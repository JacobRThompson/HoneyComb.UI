using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxParsers
{
    internal class StringTextboxParser : ITextBoxParser<ReadOnlyMemory<char>>
    {
        private readonly IAffixer<ReadOnlyMemory<char>> _affixer;

        public StringTextboxParser()
        {
            _affixer = new Affixer<ReadOnlyMemory<char>>();
        }

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

        public bool TryParse(in string text, out ReadOnlyMemory<char> result)
        {
            result = _affixer.StripAffixes(text).AsMemory();
            return true;
        }

        public string ConvertToString(in ReadOnlyMemory<char> value)
        {
            string unaffixedString = value.ToString();

            return _affixer.AddAffixes(unaffixedString);
        }
    }
}
