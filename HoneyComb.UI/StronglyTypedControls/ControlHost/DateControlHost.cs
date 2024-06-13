using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ControlHost
{
    public class DateControlHost<TControl> : ValuedControlHost<TControl, DateOnly>
          where TControl : Control, new()
    {
        public DateControlHost(Dictionary<Guid, ITextBoxVerifier<DateOnly>>? miscVerifiers = null): base(
            new DateTextBoxParser(),
            miscVerifiers)
        { }
    }
}
