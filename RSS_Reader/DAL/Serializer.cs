using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DAL
{
    public class Serializer
    {

        public static void Serialize<T>(T data)
        {
            string path = Environment.CurrentDirectory + "\\feeds.xml";
            
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
                using(FileStream file = new FileStream(path, FileMode.Append))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(file, data);
                }
            }
        }

        public static T DeSerialize<T>()
        {
            string path = Environment.CurrentDirectory + "\\feeds.xml";

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));

                    T data = (T) xs.Deserialize(fs);

                    return data;
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
