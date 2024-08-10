using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneyComb.UI.BaseComponents
{
    public partial class AdaptiveFontLabel : Label
    {

        const bool AUTO_SIZE_DEFAULT = false;
        const bool AUTO_SCALE_FONT_DEFAULT = true;

        private List<float> _availableFontSizes = new();
        private Dictionary<float, Font> _generatedFonts = new();

        public AdaptiveFontLabel()
        {
            AutoSize = AUTO_SIZE_DEFAULT;
            AutoScaleFont = AUTO_SCALE_FONT_DEFAULT;
        }

        /// <summary>
        /// List of options that control will cycle through in order to find the largest font that is able to contain desired content
        /// </summary>
        /// <remarks>
        /// WinForms restricts the collection types that we can use without things breaking. Because of this:
        /// <list type="bullet">
        ///     <item>
        ///         <description><i>Never</i> use <c>add()</c>, <c>remove()</c>, or any other method of this list (generated fonts will fail to update)</description>
        ///     </item>
        ///     <item>
        ///         <description><i>Always</i> add font sizes in ascending numerical order when in the WinForms designer (this property's setter gets ignored while inside the designer)</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public List<float> AvailableFontSizes { 
            get => _availableFontSizes;
            set
            {
                value.Sort();
                _availableFontSizes = value;
                GenerateAvailableFonts();
            } 
        }

        [DefaultValue(AUTO_SCALE_FONT_DEFAULT)]
        public bool AutoScaleFont { get; set; }


        [DefaultValue(AUTO_SIZE_DEFAULT)]
        public override bool AutoSize 
        { 
            get => base.AutoSize; 
            set => base.AutoSize = value; 
        }

        public override Font Font { 
            get => base.Font; 
            set
            {
                if (AutoScaleFont)
                {
                    GenerateAvailableFonts();
                    ScaleFontForBestFit(value);
                }
                else
                {
                    base.Font = value;
                }
            }
        }

        void GenerateAvailableFonts()
        {
            _generatedFonts = _availableFontSizes.ToDictionary(
                   ptSize => ptSize,
                   ptSize => new Font(base.Font.FontFamily, ptSize, base.Font.Style)
               );
        }



        void ScaleFontForBestFit(Font? fallbackValue = null)
        {
            using (Graphics graphics = this.CreateGraphics())
            {

                //Calculate the drawable region in which text can be rendered while respecting control's padding
                var rect = ClientRectangle;
                var pad = Padding;
                SizeF allowedArea = new(
                    rect.Width - (pad.Left + pad.Right),
                    rect.Height - (pad.Top + pad.Bottom));

                var bestFittingFont = AvailableFontSizes
                    .Select(ptSize => _generatedFonts[ptSize])
                    .Where(font =>
                    {
                        SizeF requiredArea = graphics.MeasureString(Text, font, (int)allowedArea.Width);
                        return requiredArea.Width < allowedArea.Width & requiredArea.Height < allowedArea.Height;
                    })
                    .LastOrDefault(fallbackValue ?? base.Font);

                base.Font = bestFittingFont;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (AutoScaleFont)
            {
                ScaleFontForBestFit();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {          
            base.OnSizeChanged(e);
            if (AutoScaleFont)
            {
                ScaleFontForBestFit();
            } 
        }
    }
}
