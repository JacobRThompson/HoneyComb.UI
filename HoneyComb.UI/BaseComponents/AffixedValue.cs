using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents
{
    public readonly struct AffixedValue<T> : IEquatable<AffixedValue<T>>
        where T: struct, IEquatable<T>
    {
        public AffixedValue(T value, string? prefix = null, string? suffix = null)
        {
            Value = value;
            Prefix = prefix ?? string.Empty;
            Suffix = suffix ?? string.Empty;
        }

        public readonly T Value;
        public readonly string Prefix;
        public readonly string Suffix;


        public override string ToString() => $"{Prefix}{Value}{Suffix}";
        public override int GetHashCode() => HashCode.Combine(Value, Prefix, Suffix);

        public string TrimAffixes(string text) => TrimSuffix(TrimPrefix(text, Prefix), Suffix);
        private static string TrimSuffix(string input, string suffix)
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

        private static string TrimPrefix(string input, string prefix)
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

        public bool Equals(AffixedValue<T> other) => this.GetHashCode() == other.GetHashCode();

        public override bool Equals([NotNullWhen(true)] object? obj) => obj switch
        {
            null => false,
            _ => obj.GetHashCode() == this.GetHashCode()
        };
  

       


        public static bool operator ==(AffixedValue<T> left, AffixedValue<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AffixedValue<T> left, AffixedValue<T> right)
        {
            return !(left == right);
        }

      

    }
}
