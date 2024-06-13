using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Honeycomb.UI.Utils
{
    public static class GraphicsRoutines
    {
        public static void DrawButtonBackground( this Graphics g, PushButtonState pushButtonState, bool isHighlighted, bool isChecked, Color backColor, Color parentBackColor, Rectangle region, int penSize = 1, bool outlineByDefault = true)
        {
            const float HOT_OPACITY = 0.33f;

            Color backgroundColor;
            Color outlineColor;

            switch (pushButtonState)
            {
                case PushButtonState.Hot:
                    if (isHighlighted)
                    {
                        backgroundColor = Colors.Lerp(SystemColors.MenuHighlight, parentBackColor, HOT_OPACITY);
                        outlineColor = isChecked ?
                            Colors.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            backgroundColor;
                    }
                    else
                    {
                        backgroundColor = ProfessionalColors.ButtonSelectedHighlight;
                        outlineColor = isChecked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonSelectedHighlightBorder;
                    }
                    break;

                case PushButtonState.Pressed:
                    if (isHighlighted)
                    {
                        backgroundColor = Colors.Lerp(SystemColors.MenuHighlight, parentBackColor, 1f - HOT_OPACITY);
                        outlineColor = SystemColors.MenuHighlight;
                    }
                    else
                    {
                        backgroundColor = ProfessionalColors.ButtonPressedHighlight;
                        outlineColor = isChecked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonPressedBorder;
                    }
                    break;

                default:
                    if (isHighlighted)
                    {
                        backgroundColor = SystemColors.MenuHighlight;
                        outlineColor = isChecked ?
                            Colors.Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            outlineByDefault? SystemColors.InactiveBorder: Color.Transparent;
                    }
                    else
                    {
                        backgroundColor = backColor;
                        outlineColor = isChecked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            outlineByDefault ? SystemColors.InactiveBorder : Color.Transparent;
                    }
                    break;
            }

            g.FillRectangle(new SolidBrush(backgroundColor), region);
            g.DrawRectangle(
                new Pen(outlineColor, penSize),
                new(region.Location, region.Size - new Size(penSize, penSize)));
        }





    }
}
