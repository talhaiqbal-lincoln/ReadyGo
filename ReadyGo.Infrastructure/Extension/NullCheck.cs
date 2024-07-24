using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Infrastructure.Extension
{
    public static class NullCheck
    {
        public static string CheckString(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        } 
        public static double? CheckDouble(this double? value)
        {
            return value == null ? null : value;
        }
        public static Guid ToGuid(this Guid? source)
        {
            return source ?? Guid.Empty;
        }
        public static bool IsFloatOrInt(this string value)
        {
            int intValue;
            float floatValue;
            return Int32.TryParse(value, out intValue) || float.TryParse(value, out floatValue);
        }
    }
}
