using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using Honeycomb.UI.Interfaces;
using Honeycomb.UI.StronglyTypedControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ControlHost
{
    public interface IValuedControlHost<TControl, T> : IToggleableAvailability
        where TControl : Control, new()
        where T : struct, IEquatable<T>
    {
        public TControl Child { get; set; }

        public IControlParser<T> Parser { get; }
        public Dictionary<Guid, IControlVerifier<T>> Verifiers { get; }

        public void SetValue(in T value);

        public bool TryGetValue(out T value);

    }
}
