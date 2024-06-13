using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Interfaces
{
    public interface IHighlightableText: IHighlightable, IText
    {
        public const string DEFAULT_FONT = "Segoe UI, 9pt";
        public const string HIGHLIGHTED_FONT = "Segoe UI, 9pt, style=Italic";

        public Font DefaultFont { get; set; }
        public Font HighlightedFont { get; set; }

        public void SetHighlightedFont(ref Font _highlightedFont, Font value)
        {
            _highlightedFont = value;
            if (Highlighted)
            {
                Font = value;
            }
        }
        public void SetDefaultFont(ref Font _defaultFont, Font value)
        {
            _defaultFont = value;
            if (!Highlighted)
            {
                Font = value;
            }
        }

        new public void  SetHighlighted(ref bool _highlighted, bool value)
        {
            (this as IHighlightable).SetHighlighted(ref _highlighted, value);
            Font = value? HighlightedFont: DefaultFont;
        }

    }
}
