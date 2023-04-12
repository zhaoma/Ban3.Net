using System;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Infrastructures.Common.Extensions
{
    public static partial class Helper
    {
        /// 
        public static IEnumerable<T> GetAttributes<T>(
            this object obj,
            bool includeInherited = true) where T : Attribute
        {
            var type = (obj as Type ?? obj.GetType());
            return type
                .GetCustomAttributes(typeof(T), includeInherited)
                .OfType<T>()
                .Select(attribute => attribute);
        }

        /// 
        public static T GetFirstAttribute<T>(
            this object obj,
            bool includeInherited = true) where T : Attribute
        {
            var attributes = obj.GetAttributes<T>(includeInherited);
            if (attributes != null && attributes.Any())
            {
                return (attributes.First() as T);
            }

            return null;
        }

    }
}
