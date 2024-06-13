using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.ToolStripControls
{
    public class ToolStripPinnableButton : ToolStripButton, IPinnableUIElement
    {

        private bool _pinned = false;


        public event EventHandler? PinnedChanged;

        public bool Pinned
        {
            get => _pinned;
            set
            {
                if (_pinned != value)
                {
                    _pinned = value;
                    OnPinnedChanged(EventArgs.Empty);
                }
            }
        }

        protected void OnPinnedChanged(EventArgs e)
        {
            PinnedChanged?.Invoke(this, e);


        }

        new public bool Visible
        {
            get => base.Visible;
            set
            {
                if (!Pinned) { base.Visible = value; }
            }
        }
    }
}
