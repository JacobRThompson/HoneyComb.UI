using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Honeycomb.UI.IconButtons
{
    public class IconPushButton: IconControl
    {

        protected virtual Bitmap BackgroundBitmap { get; set; } = new(1, 1);

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            BackgroundBitmap = new(BackgroundImage, this.Size);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            BackgroundBitmap = new(BackgroundImage, this.Size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void OnPaint(PaintEventArgs e)
        {

            Color foreColor, backColor;

            switch (ButtonState)
            {
                case PushButtonState.Hot: //Swap back and fore colors when user hovers over button
                    foreColor = this.GetIconBackColor();
                    backColor = this.GetIconForeColor();
                    break;

                case PushButtonState.Pressed:
                    foreColor = this.GetIconForeColor();
                    backColor = this.GetIconBackColor();
                    break;

                case PushButtonState.Disabled:
                    foreColor = SystemColors.GrayText;
                    backColor = this.GetIconForeColor();
                    break;

                default:
                    foreColor = this.GetIconForeColor();
                    backColor = this.GetIconBackColor();
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), e.ClipRectangle);

            if (BackgroundImage != null)
            {
                //StructExtensions.UnsafeReplaceOpaquePixels(BackgroundBitmap, foreColor);

                e.Graphics.DrawImage(
                    BackgroundBitmap!.ReplaceOpaquePixels(foreColor),
                    e.ClipRectangle.ScaleToAspectRatio(BackgroundImage!.GetAspectRatio())
                );

            }
            
        }


    }

    
}
