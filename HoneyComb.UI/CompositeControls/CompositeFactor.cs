using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Honeycomb.UI.StronglyTypedControls;
using Honeycomb.UI.Interfaces;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace Honeycomb.UI.CompositeControls
{
    /*
    public class CompositeFactor<TFactorBox, TFactorBoxRoot, T> : UserControl, IHighlightableText
        where TFactorBox : NumericControlHost<TFactorBoxRoot, T>, IHighlightable, IHighlightableText, new()
        where TFactorBoxRoot : Control, new()
        where T : struct, INumber<T>
    {

        //public const int FACTORBOX_WIDTH = 45;
        public const int LABEL_WIDTH = 120;
        public const int FACTORBOX_WIDTH = 90;
        public const int SUBCONTROL_HEIGHT = 23;

        public const string FACTORBOX_MARGIN = "0,0,0,0";
        public const string LABEL_FONT = "Segoe UI, 9pt";
        public const string LABEL_MARGIN = "0,0,0,2";

        public CompositeFactor() 
        {
            (this as IHighlightable).DefaultBackColor = SystemColors.ButtonFace;
            Label.AutoSize = false;
            Label.ImageAlign = ContentAlignment.MiddleRight;
            Label.Margin = (Padding) new PaddingConverter().ConvertFromString(LABEL_MARGIN)!;

            FactorBox.Margin = (Padding)new PaddingConverter().ConvertFromString(FACTORBOX_MARGIN)!;
            FactorBox.Selectable = false;
        }


        public event EventHandler HighlightedChanged = delegate { };

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TFactorBox FactorBox { get; } = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Windows.Forms.Label Label { get; } = new();


        [DefaultValue(AutoValidate.EnableAllowFocusChange)]
        public override AutoValidate AutoValidate 
        { 
            get => base.AutoValidate; 
            set => base.AutoValidate = value; 
        }

        #region Label Overrides
        
        [Category("Appearance")]
        [DefaultValue(LABEL_FONT)]
        public override Font Font
        {
            get => Label.Font;
            set => Label.Font = value;
        }

        public override string Text
        {
            get => Label.Text;
            set => Label.Text = value;
        }

        public override Color BackColor
        {
            get => Label.BackColor;
            set => Label.BackColor = value;
        }


        public override Color ForeColor
        {
            get => Label.ForeColor;
            set => Label.ForeColor = value;
        }
        #endregion

        #region FactorBox Overrides

        [Category("Appearance")]
        [DefaultValue(IHighlightable.HIGHLIGHTED_)]
        public bool Highlighted 
        { 
            get => FactorBox.Highlighted; 
            set
            {
                FactorBox.Highlighted = value;
                OnHighlightChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.DEFAULT_FONT)]
        new public Font DefaultFont
        {
            get => (FactorBox as IHighlightableText).DefaultFont;
            set => (FactorBox as IHighlightableText).DefaultFont = value;

        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.HIGHLIGHTED_FONT)]
        public Font HighlightedFont
        {
            get => FactorBox.HighlightedFont;
            set => FactorBox.HighlightedFont = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_BACK_COLOR)]
        Color IHighlightable.DefaultBackColor
        {
            get => (FactorBox as IHighlightable).DefaultBackColor;
            set => (FactorBox as IHighlightable).DefaultBackColor = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_FORE_COLOR)]
        Color IHighlightable.DefaultForeColor 
        { 
            get => (FactorBox as IHighlightable).DefaultForeColor; 
            set => (FactorBox as IHighlightable).DefaultForeColor = value; 
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_BACK_COLOR)]
        public Color HighlightedBackColor
        {
            get => FactorBox.HighlightedBackColor;
            set => FactorBox.HighlightedBackColor = value;
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_FORE_COLOR)]
        public Color HighlightedForeColor
        {
            get => FactorBox.HighlightedForeColor;
            set => FactorBox.HighlightedForeColor = value;
        }

        [Category("Value")]
        [DefaultValue(IAffixed.SUFFIX)]
        public virtual string Suffix { 
            get => FactorBox.Suffix; 
            set => FactorBox.Suffix = value; 
        }

        [Category("Value")]
        [DefaultValue(IAffixed.PREFIX)]
        public virtual string Prefix 
        {
            get => FactorBox.Prefix;
            set => FactorBox.Prefix = value; 
        }

        [Category("Value")]
        [DefaultValue(IValuedControl<T>.IS_EMPTY_MSG)]
        public virtual string IsEmptyMsg 
        {
            get => FactorBox.IsEmptyMsg;
            set => FactorBox.IsEmptyMsg = value; 
        }

        [Category("Value")]
        [DefaultValue(IValuedControl<T>.IS_INVALID_MSG)]
        public virtual string CannotParseMsg 
        { 
            get => FactorBox.InvalidMsg; 
            set => FactorBox.InvalidMsg = value; 
        }


        [Category("Value")]
        [DefaultValue(NumericControlHost<TFactorBoxRoot, T>.FORMAT_STRING)]
        public virtual string FormatString
        {
            get => FactorBox.FormatString;
            set => FactorBox.FormatString = value;
        }


        [Category("Value")]
        [DefaultValue(IValued<T>.NULLABLE)]
        public virtual bool IsNullable 
        {
            get => FactorBox.IsNullable;
            set => FactorBox.IsNullable = value; 
        }

        [Category("Value")]
        [DefaultValue(IRequireableControl.IS_REQUIRED)]
        public virtual bool IsRequired
        {
            get => FactorBox.IsRequired;
            set => FactorBox.IsRequired = value;
        }

        [Category("Value")]
        [DefaultValue(IRequireableControl.IS_REQUIRED_MSG)]
        public virtual string IsRequiredMsg
        {
            get => FactorBox.IsRequiredMsg;
            set => FactorBox.IsRequiredMsg = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsRequiredSatisfied => FactorBox.IsRequiredSatisfied;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsValid => FactorBox.Valid;

        [Browsable(false)]
        public Optioned<T> Value 
        {
            get => FactorBox.UnaffixedResult; 
            set => FactorBox.Result = value; 
        }
        #endregion

        [Category("Layout")]
        [DefaultValue(SUBCONTROL_HEIGHT)]
        public int SubControlHeight
        {
            get => FactorBox.Height;
            set
            {
                FactorBox.Height = value;
                UpdateSubControls();
            }
        }

        [Category("Layout")]
        [DefaultValue(FACTORBOX_WIDTH)]
        public int FactorBoxWidth
        {
            get => FactorBox.Width;
            set
            {
                FactorBox.Width = value;
                UpdateSubControls();
            }
        }

        [Category("Layout")]
        [DefaultValue(LABEL_WIDTH)]
        public int LabelWidth
        {
            get => Label.Width;
            set
            {
                Label.Width = value;
                UpdateSubControls();
            }
        }

        [Category("Layout")]
        [DefaultValue(FACTORBOX_MARGIN)]
        public virtual Padding FactorBoxMargin
        {
            get => FactorBox.Margin;
            set
            {
                FactorBox.Margin = value;
                UpdateSubControls();
            }
        }

        [Category("Layout")]
        [DefaultValue(typeof(Padding), LABEL_MARGIN)]
        public virtual Padding LabelMargin
        {
            get => Label.Margin;
            set
            {
                Label.Margin = value;
                UpdateSubControls();
            }
        }
       
        /// <summary>
        /// The calculated y position to place sub-controls so that they are centered nicely.
        /// </summary>
        /// <remarks>
        /// Note: This does not account for offsets resulting from the margin of individual sub-controls
        /// </remarks>
        protected int SubControlYPos => (Math.Max(SubControlHeight, Height) - SubControlHeight) / 2 + Padding.Bottom;

        protected virtual int MinWidth => FactorBoxXPos + FactorBox.Margin.Right + Padding.Right;
        protected virtual int LabelXPos => Padding.Left + Label.Margin.Left;
        protected virtual int FactorBoxXPos => LabelXPos + Label.Margin.Right + Label.Width + FactorBox.Margin.Right;

        protected virtual void UpdateSubControls()
        {

            Label.Location = new Point(LabelXPos, Padding.Top + Label.Margin.Top);
            Label.Height = Height - Padding.Vertical - Label.Margin.Vertical;

            FactorBox.Location = new Point(FactorBoxXPos, SubControlYPos);

            MinimumSize = new Size(MinWidth, MinimumSize.Height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateSubControls();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            UpdateSubControls();
        }

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            HighlightedChanged?.Invoke(this, e);
        }
    

    }*/
}
