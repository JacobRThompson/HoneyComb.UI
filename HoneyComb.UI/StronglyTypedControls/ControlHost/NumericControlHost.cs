using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using Honeycomb.UI.BaseComponents;
using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.UI.BaseComponents.TextBoxParsers;


namespace Honeycomb.UI.StronglyTypedControls
{
    public abstract class NumericControlHost<TControl, T> : ValuedControlHost<TControl, T>
        where TControl : Control, new()
        where T : struct, INumber<T>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tryParseFunction">
        ///     Function that converts a string to the a member of type <typeparamref name="T"/>. Workaround for limitation of current implementation of static interface members.
        /// </param>
        /// <param name="divideBy100Funcion">
        ///     Function that divides a member of type <typeparamref name="T"/> by 100. Workaround for limitation of current implementation of static interface members.
        /// </param>
        /// <param name="miscVerifiers"></param>
        public NumericControlHost(
            TryParseFunction<T> tryParseFunction,
            Func<T, T> divideBy100Funcion,
            Dictionary<Guid, ITextBoxVerifier<T>>? miscVerifiers = null
        ) : base(
            new NumericTextBoxParser<T>(tryParseFunction, divideBy100Funcion),
            new Dictionary<Guid, ITextBoxVerifier<T>>()
            {
                {NumericTextBoxVerifier.TypeId, new NumericTextBoxVerifier<T>(enabled: true) }
            }
            .Concat(miscVerifiers ?? new Dictionary <Guid, ITextBoxVerifier<T>>()) 
            .ToDictionary(x => x.Key,x => x.Value))
        {}

        #region Numeric Verifier Members
        [DefaultValue(null)]
        public T? MinValue 
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MinValue; 
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MinValue = value; 
        }

        [DefaultValue(null)]
        public T? MaxValue
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MaxValue;
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MaxValue = value;
        }

        [DefaultValue(null)]
        public T? Modulus 
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.Modulus;
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.Modulus = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? MinValueGetter
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MinValueGetter;
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MinValueGetter = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? MaxValueGetter
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MaxValueGetter;
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.MaxValueGetter = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? ModuloGetter
        {
            get => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.ModuloGetter;
            set => (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.ModuloGetter = value;
        }

        #endregion


        [DefaultValue(NumericTextBoxParser.NUMERIC_STYLE_DEFAULT)]
        public NumberStyles NumericStyle
        {
            get => (Parser as NumericTextBoxParser<T>)!.NumericStyle;
            set => (Parser as NumericTextBoxParser<T>)!.NumericStyle = value;
        }

        [DefaultValue(NumericTextBoxParser.FORMAT_STRING_DEFAULT)]
        public virtual string FormatString 
        {
            get => (Parser as NumericTextBoxParser<T>)!.FormatString;
            set
            {
                (Parser as NumericTextBoxParser<T>)!.FormatString = value;
                (Verifiers[NumericTextBoxVerifier.TypeId] as NumericTextBoxVerifier<T>)!.FormatString = value;
            }
        } 

       
        
    }
}
