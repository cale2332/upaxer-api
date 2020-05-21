using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebApp.Common.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(this Enum value)
        {
            try
            {
                if (value != null)
                {
                    return !(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;
        }


        public static Dictionary<int, string> ToDictionary<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<object>()
                .ToDictionary(k => (int)k, v => ((Enum)v).GetEnumDescription());
        }

        public static List<KeyValuePair<int, string>> ToKeyValuePair<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<object>()
                .Select(p => new KeyValuePair<int, string>(Convert.ToInt32(p), ((Enum)p).GetEnumDescription()))
                .OrderBy(p => p.Value)
                .ToList();
        }
         
    }
}
