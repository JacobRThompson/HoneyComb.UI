using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public interface IPinnableUIElement
    {
        event EventHandler? PinnedChanged;

        bool Pinned { get; set; }

    }
}
