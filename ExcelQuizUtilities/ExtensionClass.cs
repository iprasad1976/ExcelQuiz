using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ExcelQuiz.Utilities
{
    public static class ExtensionClass
    {
        #region This is extension methods of integer

        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static int GetIntegerFromDBObject(this object dbObject)
        {
            int result = 0;
            if (dbObject != null)
                result = Convert.ToInt32(Convert.ToString(dbObject, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            return result;
        }

        #endregion

        #region This is extension methods of datetime

        // Defines a custom string format to display the DateTime value.
        // This should come from some config variable.
        private static String format = "MMM-dd-yyyy";

        public static String ToCafFormat(this DateTime date)
        {
            // Converts the DateTime to a string using the custom format string
            String dateString = date.ToString(format);
            return dateString;
        }

        public static String ToUtcDateTime(this DateTime date)
        {
            DateTime utc = date.ToUniversalTime();

            // Converts the DateTime to a string using the custom format string
            String dateString = utc.ToString(format);
            return dateString;
        }

        public static String FromUtcDateTime(this DateTime date)
        {
            DateTime back = date.ToLocalTime();

            // Converts the DateTime to a string using the custom format string
            String dateString = back.ToString(format);
            return dateString;
        }

        #endregion
    }
}
