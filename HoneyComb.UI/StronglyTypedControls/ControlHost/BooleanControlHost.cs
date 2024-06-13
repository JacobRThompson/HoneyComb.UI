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
        public BooleanControlHost(Dictionary<Guid, ITextBoxVerifier<bool>>? miscVerifiers = null) : base(
            new BooleanTextBoxParser(),
            miscVerifiers)
        { }

        [DefaultValue(BooleanTextBoxParser.TRUE_LABEL_DEFAULT)]
        public string TrueLabel {
            get => (Parser as BooleanTextBoxParser)!.TrueLabel; 
            set => (Parser as BooleanTextBoxParser)!.TrueLabel = value;
        }

        [DefaultValue(BooleanTextBoxParser.FALSE_LABEL_DEFAULT)]
        public string FalseLabel
        {
            get => (Parser as BooleanTextBoxParser)!.FalseLabel;
            set => (Parser as BooleanTextBoxParser)!.FalseLabel = value;
        }
    }
}
