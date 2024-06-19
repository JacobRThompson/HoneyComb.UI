using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyComb.UI.Utils;
using HoneyComb.UI.Utils.Extensions;
namespace HoneyComb.UI.BaseComponents.MultiSelect
{
    public partial class MultiSelector : IDisposable
    {

        private readonly HashSet<Control> _selectedControls = new();

        private bool _isSelecting = false;
        private Point _selectionStartPt = default;
        private Rectangle _selectionArea = default;

        public MultiSelectPanel _selectionAreaPainter = new()
        {
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

                    _parent.Controls.Remove(_selectionAreaPainter);
                }

                _parent = value;

                if (value != null)
                {
                    value.MouseDown += Parent_MouseDown;
                    value.MouseMove += Parent_MouseMove;
                    value.MouseUp += Parent_MouseUp;

                    value.Controls.Add(_selectionAreaPainter);
                    value.Controls.SetChildIndex(_selectionAreaPainter, 0);
                }
            }
        }

        public IEnumerable<Control> SelectedControls => _selectedControls;

        IEnumerable<Control> ControlsWithinSelectionArea
        {
            get
            {
                if (!IsSelecting || Parent == null)
                {
                    return Enumerable.Empty<Control>();
                }
                else
                {
                    return Parent.GetAllChildren(child =>
                        IntersectsSelectedRegion(child) &&
                        child != _selectionAreaPainter);

                }
            }
        }

        bool IntersectsSelectedRegion(Control control)
        {
            var absPainterPosition = _selectionAreaPainter.PointToScreen(new(0));
            var absControlPosition = control.PointToScreen(new(0));


            var absPainterBounds = new Rectangle(absPainterPosition, _selectionAreaPainter.Size);
            var absControlBounds = new Rectangle(absControlPosition, control.Size);

            return absPainterBounds.IntersectsWith(absControlBounds);
        }

        public Color SelectionColor
        {
            get => _selectionAreaPainter.BackColor;
            set => _selectionAreaPainter.BackColor = value;
        }

        private bool IsSelecting
        {
            get => _isSelecting;
            set
            {
                _isSelecting = value;
                _selectionAreaPainter.Visible = value;
            }
        }


        private Rectangle SelectionArea
        {
            get => _selectionArea;
            set
            {
                _selectionArea = value;
                _selectionAreaPainter.Location = _selectionArea.Location;
                _selectionAreaPainter.Size = _selectionArea.Size;
            }
        }

        public void PasteClipboardToSelectedArea()
        {
            Color c;
            var pasteableControls = SelectedControls
                .Where(ctrl => ctrl.Tag is IExcelPasteTarget tag && tag.PasteableFromExcel);

            var controlRowSource = Algorithms
                .GenerateRows(pasteableControls)
                .GetEnumerator();

            var valueRowSource = StringExtensions.
                SplitClipboardCells(Clipboard.GetText()).
                GetEnumerator();


            IEnumerator<string> valueSource;
            IEnumerator<Control> controlSource;
            while (controlRowSource.MoveNext() & valueRowSource.MoveNext())
            {
                c = Colors.GenerateRandom();
                valueSource = valueRowSource.Current.GetEnumerator()!;
                controlSource = controlRowSource.Current.AsEnumerable().GetEnumerator()!;

                while (controlSource.MoveNext() & valueSource.MoveNext())
                {
                    controlSource.Current.Text = valueSource.Current;
                    controlSource.Current.BackColor = c;
                }
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
            if (IsSelecting)
            {

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

                    Parent.Controls.Remove(_selectionAreaPainter);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _isDisposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
