using System.Windows.Forms.Design;

namespace Honeycomb.UI.ToolStripControls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripMovableButton : ToolStripButton
    {

        const int SELF_EDGE_DISTANCE = 10;

        private bool _isDragging = false;
        private bool _isMovable = false;

        public ToolStripMovableButton() : base()
        {
            CheckOnClick = true;
        }

        private bool IsMovable
        {
            get => _isMovable;
            set
            {
                _isMovable = value;
                if (IsDragging) { IsDragging = false; }
            }
        }
        public bool IsDragging
        {
            get => _isDragging;
            set
            {
                _isDragging = value;
                if (value)
                {
                    BackColor = Color.Cyan;
                }
                else
                {
                    BackColor = SystemColors.Control;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsMovable = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsMovable = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (IsMovable)
            {
                if (!IsDragging) { IsDragging = true; }

                Point mousePosition = GetCurrentParent().PointToClient(Cursor.Position);
                if (mousePosition.Y > Bounds.Top && mousePosition.Y < Bounds.Bottom)
                {
                    ToolStrip parent = Owner;
                    int currentIndex = parent.Items.IndexOf(this);

                    if (mousePosition.X < Bounds.Left + SELF_EDGE_DISTANCE)
                    {
                        parent.Items.Remove(this);
                        parent.Items.Insert(Math.Max(currentIndex - 1, 0), this);
                    }
                    else if (mousePosition.X > Bounds.Right - SELF_EDGE_DISTANCE)
                    {
                        parent.Items.Remove(this);
                        parent.Items.Insert(Math.Min(currentIndex + 1, parent.Items.Count), this);
                    }
                }
                else
                {
                    IsMovable = false;
                    if (IsDragging) { IsDragging = false; }
                }
            }
        }
    }
}