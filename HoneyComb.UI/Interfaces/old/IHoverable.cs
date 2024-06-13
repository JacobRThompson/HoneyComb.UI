using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.Interfaces
{
    public interface IHoverable: IHighlightable
    {
        public PushButtonState ButtonState { get; set; }

        public Control? Parent { get; set; }
        public float HotOpacity { get; set; }

        /// <summary>  Color used for background when the user is hovering over the control with a mouse, etc. </summary>
        public Color HotBackColor { get; set; } // ProfessionalColors.ButtonSelectedHighlight

        /// <summary>  Color used for foreground when the user is hovering over the control with a mouse, etc. </summary>
        public Color PressedBackColor { get; set; } //ProfessionalColors.ButtonPressedHighlight

     
        public void PaintBackground(PaintEventArgs e)
        {

            Color backgroundColor = ButtonState switch
            {
                PushButtonState.Hot => Highlighted?
                    Colors.Lerp(HighlightedBackColor, Parent?.BackColor ?? Color.Transparent, HotOpacity):
                    HotBackColor,

                PushButtonState.Pressed => Highlighted?
                    Colors.Lerp(HighlightedBackColor, Parent?.BackColor ?? Color.Transparent, 1f - HotOpacity):
                    PressedBackColor,

                _ => Highlighted ?
                    HighlightedBackColor:
                    DefaultBackColor
            };
         
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.ClipRectangle);
        }


    }


}
