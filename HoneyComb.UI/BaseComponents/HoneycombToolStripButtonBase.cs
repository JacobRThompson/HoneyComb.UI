using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


using System.Windows.Forms.VisualStyles;
using Honeycomb.UI.Interfaces;

namespace Honeycomb.UI.BaseComponents
{
    public partial class HoneycombToolStripButtonBase : UserControl, IPinnableUIElement, IHoverable, IHighlightableText
    {
        const int ICON_DEFAULT_SIZE = 15;

        private int _iconMargin = 1;
        protected bool _highlighted = false;
        protected Color _defaultForeColor = SystemColors.MenuText;
        protected Color _defaultBackColor = SystemColors.MenuBar;
        protected Color _highlightedForeColor = SystemColors.HighlightText;
        protected Color _highlightedBackColor = SystemColors.MenuHighlight;

        protected Font _defaultFont = (new FontConverter().ConvertFromString("Segoe UI, 9") as Font)!;
        protected Font _highlightedFont = (new FontConverter().ConvertFromString("Segoe UI, 9") as Font)!;

        private bool _showIcons = true;
        private PushButtonState _buttonState = PushButtonState.Normal;

        private bool _checked = false;

        public HoneycombToolStripButtonBase()
        {
            InitializeComponent();

            label.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            label.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            label.MouseDown += (object? sender, MouseEventArgs e) => OnMouseDown(e);
            label.MouseUp += (object? sender, MouseEventArgs e) => OnMouseUp(e); ;
            label.Click += (object? sender, EventArgs e) => OnClick(e);

            flowLayoutPanel1.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            flowLayoutPanel1.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            flowLayoutPanel1.MouseDown += (object? sender, MouseEventArgs e) => OnMouseDown(e);
            flowLayoutPanel1.MouseUp += (object? sender, MouseEventArgs e) => OnMouseUp(e);
            flowLayoutPanel1.Click += (object? sender, EventArgs e) => OnClick(e);

            PinToggle.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            PinToggle.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            PinToggle.CheckedChanged += (object? sender, EventArgs e) => OnPinnedChanged(e);

            CloseButton.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            CloseButton.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public event EventHandler? PinnedChanged;
        public event EventHandler? CheckedChanged;
        public event EventHandler? HighlightedChanged;


        [DefaultValue(true)]
        public bool ShowIcons
        {
            get => _showIcons;
            set
            {
                if (_showIcons != value)
                {
                    _showIcons = value;

                    SuspendLayout();
                    PinToggle.Visible = value;
                    CloseButton.Visible = value;
                    ResumeLayout();
                }
            }
        }

        [DefaultValue(1)]
        public int IconMargin
        {
            get => _iconMargin;
            set
            {
                if (_iconMargin != value)
                {
                    _iconMargin = value;
                    SuspendLayout();
                    PinToggle.Size = new Size(ICON_DEFAULT_SIZE - 2 * _iconMargin, ICON_DEFAULT_SIZE - 2 * _iconMargin);
                    PinToggle.Margin = new(0, _iconMargin + 3, _iconMargin, _iconMargin + 3);

                    CloseButton.Size = new Size(ICON_DEFAULT_SIZE - 2 * _iconMargin, ICON_DEFAULT_SIZE - 2 * _iconMargin);
                    CloseButton.Margin = new(3, _iconMargin + 3, _iconMargin, _iconMargin + 3);
                    ResumeLayout();
                }
            }
        }

        [DefaultValue(true)]
        public virtual bool CheckOnClick { get; set; } = true;

        [DefaultValue(false)]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    OnCheckedChanged(EventArgs.Empty);
                    Invalidate();
                }
            }
        }


        [DefaultValue(PushButtonState.Normal)]
        public PushButtonState ButtonState
        {
            get => _buttonState;
            set
            {
                _buttonState = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public override Color ForeColor => base.ForeColor;

        [Browsable(false)]
        public override Color BackColor => base.BackColor;

        [Browsable(false)]
        public override Font Font => base.Font;
       
        public override string Text
        {
            get => label.Text;
            set
            {
                base.Text = value;
                label.Text = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), "Segoe UI, 9")]  
        public new Font DefaultFont
        {
            get => _defaultFont;
            set => (this as IHighlightableText).SetDefaultFont(ref _defaultFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "MenuText")]
        public new Color DefaultForeColor
        {
            get => _defaultForeColor;
            set
            {
                (this as IHighlightableText).SetDefaultForeColor(ref _defaultForeColor, value);
                PinToggle.DefaultForeColor = value;
                CloseButton.DefaultForeColor = value;

            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "MenuBar")]
        public new Color DefaultBackColor
        {
            get => _defaultBackColor;
            set
            {
                (this as IHighlightableText).SetDefaultBackColor(ref _defaultBackColor, value);

            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        public Font HighlightedFont
        {
            get => _highlightedFont;
            set => (this as IHighlightableText).SetHighlightedFont(ref _highlightedFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "HighlightText")]
        public Color HighlightedForeColor
        {
            get => _highlightedForeColor;
            set
            {
                (this as IHighlightableText).SetHighlightedForeColor(ref _highlightedForeColor, value);
                PinToggle.HighlightedForeColor = value;
                CloseButton.HighlightedForeColor = value;

            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "MenuHighlight")]
        public Color HighlightedBackColor
        {
            get => _highlightedBackColor;
            set
            {
                (this as IHighlightableText).SetHighlightedBackColor(ref _highlightedBackColor, value);
                //PinToggle.HighlightedBackColor = value;
                //CloseButton.HighlightedBackColor = value;
                Invalidate();
            }

        }

        [DefaultValue(false)]
        public bool Pinned
        {
            get => PinToggle.Checked;
            set => PinToggle.Checked = value;
        }

        [DefaultValue(true)]
        public new bool Visible
        {
            get => base.Visible;
            set
            {
                //Do nothing if we are trying to hide control while it is pinned
                if (!value & Pinned) { }
                else
                {
                    base.Visible = value;
                    OnVisibleChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(false)]
        public bool Highlighted
        {
            get => _highlighted;
            set
            {
                SuspendLayout();
                (this as IHighlightable).SetHighlighted(ref  _highlighted, value);
                PinToggle.Highlighted = value;
                CloseButton.Highlighted = value;

                OnHighlightedChanged(EventArgs.Empty);
                ResumeLayout();
            }
        }

        [DefaultValue(0.33f)]
        public float HotOpacity { get; set; } = 0.33f;

        [DefaultValue(typeof(Color), "181, 215, 243")]
        public Color HotBackColor { get; set; } = ProfessionalColors.ButtonSelectedHighlight;

        [DefaultValue(typeof(Color), "126, 186, 234")]
        public Color PressedBackColor { get; set; } = ProfessionalColors.ButtonPressedHighlight;

        public void SetFont(Font value) => Font = value;
        public void SetForeColor(Color value) => base.ForeColor = value;
        public void SetBackColor(Color value) => base.BackColor = value;

        private void CloseButton_Click(object sender, EventArgs e) => this.Hide();

        public new void Hide() => base.Visible = false;

        protected virtual void OnHighlightedChanged(EventArgs e)
        {
            label.Highlighted = this.Highlighted;
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.HasMouse())
            {
                base.OnMouseLeave(e);
                ButtonState = PushButtonState.Normal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.HasMouse())
            {
                base.OnMouseEnter(e);
                ButtonState = PushButtonState.Hot;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ButtonState = PushButtonState.Hot;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ButtonState = PushButtonState.Pressed;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (CheckOnClick)
                Checked = !Checked;
        }

        protected virtual void OnPinnedChanged(EventArgs e)
        {
            PinnedChanged?.Invoke(this, e);
            Invalidate();
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }


     
        protected override void OnPaintBackground(PaintEventArgs e)
        {

            Color backgroundColor;
            Color outlineColor;

            switch (ButtonState)
            {
                case PushButtonState.Hot:
                    if (Highlighted)
                    {
                        backgroundColor = Colors.Lerp(HighlightedBackColor, Parent?.BackColor ?? Color.Transparent, HotOpacity);
                        outlineColor = this.Checked ?
                            Colors.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            backgroundColor;
                    }
                    else
                    {
                        backgroundColor = HotBackColor;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonSelectedHighlightBorder;
                    }
                    break;

                case PushButtonState.Pressed:
                    if (Highlighted)
                    {
                        backgroundColor = Colors.Lerp(HighlightedBackColor, Parent?.BackColor ?? Color.Transparent, 1f - HotOpacity);
                        outlineColor = SystemColors.MenuHighlight;
                    }
                    else
                    {
                        backgroundColor = PressedBackColor;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonPressedBorder;
                    }
                    break;

                default:
                    if (Highlighted)
                    {
                        backgroundColor = HighlightedBackColor;
                        outlineColor = this.Checked ?
                            Colors.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            SystemColors.InactiveBorder;
                    }
                    else
                    {
                        backgroundColor = DefaultBackColor;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            SystemColors.InactiveBorder;
                    }
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.ClipRectangle);

            e.Graphics.DrawRectangle(
                new Pen(outlineColor),
                new(Point.Empty, this.Size - new Size(1, 1)));

        }

    }
}
