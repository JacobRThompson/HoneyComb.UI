using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.UI.Utils;
using HoneyComb.UI.Utils.Extensions;
namespace HoneyComb.UI.BaseComponents
{
    public partial class MultiSelector : IDisposable
    {

        private readonly HashSet<Control> _selectedControls = [];

        private bool _isSelecting = false;
        private Point _selectionStartPt = default;
        private Rectangle _selectionArea = default;

        public TranslucentPanel _boxPainter = new() { 
            Visible = false, 
            BackColor = SystemColors.Highlight.ToAlpha(64), 
        };

        private bool _isDisposed;
        private Form? _parent;

        public MultiSelector(Form? parent)
        {
            Parent = parent;
        }

        public Form? Parent
        {
            get => _parent;
            set
            {
                if (_parent != null)
                {
                    _parent.MouseDown -= Parent_MouseDown;
                    _parent.MouseMove -= Parent_MouseMove;
                    _parent.MouseUp -= Parent_MouseUp;

                    _parent.Controls.Remove(_boxPainter);
                }

                _parent = value;

                if (value != null)
                {
                    value.MouseDown += Parent_MouseDown;
                    value.MouseMove += Parent_MouseMove;
                    value.MouseUp += Parent_MouseUp;

                    value.Controls.Add(_boxPainter);
                    value.Controls.SetChildIndex(_boxPainter, 0);
                }
            }
        }

        public IEnumerable<Control>SelectedControls => _selectedControls;

        IEnumerable<Control> ControlsWithinSelectionArea 
        {
            get
            {
                if(!IsSelecting || Parent == null ) 
                { 
                    return Enumerable.Empty<Control>(); 
                }
                else
                {
                    return Parent.GetAllChildren(child =>
                        IntersectsSelectedRegion(child) &&
                        child != _boxPainter);
                    
                }              
            }
        }

        bool IntersectsSelectedRegion(Control control)
        {
            var absPainterPosition = _boxPainter.PointToScreen(new(0));
            var absControlPosition = control.PointToScreen(new(0));


            var absPainterBounds = new Rectangle(absPainterPosition, _boxPainter.Size);
            var absControlBounds = new Rectangle(absControlPosition, control.Size);

            return absPainterBounds.IntersectsWith(absControlBounds);
        }

        public Color SelectionColor
        {
            get => _boxPainter.BackColor; 
            set => _boxPainter.BackColor = value;
        }

        private bool IsSelecting
        {
            get => _isSelecting;
            set
            {
                _isSelecting= value;
                _boxPainter.Visible = value;
            }
        }


        private Rectangle SelectionArea
        {
            get => _selectionArea;
            set 
            {
                _selectionArea = value;
                _boxPainter.Location = _selectionArea.Location;
                _boxPainter.Size = _selectionArea.Size;
            }
        }


        void Parent_MouseDown(object? sender, MouseEventArgs e)
        {
            IsSelecting = true;
            _selectionStartPt = e.Location;
            _selectedControls.Clear();
        }

        void Parent_MouseUp(object? sender, MouseEventArgs e)
        {

            foreach (Control c in ControlsWithinSelectionArea)
            {
                c.BackColor = Color.Red;
                _selectedControls.Add(c);
            }

            IsSelecting = false;
        }

        void Parent_MouseMove(object? sender, MouseEventArgs e)
        {
            if (IsSelecting) {

                SelectionArea = new Rectangle(
                    Math.Min(_selectionStartPt.X, e.X),
                    Math.Min(_selectionStartPt.Y, e.Y),
                    Math.Abs(_selectionStartPt.X - e.X),
                    Math.Abs(_selectionStartPt.Y - e.Y));

                //_boxPainter.Invalidate();
            }
        }
                      
        void IDisposable.Dispose()
        {
            if (!_isDisposed)
            {

                if (Parent != null)
                {
                    Parent.MouseDown += Parent_MouseDown;
                    Parent.MouseMove += Parent_MouseMove;
                    Parent.MouseUp += Parent_MouseUp;

                    Parent.Controls.Remove(_boxPainter);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _isDisposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
