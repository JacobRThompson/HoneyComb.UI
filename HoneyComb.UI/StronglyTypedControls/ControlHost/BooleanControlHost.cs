using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls
{
    public class BooleanControlHost<TControl> : ValuedControlHost<TControl, bool>
        where TControl : Control, new()
    {
        public BooleanControlHost(Dictionary<Guid, IControlVerifier<bool>>? miscVerifiers = null) : base(
            new BooleanControlParser(),
            miscVerifiers)
        { }

        [DefaultValue(BooleanControlParser.TRUE_LABEL_DEFAULT)]
        public string TrueLabel {
            get => (Parser as BooleanControlParser)!.TrueLabel; 
            set => (Parser as BooleanControlParser)!.TrueLabel = value;
        }

        [DefaultValue(BooleanControlParser.FALSE_LABEL_DEFAULT)]
        public string FalseLabel
        {
            get => (Parser as BooleanControlParser)!.FalseLabel;
            set => (Parser as BooleanControlParser)!.FalseLabel = value;
        }



    }
}
