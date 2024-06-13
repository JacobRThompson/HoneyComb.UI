using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Honeycomb.UI.Interfaces
{
    /*
    public interface INumericValued<T> : IValued<T>
        where T : struct, IEqualityOperators<T, T, bool>, IModulusOperators<T, T, T>, IComparisonOperators<T, T, bool>, IAdditiveIdentity<T, T>, IEquatable<T>
    {
        public const NumberStyles INPUT_STYLE = NumberStyles.Number;
        public const string FORMAT_STRING = "G4";

        public RangeErrors RangeErrors { get; set; }
        public NumberStyles NumericStyle { get; set; }
        public string FormatString { get; set; }

        //
        string IAffixed.TrimAffixes(string text)
        {
            text = GetIsPercent() ? TrimPrefix(text, "%") : text;
            return TrimSuffix(TrimPrefix(text, Prefix), Suffix);
        }

        public bool GetIsCurrency() => string.IsNullOrEmpty(FormatString) switch
        {
            true => false,
            false => char.ToUpper(FormatString[0]) == 'C'
        };

        public bool GetIsPercent() => string.IsNullOrEmpty(FormatString) switch
        {
            true => false,
            false => char.ToUpper(FormatString[0]) == 'P'
        };

        public bool IsCurrency { get;}
        public bool IsPercent { get;}

        public T? MinValue { get; set; }
        public T? MaxValue { get; set; }
        public T? Modulus { get; set; }

        public T RevertPercentFormatting(T x);

        public sealed RangeErrors CalcRangeErrors(T value)
        {
            RangeErrors result = 0;

            //Append flags to result for each way in which we fail range validation
            if (Modulus.HasValue & value % Modulus != T.AdditiveIdentity) { result |= RangeErrors.NotDivisibleByModulus; }
            if (MaxValue.HasValue & value > MaxValue) { result |= RangeErrors.GreaterThanMax; }
            if (MinValue.HasValue & value < MinValue) { result |= RangeErrors.LessThanMin; }

            return result;
        }

        public NumberStyles GetInputStyle(in NumberStyles _inputStyle) => GetIsCurrency() switch
        {
            false => _inputStyle,
            true => _inputStyle | NumberStyles.AllowCurrencySymbol
        };


    }
    */

    [Flags]
    public enum RangeErrors
    {
        None = 0,
        LessThanMin = 1,
        GreaterThanMax = 2,
        NotDivisibleByModulus = 4
    }
    

}
