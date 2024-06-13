using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxVerifiers
{

    public static class NumericTextBoxVerifier
    {
        public static ErrorProvider? OutsideNumericRangeProvider { get; set; }
        public readonly static Guid TypeId = Guid.NewGuid();
    }

    public sealed class NumericTextBoxVerifier<T> : ITextBoxVerifier<T>
        where T : struct, INumber<T>
    {
        private readonly StringBuilder _errorBuilder = new();


        public NumericTextBoxVerifier(bool enabled, string formatString = "N", 
            TryGetter<T>? upperBoundGetter = null,
            TryGetter<T>? lowerBoundGetter = null,
            TryGetter<T>? moduloGetter = null) 
        {

            Enabled = enabled;
            FormatString = formatString;

            MaxValueGetter = upperBoundGetter;
            MinValueGetter = lowerBoundGetter;
            ModuloGetter = moduloGetter;
        }

        public Guid TypeId => NumericTextBoxVerifier.TypeId;

        public bool Enabled { get; set; }

        public Control? Parent { get; set; }
        public string FormatString { get; set; }

        public T? MaxValue { get; set; }
        public T? MinValue { get; set; }
        public T? Modulus { get; set; }

        public TryGetter<T>? MaxValueGetter { get; set; }
        public TryGetter<T>? MinValueGetter { get; set; }
        public TryGetter<T>? ModuloGetter { get; set; }

        public bool Verify(in (bool couldParse, T parsedValue) tryParseResult)
        {
            bool isValid = true;

            _errorBuilder.Clear();
                     
            if(tryParseResult.couldParse) 
            {
                T? upperBound, lowerBound, modulus;

                if (MaxValueGetter?.Invoke(out T ub) ?? false)
                    upperBound = ub;
                else if (MaxValue != null)
                    upperBound = MaxValue;
                else
                    upperBound = null;


                if (MinValueGetter?.Invoke(out T lb) ?? false)
                    lowerBound = lb;
                else if (MinValue != null)
                    lowerBound = MinValue;
                else
                    lowerBound = null;


                if (ModuloGetter?.Invoke(out T mod) ?? false)
                    modulus = mod;
                else if (Modulus != null)
                    modulus = Modulus;
                else
                    modulus = null;


                if((upperBound != null && tryParseResult.parsedValue > upperBound) |
                    (lowerBound != null && tryParseResult.parsedValue < lowerBound) |
                    (modulus != null && tryParseResult.parsedValue % modulus != T.AdditiveIdentity))
                {
                    string lowerBoundText = lowerBound.HasValue? string.Format($"{{0:{FormatString}}}", lowerBound.Value) : "-infinity";
                    string upperBoundText = upperBound.HasValue? string.Format($"{{0:{FormatString}}}", upperBound.Value) : "infinity";

                    isValid = false;
                    _errorBuilder.AppendLine($"Value must be between {lowerBoundText} and {upperBoundText} (inclusive)");

                    if (modulus!= null)
                    {
                        _errorBuilder.AppendLine(string.Format($"Value must be divisible by {{0:{FormatString}}}", modulus));
                    }
                }
            }
            else
            {
                isValid = false;
            }

            string errorText = _errorBuilder.ToString();
            if (NumericTextBoxVerifier.OutsideNumericRangeProvider != null && Parent != null)
            {
                NumericTextBoxVerifier.OutsideNumericRangeProvider.SetErrorWithInterface(Parent, errorText);
            }

            return isValid;
        }
    }
}
