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


namespace Honeycomb.UI.StronglyTypedControls
{
    public abstract class NumericControlHost<TControl, T> : ValuedControlHost<TControl, T>
        where TControl : Control, new()
        where T : struct, INumber<T>
    {
        public NumericControlHost(Dictionary<Guid, IControlVerifier<T>>? miscVerifiers = null) : base(
            new NumericControlParser<T>(),
            new Dictionary<Guid, IControlVerifier<T>>()
            {
                {NumericControlVerifier.TypeId, new NumericControlVerifier<T>(enabled: true) }
            }
            .Concat(miscVerifiers ?? new Dictionary <Guid, IControlVerifier<T>>()) 
            .ToDictionary(x => x.Key,x => x.Value))
        {}

        #region Numeric Verifier Members
        [DefaultValue(null)]
        public T? MinValue 
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MinValue; 
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MinValue = value; 
        }

        [DefaultValue(null)]
        public T? MaxValue
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MaxValue;
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MaxValue = value;
        }

        [DefaultValue(null)]
        public T? Modulus 
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.Modulus;
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.Modulus = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? MinValueGetter
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MinValueGetter;
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MinValueGetter = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? MaxValueGetter
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MaxValueGetter;
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.MaxValueGetter = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TryGetter<T>? ModuloGetter
        {
            get => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.ModuloGetter;
            set => (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.ModuloGetter = value;
        }

        #endregion


        [DefaultValue(NumericControlParser.NUMERIC_STYLE_DEFAULT)]
        public NumberStyles NumericStyle
        {
            get => (Parser as NumericControlParser<T>)!.NumericStyle;
            set => (Parser as NumericControlParser<T>)!.NumericStyle = value;
        }

        [DefaultValue(NumericControlParser.FORMAT_STRING_DEFAULT)]
        public virtual string FormatString 
        {
            get => (Parser as NumericControlParser<T>)!.FormatString;
            set
            {
                (Parser as NumericControlParser<T>)!.FormatString = value;
                (Verifiers[NumericControlVerifier.TypeId] as NumericControlVerifier<T>)!.FormatString = value;
            }
        } 

       
        
    }
}
