using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExcelQuiz.Utilities
{
    public static class IDataReaderExtension 
    {
       
        #region IDataRecord Members


        public static bool GetBoolean(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetBoolean(fieldsIndex);
            }
            else
            {
                return false;
            }
        }

        public static byte GetByte(this IDataReader reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static long GetBytes(this IDataReader reader, string fieldName, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public static char GetChar(this IDataReader reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static long GetChars(this IDataReader reader, string fieldName, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }



        public static DateTime GetDateTime(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetDateTime(fieldsIndex);
            }
            else
            {
                // change this code to return appropriate value
                return DateTime.MinValue;
            }
        }

        public static decimal GetDecimal(this IDataReader reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static double GetDouble(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;

            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetDouble(fieldsIndex);
            }
            else
            {
                // change this code to return appropriate value
                return 0.0;
            }
        }



        public static float GetFloat(this IDataReader reader, string fieldName)
        {
            throw new NotImplementedException();
        }

        public static Guid GetGuid(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);
            
            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetGuid(fieldsIndex);
            }
            else
            {
                return Guid.Empty;
            }
        }

        public static short GetInt16(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetInt16(fieldsIndex);
            }
            else
            {
                return 0;
            }
        }

        public static int GetInt32(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetInt32(fieldsIndex);
            }
            else
            {
                return 0;
            }
        }

        public static long GetInt64(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetInt64(fieldsIndex);
            }
            else
            {
                return default(long);
            }
        }

        public static Byte[] GetBytes(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return (Byte[])reader[fieldName];
            }
            else
            {
                return null;
            }
        }

        public static string GetString(this IDataReader reader, string fieldName)
        {
            int fieldsIndex;
            fieldsIndex = reader.GetOrdinal(fieldName);

            if (!reader.IsDBNull(fieldsIndex))
            {
                return reader.GetString(fieldsIndex);
            }
            else
            {
                return string.Empty;
            }
        }


        public static int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public static bool IsDBNull(this IDataReader reader, string fieldName)
        {
            throw new NotImplementedException();
        }

      

        #endregion
    }

    
}
