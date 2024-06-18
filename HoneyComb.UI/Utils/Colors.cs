using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Utils
{
    public static class Colors
    {
        private static Random _rng = new();

        public static Color ToAlpha(this Color c, byte alpha = 255) => Color.FromArgb(alpha, c.R, c.G, c.B);
        public static Color GenerateRandom() => Color.FromArgb(_rng.Next(256), _rng.Next(256), _rng.Next(256));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color Lerp(Color a, Color b, float amount)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * amount),
                (int)(a.G + (b.G - a.G) * amount),
                (int)(a.B + (b.B - a.B) * amount));
        }

        
    }
}
