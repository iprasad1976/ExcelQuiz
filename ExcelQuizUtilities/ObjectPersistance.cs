using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ExcelQuiz.Utilities
{
    public class ObjectPersistance<T>
    {
        /// <summary>
        /// This method is used to Deserialize the XML to object.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeSerialize(string xml)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(T));
            var sw = new StringReader(xml);
            T p = (T)xmlser.Deserialize(sw);
            return p;
        }

        /// <summary>
        /// This method is used to Serialize the object to XML
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string Serialize(T p)
        {
            Type typ = typeof(T);
            XmlSerializer xmlser = new XmlSerializer(typ);
            var sw = new StringWriter();
            xmlser.Serialize(sw, p);
            return sw.ToString();
        }

        public static T Copy(T obj)
        {
            return DeSerialize(Serialize(obj));
        }
    }
}
