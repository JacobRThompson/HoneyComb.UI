using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Utils
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TResult> If<TResult>(
            this IEnumerable<TResult> source,
            bool condition,
            in Func<IEnumerable<TResult>, IEnumerable<TResult>> operation) 
        {
            return condition ? operation(source) : source;
        }

        public static IEnumerable<TResult> If<T,TResult>(
           this IEnumerable<TResult> source, 
           bool condition,
           in Func<IEnumerable<TResult>, T, IEnumerable<TResult>> operation,
           in T p1)
        {
            return condition ? operation(source, p1) : source;
          
        }

        public static IEnumerable<TResult> If<T1, T2, TResult>(
          this IEnumerable<TResult> source, 
          bool condition,
          in Func<IEnumerable<TResult>, T1, T2, IEnumerable<TResult>> operation,
          in T1 p1, in T2 p2)
        {
            return condition ? operation(source, p1, p2) : source;
        }

        public static (T? min, T? max) Range<T>(this IEnumerable<T> source) where
            T : IComparisonOperators<T, T, bool>, IMinMaxValue<T>
        {
            T min = T.MaxValue;
            T max = T.MinValue;

            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current < min) { min = enumerator.Current; }
                if (enumerator.Current > max) { max = enumerator.Current; }
            }

            // This can only happen if an empty IEnumerable is passed as a source
            if (min > max)
            {
                return (default, default);
            }

            return (min, max);
        }
    }
}
