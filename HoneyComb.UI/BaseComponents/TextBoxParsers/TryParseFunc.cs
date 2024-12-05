using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.BaseComponents.TextBoxParsers
{
    public delegate bool TryParseFunction<T>(in string? s, NumberStyles style, IFormatProvider? provider, out T result);
}
