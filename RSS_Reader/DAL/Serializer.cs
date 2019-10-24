using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class Serializer
    {

        public static void Serialize<T>(T data, string path)
        {

            if (!File.Exists(path))
            {
                using (FileStream file = File.Create(path))
                {

                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(file, data);
                }
            }
            else
            {
                var serializer = new XmlSerializer(typeof(T));

                var writer = new StreamWriter(path, append: true);

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;

                var xmlWriter = XmlWriter.Create(writer, settings);

                serializer.Serialize(xmlWriter, data, ns);

                xmlWriter.Close();
                writer.Close();
            }
        }

        public static T Deserialize<T>(string path)
        {

            if (File.Exists(path))
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;

                var reader = new StreamReader(path);

                XmlReader xreader = XmlReader.Create(reader, settings);

                XmlSerializer xs = new XmlSerializer(typeof(T));

                T data = (T)xs.Deserialize(xreader);

                xreader.Close();
                reader.Close();

                return data;
            }
            else
            {
                return default(T);
            }
        }


    }
}
