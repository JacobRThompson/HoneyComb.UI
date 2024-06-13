using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Honeycomb.UI.BaseComponents.TextBoxParsers
{



    public sealed class DateTextBoxParser: ITextBoxParser<DateOnly>
    {
        public const string FORMAT_STRING_DEFAULT = "";
        public const DateTimeStyles DATETIME_STYLE_DEFAULT = DateTimeStyles.None;

        private readonly IAffixer<DateOnly> _affixer;
        private DateTimeStyles _dateTimeStyle;


        public DateTextBoxParser()
        {
            _affixer = new Affixer<DateOnly>();
            _dateTimeStyle = DATETIME_STYLE_DEFAULT;
        }


        public string FormatString { get; set; } = NumericTextBoxParser.FORMAT_STRING_DEFAULT;

        public DateTimeStyles DateTimeStyle
        {
            get => _dateTimeStyle;
            set => _dateTimeStyle = value;
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

        public bool TryParse(in string text,[NotNullWhen(true)] out DateOnly result)
        {
            string unaffixedText = _affixer.StripAffixes(text);

            //Placeholder in case we need to do any extra handling later similar to how percents are handled in NumericTextBoxParser
            string parsedText = unaffixedText;

            if (DateOnly.TryParse(parsedText, CultureInfo.CurrentCulture, DateTimeStyle, out DateOnly value)){

                result = value;

                //For some reason, there are cases where an invalid value will get marked as being able to be parsed.
                //Instead of rewriting everything, we add an additional check and call it a day
                return value != default;
            }
            else
            {
                result = default; 
                return false;
            }
        }

        public string ConvertToString(in DateOnly value)
        {
            //C# is annoying when it comes to nested string interpolation. Because of this, we break formatting into 2 steps:

            //1. Generating the template that we pass to string.Format
            string formatTemplate = _affixer.AddAffixes($"{{0:{FormatString}}}");

            //2. Actually formatting the damn value
            return string.Format(formatTemplate, value);
        }

    }
}
