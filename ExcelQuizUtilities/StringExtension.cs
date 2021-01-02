using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ExcelQuiz.Utilities
{
    public static class StringExtension
    {
        public static int ToInt32(this string input)
        {
            int result;
            int.TryParse(input, out result);
            return result;
        }

        public static long ToInt64(this string input)
        {
            long result;
            long.TryParse(input, out result);
            return result;
        }

        public static bool ToBool(this string input)
        {
            bool result;
            bool.TryParse(input, out result);
            return result;
        }

        public static T To<T>(this string input)
        {
            Type type = typeof(T);
            T retVal = default(T); // (T)type.Assembly.CreateInstance(type.ToString());

            MethodInfo mi = type.GetMethod("Parse", new Type[] { typeof(string) });

            if (mi == null)
            {
                //It might be a nullable type , try to get the method on the encapulated type
                if (type.GetGenericArguments() != null &&
                    type.GetGenericArguments().Length > 0)
                {
                    mi = type.GetGenericArguments()[0].GetMethod("Parse", new Type[] { typeof(string) });
                }
            }

            if (mi != null)
            {
                retVal = (T)mi.Invoke(type, new object[] { input });
            }

            return retVal;
        }

    }
}


