using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExcelQuiz.Utilities
{
    public static class DataTableExtension
    {
        #region IDataRecord Members


        public static bool GetBoolean(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static byte GetByte(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static long GetBytes(this DataRow reader, string fieldName, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public static char GetChar(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static long GetChars(this DataRow reader, string fieldName, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }



        public static DateTime GetDateTime(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static decimal GetDecimal(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static double GetDouble(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }



        public static float GetFloat(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static Guid GetGuid(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static short GetInt16(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static int GetInt32(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static long GetInt64(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }



        public static string GetString(this DataRow row, string fieldName)
        {
           return string.Empty;
        }


        public static int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public static bool IsDBNull(this DataRow reader, string fieldName)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
