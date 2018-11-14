using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Extensions
{
    public static class TypeExtensions
    {
        internal const BindingFlags AllInstanceScopes = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static T CreateAs<T>(this Type type, params object[] parameters)
        {
            return (T)Activator.CreateInstance(type, AllInstanceScopes, null, parameters, CultureInfo.CurrentCulture);
        }

        public static bool IsConcreteClass(this Type type)
        {
            if (type == null) return false;

            return type.IsClass && !type.IsAbstract;
        }

        public static bool Is<T>(this Type type)
        {
            return Is(type, typeof(T));
        }

        public static bool Is(this Type type, Type targetType)
        {
            return targetType.IsAssignableFrom(type);
        }
    }
}
