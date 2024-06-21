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
        public static bool PaintSelectedControls = true;

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
                    UnTrackContainer(_parent);

                    _parent.Controls.Remove(_selectionAreaPainter);
                }

                _parent = value;

                if (value != null)
                {
                    TrackContainer(value);

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

                if(Parent != null)
                {
                    _selectionAreaPainter.Location = Parent.PointToClient(_selectionArea.Location);
                    _selectionAreaPainter.Size = _selectionArea.Size;
                }
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

        void TrackedContainer_MouseDown(object? sender, MouseEventArgs e)
        {
            IsSelecting = true;

            _selectionStartPt = (sender as Control)!.PointToScreen(e.Location);
            _selectedControls.Clear();
        }

        void TrackedContainer_MouseUp(object? sender, MouseEventArgs e)
        {
            if (PaintSelectedControls)
            {
                var c = Colors.GenerateRandom();
                foreach (Control ctrl in ControlsWithinSelectionArea)
                {
                    ctrl.BackColor = c;
                    _selectedControls.Add(ctrl);
                }

                IsSelecting = false;
            }
           
        }

        void TrackedContainer_MouseMove(object? sender, MouseEventArgs e)
        {
            if (IsSelecting)
            {

                var newPos = (sender as Control)!.PointToScreen(e.Location);

                SelectionArea = new Rectangle(
                    Math.Min(_selectionStartPt.X, newPos.X),
                    Math.Min(_selectionStartPt.Y, newPos.Y),
                    Math.Abs(_selectionStartPt.X - newPos.X),
                    Math.Abs(_selectionStartPt.Y - newPos.Y));

                //_boxPainter.Invalidate();
            }
        }

        void TrackContainer(ContainerControl target)
        {
            var containerFamilyTree = target.
                GetAllChildren().
                OfType<ContainerControl>().
                Append(target);


            foreach (var container in containerFamilyTree)
            {
                container.MouseDown += TrackedContainer_MouseDown;
                container.MouseMove += TrackedContainer_MouseMove;
                container.MouseUp += TrackedContainer_MouseUp;
            }
        }

        void UnTrackContainer(ContainerControl target)
        {
            var containerFamilyTree = target.
                GetAllChildren().
                OfType<ContainerControl>().
                Append(target);

            foreach (var container in containerFamilyTree)
            {
                container.MouseDown -= TrackedContainer_MouseDown;
                container.MouseMove -= TrackedContainer_MouseMove;
                container.MouseUp -= TrackedContainer_MouseUp;
            }
        }

        void IDisposable.Dispose()
        {
            if (!_isDisposed)
            {

                if (Parent != null)
                {
                    UnTrackContainer(Parent);

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
