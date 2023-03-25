using System;
using System.Linq;
using System.Reflection;
using Tools.Attributes;

namespace Tools.Mapper
{
    public static class Mapper
    {
        public static T Map<T, K>(K src)
        {
            var obj = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propertie in properties)
            {
                try
                {
                    var propertieName = propertie.Name;
                    var child = string.Empty;

                    var customAttributes = propertie.GetCustomAttribute<CustomResponseAttribute>();
                    if (customAttributes != null)
                    {
                        if (customAttributes.Parent != null)
                        {
                            propertieName = customAttributes.Parent;
                        }
                        child = customAttributes.Child;
                    }

                    var srcPropInfo = src.GetType().GetProperty(propertieName, BindingFlags.Public | BindingFlags.Instance);
                    if (srcPropInfo != null)
                    {
                        var value = srcPropInfo.GetValue(src, null);

                        if (!string.IsNullOrEmpty(child) && value != null)
                        {
                            var srcPropChildInfo = value.GetType().GetProperty(child, BindingFlags.Public | BindingFlags.Instance);
                            if (srcPropChildInfo != null)
                            {
                                value = srcPropChildInfo.GetValue(value, null);
                            }
                        }

                        propertie.SetValue(obj, value, null);
                    }
                } catch { }
            }

            return obj;
        }

    }
}
