using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Honeycomb.UI.BaseComponents.TextBoxParsers
{

    public static class NumericControlParser
    {

        public const string FORMAT_STRING_DEFAULT = "";
        public const NumberStyles NUMERIC_STYLE_DEFAULT = NumberStyles.Number;
    }

    public sealed class NumericControlParser<T> : IControlParser<T>
         where T : struct, INumber<T>
    {
        

        private readonly IAffixer<T> _affixer;
        private NumberStyles _numericStyle;

        public NumericControlParser()
        {
            _affixer = new Affixer<T>();
            _numericStyle = NumericControlParser.NUMERIC_STYLE_DEFAULT;
        }

        public string FormatString { get; set; } = NumericControlParser.FORMAT_STRING_DEFAULT;
        public NumberStyles NumericStyle
        {
            get => IsCurrency ?
                _numericStyle | NumberStyles.AllowCurrencySymbol :
                _numericStyle;

            set => _numericStyle = value;
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

        private bool IsCurrency => !string.IsNullOrEmpty(FormatString) && char.ToUpper(FormatString[0]) == 'C';
        private bool IsPercent => !string.IsNullOrEmpty(FormatString) && char.ToUpper(FormatString[0]) == 'P';

        public bool TryParse(in string text, [NotNullWhen(true)] out T result)
        {
            string unaffixedText = _affixer.StripAffixes(text);

            //generate text that we pass to the appropriate parse funciton. We may strip a percent sign here.
            string parsedText = IsPercent ? unaffixedText.TrimEnd('%') : unaffixedText;

            result = default;
            try
            {
                //We parse passed text and then divide to account for the use of a precent if needed.
                dynamic admissionOfFailure = result switch
                {
                    int _ => int.Parse(parsedText, NumericStyle, CultureInfo.CurrentCulture) / (IsPercent ? 100 : 1),
                    double _ => double.Parse(parsedText, NumericStyle, CultureInfo.CurrentCulture) / (IsPercent ? 100d : 1d),
                    decimal _ => decimal.Parse(parsedText, NumericStyle, CultureInfo.CurrentCulture) / (IsPercent ? 100m : 1m),
                    _ => throw new NotImplementedException()
                };

                result = admissionOfFailure;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }

        public string ConvertToString(in T value)
        {
            //C# is annoying when it comes to nested string interpolation. Because of this, we break formatting into 2 steps:

            //1. Generating the template that we pass to string.Format
            string formatTemplate = _affixer.AddAffixes($"{{0:{FormatString}}}");

            //2. Actually formatting the damn value
            return string.Format(formatTemplate, value);
        }
    }
}
