using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    sealed class Affixer<T> : IAffixer<T>
        where T : struct, IEquatable<T>
    {
        public const string SUFFIX_DEFAULT = "";
        public const string PREFIX_DEFAULT = "";


        public string Suffix { get; set; } = SUFFIX_DEFAULT;
        public string Prefix { get; set; } = PREFIX_DEFAULT;

        public string TrimSuffix(in string input)
        {

            if (Suffix != string.Empty)
            {
                int suffixIndex = input.LastIndexOf(Suffix);
                if (suffixIndex != -1)
                {
                    return input.Remove(suffixIndex, Suffix.Length);
                }
            }
            return input;
        }

        public string TrimPrefix(in string input)
        {
            if (Prefix != string.Empty)
            {
                int prefixIndex = input.IndexOf(Prefix);
                if (prefixIndex != -1)
                {
                    return input.Remove(prefixIndex, Prefix.Length);
                }
            }
            return input;
        }

        public string AddAffixes(in string input) => $"{Prefix}{input}{Suffix}";

        public string StripAffixes(in string input) => TrimPrefix(TrimSuffix(input));


        public AffixedValue<T> CreateAffixedValue(in T input) => new(input, Prefix, Suffix);





    }
}
