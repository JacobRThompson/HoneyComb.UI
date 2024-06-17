using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
namespace HoneyComb.UI.Utils.Extensions
{
    public static class StringExtensions
    {
        private static IEnumerable<string> FindNumericSubtringCanidates(this string self, NumberStyles style = NumberStyles.None)
        {
            StringBuilder regexBody = new StringBuilder();
            StringBuilder allowedCharacters = new(@"\d");

            var numberFormat = CultureInfo.CurrentCulture.NumberFormat;

            if (style.HasFlag(NumberStyles.AllowThousands))
            {
                allowedCharacters.Append(
                    style.HasFlag(NumberStyles.AllowCurrencySymbol) ?
                        numberFormat.CurrencyGroupSeparator :
                        numberFormat.NumberGroupSeparator
                    );
            }

            if (style.HasFlag(NumberStyles.AllowLeadingSign))
            {
                regexBody.Append($"[{numberFormat.NegativeSign},{numberFormat.PositiveSign}]?");
            }

            if (style.HasFlag(NumberStyles.AllowCurrencySymbol))
            {
                regexBody.Append($@"\{numberFormat.CurrencySymbol}");
            }

            regexBody.Append($"[{allowedCharacters}]");

            if (style.HasFlag(NumberStyles.AllowDecimalPoint))
            {
                regexBody.Append(@"\.?\d*");
            }

            string regexText = regexBody.ToString();

            var result = Regex.Matches(self, regexText).
                Select(x => x.Value).
                Where(x => !string.IsNullOrWhiteSpace(x));

            return result;
        }

        public static IEnumerable<float> FindNumericValues(this string self, NumberStyles style = NumberStyles.None)
        {
            var temp = self.FindNumericSubtringCanidates(style).
                Select<string, float?>(x =>
                    float.TryParse(x, style, CultureInfo.CurrentCulture, out float result) switch
                    {
                        true => result,
                        false => null
                    }
                ).OfType<float>();

            return temp;
        }

        public static IEnumerable<IEnumerable<string>> SplitClipboardCells(string cells)
        {
            IEnumerable<string> rows = cells.Split("\r\n");
            return rows.Select(row => row.Split("\t"));
        }
    }

    


    public enum OrderMethod
    {
        AsString,
        AsNumberAppendNonNumeric,
        AsNumberPrependNonNumeric
    }
}
