using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls
{
    /*
    public abstract class HighlightableValuedControl<TControl, T> : ValuedControlHost<TControl, T>, IHighlightableText
        where TControl : Control, new()
        where T : struct, IEquatable<T>
    {

        protected bool _highlighted = IHighlightable.HIGHLIGHTED_;

        protected Font _defaultFont = (Font) new FontConverter().ConvertFromString(IHighlightableText.DEFAULT_FONT)!;
        protected Font _highlightedFont = (Font) new FontConverter().ConvertFromString(IHighlightableText.HIGHLIGHTED_FONT)!;

        protected Color _defaultBackColor = (Color) new ColorConverter().ConvertFromString(IHighlightable.DEFAULT_BACK_COLOR)!;
        protected Color _defaultForeColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.DEFAULT_FORE_COLOR)!;
        protected Color _highlightedBackColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.HIGHLIGHTED_BACK_COLOR)!;
        protected Color _highlightedForeColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.HIGHLIGHTED_FORE_COLOR)!;

        public event EventHandler HighlightedChanged = delegate { };

        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool Highlighted
        {
            get => _highlighted;
            set
            {
                (this as IHighlightableText).SetHighlighted(ref _highlighted, value);
                OnHighlightChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.DEFAULT_FONT)]
        public new Font DefaultFont
        {
            get => _defaultFont;
            set => (this as IHighlightableText).SetDefaultFont(ref _defaultFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.HIGHLIGHTED_FONT)]
        public Font HighlightedFont
        {
            get => _highlightedFont;
            set => (this as IHighlightableText).SetHighlightedFont(ref _highlightedFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_FORE_COLOR)]
        public new Color DefaultForeColor
        {
            get => _defaultForeColor;
            set => (this as IHighlightableText).SetDefaultForeColor(ref _defaultForeColor, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_BACK_COLOR)]
        public new Color DefaultBackColor
        {
            get => _defaultBackColor;
            set => (this as IHighlightableText).SetDefaultBackColor(ref _defaultBackColor, value);
        }


        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_FORE_COLOR)]
        public Color HighlightedForeColor
        {
            get => _highlightedForeColor;
            set => (this as IHighlightableText).SetHighlightedForeColor(ref _highlightedForeColor, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_BACK_COLOR)]
        public Color HighlightedBackColor
        {
            get => _highlightedBackColor;
            set => (this as IHighlightableText).SetHighlightedBackColor(ref _highlightedBackColor, value);
        }

       


       

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }


    }
    */
}
