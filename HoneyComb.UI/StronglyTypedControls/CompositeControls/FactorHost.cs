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
    /// <summary>
    /// A composite control that contains a label and a numeric control
    /// </summary>
    public abstract class FactorHost<TNumericControlHost, TControl, T>: ContainerControl, IInitializable
        where TNumericControlHost: NumericControlHost<TControl, T>
        where TControl : Control, new()
        where T: struct, INumber<T>
    {


        private Label? _label;
        private TNumericControlHost? _factorBox;

        [MemberNotNullWhen(true, nameof(Label), nameof(FactorBox))]
        public bool Initialized => Label!=null && FactorBox!=null;

      
        public Label? Label { 
            get => _label;
            set
            {
                _label = value;
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

        protected override void OnLayout(LayoutEventArgs e)
        {
            SuspendLayout();
            if (Initialized)
            {
                //---------------------
                //1st loop: set size of control

                int minHeight;
                int newHeight = 0;
                int newWidth = this.Padding.Horizontal;

                foreach (var child in this.Controls.OfType<Control>()
                    .Where(c => c.Visible && c != this))
                {
                    minHeight = child.Height + child.Margin.Vertical + this.Padding.Vertical;
                    if (minHeight > newHeight)
                    {
                        newHeight = minHeight;
                    }
                 
                    newWidth += child.Width + child.Margin.Horizontal;
                }

                if (newWidth > 0 && newHeight > 0)
                {
                    this.Size = new(newWidth, newHeight);
                }

                int childY;
                int childX = this.Padding.Left;
                //---------------------
                //2nd loop: set location of children
                foreach (var child in this.Controls.OfType<Control>()
                   .Where(c => c.Visible && c != this))
                {
                    childY = 
                        this.Padding.Top + 
                        (this.Height-this.Padding.Vertical-child.Height-child.Margin.Vertical)/2+
                        child.Margin.Top;
                    
                    childX += child.Margin.Left;

                    //Set position
                    child.Location = new(childX, childY);

                    //Add rest of child width
                    childX += child.Width + child.Margin.Right;
                }

            }
            ResumeLayout();
            base.OnLayout(e);
        }
    }
}
