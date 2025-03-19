using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazorFinance.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()?
                            .GetName() ?? string.Empty;
        }

        public static T[] GetEnumValues<T>() where T : System.Enum
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
