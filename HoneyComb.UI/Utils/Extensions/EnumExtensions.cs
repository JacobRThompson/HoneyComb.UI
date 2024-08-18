using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.Utils.Extensions
{
    public static class EnumExtensions
    {      
        public static DescriptionAttribute? GetDescripton<T>(this T value) where T : Enum
        {          
            MemberInfo valueMetaData = typeof(T).GetMember(value.ToString())[0];

            return valueMetaData.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
        }

        public static Dictionary<T, DescriptionAttribute?> GetDescriptions<T>() where T : struct, Enum
        {
            return Enum.GetValues<T>()
                .Select(val => (Key: val, Value: val.GetDescripton()))
                .ToDictionary(
                    entry => entry.Key,
                    entry => entry.Value
                );
        }

        public static bool TryParseWithDescriptions<T>(string description, out T result) where T : struct, Enum
        {
            if(Enum.TryParse<T>(description, out result))
            {
                return true;
            }
            else 
            {
                T[] validValues = GetDescriptions<T>()
                    .Where(entry => entry.Value?.Description == description)
                    .Select(entry => entry.Key).
                    ToArray();

                switch (validValues.Length)
                {
                    case 0:
                        result = default;
                        return false;

                    case 1:
                        result = validValues[0];
                        return true;

                    default:
                        throw new AmbiguousMatchException($"String {description} is possible description for multiple {typeof(T)} values: {string.Join(", ", validValues)}");
                }

            }
        }

        public static string? ToDescription<T> (this T value) where T : Enum =>
            value.GetDescripton()?.Description ?? null;
            
    
        public static string ToDescriptionOrString<T>(this T value) where T: Enum =>
            value.ToDescription() ?? value.ToString();


    }
}
