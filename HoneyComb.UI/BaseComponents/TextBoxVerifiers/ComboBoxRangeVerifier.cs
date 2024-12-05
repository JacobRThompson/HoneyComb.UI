using Honeycomb.UI.StronglyTypedControls.ControlHost;
using HoneyComb.UI.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxVerifiers
{

    public static class ComboBoxRangeVerifier
    {
        public const bool AUTO_CALCULATE_VALID_RANGE_DEFAULT = true;
        public static ErrorProvider? ComboboxRangeProvider { get; set; }
        public readonly static Guid TypeId = Guid.NewGuid();
    }


    /// <summary>
    /// Verifier that checks if a value passed to a valued comboBox lies within the continuous range defined by the comboBox's largest and smallest item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ComboBoxRangeVerifier<TControl, T> : IControlVerifier<T>
        where TControl : ComboBox, new()
        where T : struct, IEquatable<T>, IComparisonOperators<T, T, bool>, IMinMaxValue<T>
    {

        public ComboBoxRangeVerifier(bool enabled, string formatString = "N")
        {
            Enabled = enabled;
            FormatString = formatString;          
        }

        public Guid TypeId => ComboBoxRangeVerifier.TypeId;
        public bool Enabled { get; set; }

        public ComboBoxHostExtension<TControl, T>? ComboBoxExtension {get; set;}
        public Control? Parent { get; set; }

        public string FormatString { get; set; }


        public bool Verify(in (bool couldParse, T parsedValue) result)
        {
            string errorText = string.Empty;
            bool isValid = true;
            if (ComboBoxExtension!= null && result.couldParse)
            {
                (T min, T max) range = ComboBoxExtension.RawValues.Range();

                if (result.parsedValue < range.min || result.parsedValue > range.max) 
                { 
                    isValid = false;
                    errorText = string.Format($"Value outside dropdown range ({{0:{FormatString}}} to {{1:{FormatString}}})", range.min, range.max);
                }  
            }
            else
            {
                isValid = false;
            }

            if(ComboBoxRangeVerifier.ComboboxRangeProvider != null && Parent != null &&
               ComboBoxRangeVerifier.ComboboxRangeProvider.GetError(Parent) != errorText)
            {
                ComboBoxRangeVerifier.ComboboxRangeProvider.SetErrorWithInterface(Parent, errorText);
            }

            return isValid;

        }

    }
}
