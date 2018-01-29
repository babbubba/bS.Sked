using Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace bS.Sked.Shared.Extensions
{
    public static class SerializationExtension
    {
        private static ILog log = LogManager.GetLogger(typeof(SerializationExtension));

        public static string ToJson(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static bool ToJsonFile(this object obj, string outputfile)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var output = serializer.Serialize(obj);
                var file = new StreamWriter(outputfile, false);
                file.Write(output);
            }
            catch (Exception ex)
            {
                log.Error("Error serializing the object to Json.", ex);
                return false;
            }
            return true;
        }

        public static string ToJson(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }

        public static T FromJson<T>(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(obj as string);
        }

        public static T FromJsonFile<T>(this object obj, string inputfile)
        {
            try
            {
                var file = new StreamReader(inputfile);
                var input = file.ReadToEnd();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<T>(input);
            }
            catch (Exception ex)
            {
                log.Error("Error deserializing the object to Json.", ex);
                return default(T);
            }
          
        }


        public static bool ToXmlFile<T>(this T obj, string outputfile)
        {
            if (obj == null) { return false; }

            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(obj.GetType());
                Directory.CreateDirectory(Path.GetDirectoryName(outputfile));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, obj);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(outputfile);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error serilaizing object to XML file.", ex);
                return false;
            }

            return true;
        }

        public static T DeSerializeObject<T>(this T serializableObject, string inputfile)
        {
            var fileName = inputfile;

            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            var objectOut = default(T);

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            var xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(T));
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (T)serializer.Deserialize(reader);
                }
            }

            return objectOut;
        }
    }
}
