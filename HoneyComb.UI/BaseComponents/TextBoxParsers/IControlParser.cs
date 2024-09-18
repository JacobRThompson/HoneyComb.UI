using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxParsers
{
    public interface IControlParser
    {
        public const string DEFAULT_SUFFIX = "";
        public const string DEFAULT_PREFIX = "";
    }

    public interface IControlParser<T> : IControlParser
        where T : struct
    {     
        bool TryParse(in string text, out T result);

        public string ConvertToString(in T value);

        public string Suffix { get; set; } 
        public string Prefix { get; set; }
    }
}
