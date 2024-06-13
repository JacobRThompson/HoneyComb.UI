using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    public interface IAffixer<T>
        where T : struct, IEquatable<T>
    {      
        string Suffix { get; set; }
        string Prefix { get; set; } 

        string StripAffixes(in string input);
        string AddAffixes(in string input);

        AffixedValue<T> CreateAffixedValue(in T input);
    }
}
