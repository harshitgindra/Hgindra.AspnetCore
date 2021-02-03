using System;
using System.ComponentModel;
using System.Linq;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the string value associated with the the corresponding enum option
        /// </summary>
        /// <param name="enumValue">Any Enum where DefaultValue attribute is defined.</param>
        /// <returns></returns>
        internal static string DefaultValue(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var defaultValueAttribute = fieldInfo
                .GetCustomAttributes(typeof(DefaultValueAttribute), inherit: false)
                .Cast<DefaultValueAttribute>()
                .SingleOrDefault();

            return defaultValueAttribute?.Value.ToString() ?? enumValue.ToString();
        }
    }
}
