using Honeycomb.UI.StronglyTypedControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.StronglyTypedControls.CompositeControls
{
    public abstract class FactorHost<TNumericControlHost, TControl, T>: ContainerControl
        where TNumericControlHost: NumericControlHost<TControl, T>
        where TControl : Control, new()
        where T: struct, INumber<T>
    {

        public FactorHost(TNumericControlHost factorBox) 
        { 
            FactorBox = factorBox;
        }

        public Label Label { get; set; } = new();


        public bool ShowFactor { get; set; }

        public override string Text 
        { 
            get => Label.Text; 
            set => Label.Text = value; 
        }

        public TNumericControlHost FactorBox { get; }

        public void SetFactor(in T factor) => FactorBox.SetValue(factor);
        public bool TryGetFactor(out T factor) => FactorBox.TryGetValue(out factor);


    }
}
