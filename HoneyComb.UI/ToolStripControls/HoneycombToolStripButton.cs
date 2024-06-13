using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using Honeycomb.UI.BaseComponents;

namespace Honeycomb.UI.ToolStripControls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class HoneycombToolStripButton : ToolStripControlHost, IPinnableUIElement, IHighlightable
    {

        protected readonly HoneycombToolStripButtonBase _control;

        public HoneycombToolStripButton() : base(new HoneycombToolStripButtonBase())
        {
            _control = (HoneycombToolStripButtonBase)Control;
            _control.CheckedChanged += (sender, e) => OnCheckedChanged(e);
            _control.PinnedChanged += (sender, e) => OnPinnedChanged(e);
            _control.VisibleChanged += (sender, e) => OnVisibleChanged(e);
            _control.MouseDown += (sender, e) => OnMouseDown(e);
            _control.MouseUp += (sender, e) => OnMouseUp(e);
            _control.MouseEnter += (sender, e) => OnMouseEnter(e);
            _control.MouseLeave += (sender, e) => OnMouseLeave(e);

            Margin = new(0);

        }

        public event EventHandler? PinnedChanged;
        public event EventHandler? CheckedChanged;
        public event EventHandler? HighlightedChanged;

        public void SuspendLayout() => _control.SuspendLayout();
        public void ResumeLayout() => _control.ResumeLayout();

        public virtual Font DefaultFont { get; set; } = new("Segoe UI", 9F, FontStyle.Regular);

        public virtual bool Highlighted
        {
            get => _control.Highlighted;
            set
            {
                _control.Highlighted = value;
                OnHighlighedChanged(EventArgs.Empty);
            }
        }

        public virtual PushButtonState ButtonState
        {
            get => _control.ButtonState;
            set => _control.ButtonState = value;
        }

  
        public virtual bool CheckOnClick 
        { 
            get => _control.CheckOnClick; 
            set => _control.CheckOnClick = value; 
        }

        public void SetForeColor(Color value) => base.ForeColor = value;
        public void SetBackColor(Color value) => base.BackColor = value;

        public override Color ForeColor => base.ForeColor;
        public override Color BackColor => base.BackColor;


        public  Color DefaultForeColor
        {
            get => _control.DefaultForeColor;
            set => _control.DefaultForeColor = value;
        }
        public  Color DefaultBackColor
        {
            get => _control.DefaultBackColor;
            set => _control.DefaultBackColor = value;
        }

        public Color HighlightedForeColor
        {
            get => _control.HighlightedForeColor;
            set => _control.HighlightedForeColor = value;
        }

        public Color HighlightedBackColor
        {
            get => _control.HighlightedBackColor;
            set => _control.HighlightedBackColor = value;
        }

        [DefaultValue(1)]
        public int IconMargin
        {
            get => _control.IconMargin;
            set => _control.IconMargin = value;
        }

        [DefaultValue(true)]
        public bool ShowIcons
        {
            get => _control.ShowIcons;
            set => _control.ShowIcons = value;
        }

        [DefaultValue(false)]
        public bool Pinned
        {
            get => _control.Pinned;
            set => _control.Pinned = value;  //Note: when we set this, _control's event handler will call OnPinnedChanged(e)
        }

        [DefaultValue(false)]
        public bool Checked
        {
            get => _control.Checked;
            set => _control.Checked = value; //Note: when we set this, _control's event handler will call OnCheckedChanged(e)
        }

        public new bool Visible
        {
            get => _control.Visible;
            set => _control.Visible = value; //Note: when we set this, _control's event handler will call OnVisibleChanged(e)
        }

        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);
        protected virtual void OnPinnedChanged(EventArgs e) => PinnedChanged?.Invoke(this, e);
        protected virtual void OnHighlighedChanged(EventArgs e) => HighlightedChanged?.Invoke(this, e);

       
        public void Hide() => _control.Hide();

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
