using Honeycomb.UI.StronglyTypedControls;
using HoneyComb.UI.BaseComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.StronglyTypedControls.CompositeControls
{
    public abstract class FactorHost<TNumericControlHost, TControl, T>: ContainerControl, IInitializable
        where TNumericControlHost: NumericControlHost<TControl, T>
        where TControl : Control, new()
        where T: struct, INumber<T>
    {


        private Label? _label;
        private TNumericControlHost? _factorBox;

        [MemberNotNullWhen(
            true, 
            nameof(Label), 
            nameof(FactorBox))]
        public bool Initialized => Label!=null && FactorBox!=null;

        [MemberNotNull(nameof(Label_XPos))]
        public Label? Label { 
            get => _label;
            set
            {
                //Remove event handlers from old label
                if(_label != null)
                {
                    _label.LocationChanged -= Label_LocationChanged;
                    _label.SizeChanged -= Label_SizeChanged;  
                    _label.MarginChanged -= Label_MarginChanged;

                }

                _label = value;

                //Staple event handlers to new label
                if(_label != null)
                {
                    _label.LocationChanged += Label_LocationChanged;
                    _label.SizeChanged += Label_SizeChanged;
                    _label.MarginChanged += Label_MarginChanged;                  
                }
            }
        }

        public TNumericControlHost? FactorBox { get; set; }

        public override Font Font { 
            get => base.Font;
            set
            {
                base.Font = value;
                if (Initialized)
                {
                    Label.Font = value;
                    FactorBox.Font = value;
                }
            }
        }


        protected virtual void CalculateHeights()
        {

        }

        protected virtual void AutoCalculateSize()
        {
            if (Initialized)
            {
                int width, height;
                int maxWidth = 0;
                int maxHeight = 0;

                foreach (var control in this.Controls.OfType<Control>()
                    .Where(c=>c.Visible && c!= this))
                {
                    width = control.Width + control.Margin.Horizontal + this.Padding.Horizontal;
                    height = control.Height + control.Margin.Vertical + this.Padding.Vertical;

                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }

                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                }

                if (maxWidth > 0 && maxHeight > 0)
                {
                    this.Size = new(maxWidth, maxHeight);
                }
            }
        }
        protected virtual int Label_XPos => this.Padding.Left + Label.Margin.Left;
        protected virtual int FactorBox_XPos => Label.Bounds.Right + Label.Margin.Right + FactorBox.Margin.Left;

        protected virtual void FactorBox_MarginChanged(object? sender, EventArgs e)
        {
            if (Initialized)
            {
                FactorBox.Location = new(FactorBox_XPos, Label.Location.Y);
            }
        }

        protected virtual void Label_SizeChanged(object? sender, EventArgs e)
        {
            if (Initialized)
            {
                FactorBox.Location = new(FactorBox_XPos, FactorBox.Location.Y);
            }
        }

        protected virtual void Label_LocationChanged(object? sender, EventArgs e)
        {
            if (Initialized)
            {
                FactorBox.Location = new(FactorBox_XPos, Label.Location.Y);
            }
        }
       
        protected virtual void Label_MarginChanged(object? sender, EventArgs e)
        {
            if (Initialized)
            {
                Label.Location = new(Label_XPos, Label.Location.Y);
            }
        }


        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            if (Initialized && Label.Location.X != Label_XPos)
            {
                Label.Location = new(Label_XPos, Label.Location.Y);
            }
        }







    }
}
