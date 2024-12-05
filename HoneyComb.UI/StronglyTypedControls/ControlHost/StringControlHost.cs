using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls
{
    public class StringControlHost<TControl> : ValuedControlHost<TControl, ReadOnlyMemory<char>>
        where TControl : Control, new()
    {
        public StringControlHost(Dictionary<Guid, IControlVerifier<ReadOnlyMemory<char>>>? miscVerifiers = null) : base(
           new StringControlParser(),
           miscVerifiers)
        { }
    }
}
