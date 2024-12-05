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
    /// <summary>
    /// Provides functionality to select multiple controls within a container.
    /// </summary>
    public partial class MultiSelector : IDisposable
    {
        /// <summary>
        /// Indicates whether the selected controls should be painted.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSelector"/> class.
        /// </summary>
        /// <param name="parent">The parent form.</param>
        public MultiSelector(Form? parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets or sets the parent form.
        /// </summary>
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

        /// <summary>
        /// Gets the selected controls.
        /// </summary>
        public IEnumerable<Control> SelectedControls => _selectedControls;

        /// <summary>
        /// Gets the controls within the selection area.
        /// </summary>
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

        /// <summary>
        /// Determines whether the specified control intersects with the selected region.
        /// </summary>
        /// <param name="control">The control to check.</param>
        /// <returns><c>true</c> if the control intersects with the selected region; otherwise, <c>false</c>.</returns>
        bool IntersectsSelectedRegion(Control control)
        {
            var absPainterPosition = _selectionAreaPainter.PointToScreen(new(0));
            var absControlPosition = control.PointToScreen(new(0));

            var absPainterBounds = new Rectangle(absPainterPosition, _selectionAreaPainter.Size);
            var absControlBounds = new Rectangle(absControlPosition, control.Size);

            return absPainterBounds.IntersectsWith(absControlBounds);
        }

        /// <summary>
        /// Gets or sets the selection color.
        /// </summary>
        public Color SelectionColor
        {
            get => _selectionAreaPainter.BackColor;
            set => _selectionAreaPainter.BackColor = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selection is in progress.
        /// </summary>
        private bool IsSelecting
        {
            get => _isSelecting;
            set
            {
                _isSelecting = value;
                _selectionAreaPainter.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the selection area.
        /// </summary>
        private Rectangle SelectionArea
        {
            get => _selectionArea;
            set
            {
                _selectionArea = value;

                if (Parent != null)
                {
                    _selectionAreaPainter.Location = Parent.PointToClient(_selectionArea.Location);
                    _selectionAreaPainter.Size = _selectionArea.Size;
                }
            }
        }

        /// <summary>
        /// Pastes the clipboard content to the selected area.
        /// </summary>
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

        /// <summary>
        /// Handles the MouseDown event of the tracked container. 
        /// </summary>
        /// <remarks>
        /// This handler Is typically Added/Removed from a container by calling <see cref="TrackContainer(ContainerControl)"> TrackContainer()</see> or <see cref="UnTrackContainer(ContainerControl)"> UnTrackContainer()</see>.
        /// </remarks>
        private void TrackedContainer_MouseDown(object? sender, MouseEventArgs e)
        {
            IsSelecting = true;
            _selectionStartPt = (sender as Control)!.PointToScreen(e.Location);
            _selectedControls.Clear();
        }

        /// <summary>
        /// Handles the MouseUp event of the tracked container.
        /// </summary>
        /// <remarks>
        /// This handler Is typically Added/Removed from a container by calling <see cref="TrackContainer(ContainerControl)"> TrackContainer()</see> or <see cref="UnTrackContainer(ContainerControl)"> UnTrackContainer()</see>.
        /// </remarks>
        private void TrackedContainer_MouseUp(object? sender, MouseEventArgs e)
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

        /// <summary>
        /// Handles the MouseMove event of the tracked container.
        /// </summary>
        /// <remarks>
        /// This handler Is typically Added/Removed from a container by calling <see cref="TrackContainer(ContainerControl)"> TrackContainer()</see> or <see cref="UnTrackContainer(ContainerControl)"> UnTrackContainer()</see>.
        /// </remarks>
        private void TrackedContainer_MouseMove(object? sender, MouseEventArgs e)
        {
            if (IsSelecting)
            {
                var newPos = (sender as Control)!.PointToScreen(e.Location);

                SelectionArea = new Rectangle(
                    Math.Min(_selectionStartPt.X, newPos.X),
                    Math.Min(_selectionStartPt.Y, newPos.Y),
                    Math.Abs(_selectionStartPt.X - newPos.X),
                    Math.Abs(_selectionStartPt.Y - newPos.Y));
            }
        }

        /// <summary>
        /// Tracks the specified container and its children and adds handlers needed to make MultiSelector work.
        /// </summary>
        /// <param name="target">The container to track.</param>
        private void TrackContainer(ContainerControl target)
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

        /// <summary>
        /// Stops tracking the specified container and its children and removes any MultiSelector-related handlers.
        /// </summary>
        /// <param name="target">The container to untrack.</param>
        private void UnTrackContainer(ContainerControl target)
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
