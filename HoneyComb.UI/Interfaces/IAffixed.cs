using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.BaseComponents;

namespace Honeycomb.UI.Interfaces
{
    /// <summary>
    /// Interface for Controls that support the use of suffixes and prefixes
    /// </summary>
    public interface IAffixed<T> where T : struct, IEquatable<T>
    {

        public AffixedValue<T> AffixedResult { get; }

        public T UnaffixedResult { get; }

        public string Suffix { get; set; }
        public string Prefix { get; set; }
     
        public string AddAffixes(string text) => $"{Prefix}{text}{Suffix}";
        public string TrimAffixes(string text) => TrimSuffix(TrimPrefix(text, Prefix), Suffix);

        protected static string TrimSuffix(string input, string suffix)
        {
            input ??= string.Empty;
            if (suffix != string.Empty)
            {
                int suffixIndex = input.LastIndexOf(suffix);
                if (suffixIndex != -1)
                {
                    return input.Remove(suffixIndex, suffix.Length);
                }
            }
            return input;
        }

        protected static string TrimPrefix(string input, string prefix)
        {
            if (prefix != string.Empty)
            {
                int prefixIndex = input.IndexOf(prefix);
                if (prefixIndex != -1)
                {
                    return input.Remove(prefixIndex, prefix.Length);
                }
            }
            return input;
        }


    }

}
