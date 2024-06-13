using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.Interfaces
{
    public interface IToggleableAvailability
    {
        public event EventHandler AvailabilityChanged;
        public bool Available { get; set; }

    }
}
