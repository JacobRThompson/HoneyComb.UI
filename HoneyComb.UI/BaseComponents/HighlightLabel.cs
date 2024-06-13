using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    public class HighlightLabel : Label, IHighlightableText
    {

        protected bool _highlighted = false;
        protected Color _defaultForeColor;
        protected Color _defaultBackColor;
        protected Color _highlightedForeColor;
        protected Color _highlightedBackColor;

        protected Font _defaultFont = (new FontConverter().ConvertFromString("Segoe UI, 9") as Font)!;
        protected Font _highlightedFont = (new FontConverter().ConvertFromString("Segoe UI, 9") as Font)!;


        public event EventHandler? HighlightedChanged;


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

        [Browsable(false)]
        public override Font Font => base.Font;

        [Browsable(false)]
        public override Color ForeColor => base.ForeColor;

        [Browsable(false)]
        public override Color BackColor => base.BackColor;

        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        [Category("Appearance")]
        public new Font DefaultFont
        {
            get => _defaultFont;
            set => (this as IHighlightableText).SetDefaultFont(ref _defaultFont, value);
        }

        
        [Category("Appearance")]
        public new Color DefaultForeColor 
        { 
            get => _defaultForeColor; 
            set => (this as IHighlightableText).SetDefaultForeColor(ref _defaultForeColor, value); 
        }

        [Category("Appearance")]
        public new Color DefaultBackColor 
        { 
            get => _defaultBackColor; 
            set => (this as IHighlightableText).SetDefaultBackColor(ref _defaultBackColor, value); 
        }

        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        [Category("Appearance")]
        public Font HighlightedFont
        {
            get => _highlightedFont;
            set => (this as IHighlightableText).SetHighlightedFont(ref _highlightedFont, value);
        }

        [Category("Appearance")]
        public Color HighlightedForeColor 
        { 
            get => _highlightedForeColor; 
            set => (this as IHighlightableText).SetHighlightedForeColor(ref _highlightedForeColor, value); 
        }

        [Category("Appearance")]
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

        public void SetFont(Font value) => base.Font = value;
        public void SetForeColor(Color value) => base.ForeColor = value;
        public void SetBackColor(Color value) => base.BackColor = value;
    }
}
