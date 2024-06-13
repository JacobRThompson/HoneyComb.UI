using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.IconButtons
{
    public abstract class IconControl: PictureBox, IHoverable
    {
        protected const string IMAGE_CATEGORY = "Image";

        private PushButtonState _buttonState = PushButtonState.Normal;
        protected bool _highlighted = false;
        protected Color _defaultForeColor;
        protected Color _defaultBackColor;
        protected Color _highlightedForeColor;
        protected Color _highlightedBackColor;

        public IconControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);  
        }


        public event EventHandler? HighlightedChanged;
        public event EventHandler? PushButtonStateChanged;

        [Category("Appearance")]
        public bool Highlighted
        {
            get => _highlighted;
            set
            {
                (this as IHighlightable).SetHighlighted(ref _highlighted, value);
                OnHighlightChanged(EventArgs.Empty);
            }
        }
      
        public virtual PushButtonState ButtonState
        {
            get => _buttonState;
            set
            {
                if (value != ButtonState)
                {
                    _buttonState = value;
                    Invalidate();
                   
                }
            }
        }

        public float HotOpacity { get; set; } = 0.33f;
        public Color HotBackColor { get; set; } = ProfessionalColors.ButtonSelectedHighlight;
        public Color PressedBackColor { get; set; } = ProfessionalColors.ButtonPressedHighlight;


        public void SetForeColor(Color value) => base.ForeColor = value;
        public void SetBackColor(Color value) => base.BackColor = value;

        public override Color ForeColor => base.ForeColor;
        public override Color BackColor => base.BackColor;

        public new Color DefaultForeColor
        {
            get => _defaultForeColor;
            set => (this as IHighlightable).SetDefaultForeColor(ref _defaultForeColor, value);
        }
        public new Color DefaultBackColor
        {
            get => _defaultBackColor;
            set => (this as IHighlightable).SetDefaultBackColor(ref _defaultBackColor, value);
        }

        public Color HighlightedForeColor
        {
            get => _highlightedForeColor;
            set => (this as IHighlightable).SetHighlightedForeColor(ref _highlightedForeColor, value);
        }
        public Color HighlightedBackColor
        {
            get => _highlightedBackColor;
            set => (this as IHighlightable).SetHighlightedBackColor(ref _highlightedBackColor, value);
        }


        protected virtual void OnPushButtonStateChanged(EventArgs e)
        {
            Invalidate();
            PushButtonStateChanged?.Invoke(this, e);
        }

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            ButtonState = PushButtonState.Hot;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            ButtonState = PushButtonState.Pressed;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ButtonState = PushButtonState.Hot;
            base.OnMouseUp(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            ButtonState = PushButtonState.Normal;
            base.OnMouseLeave(e);
        }

        
    }
}

