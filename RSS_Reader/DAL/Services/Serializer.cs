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
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(fs, data);
            }
        }

        public static T Deserialize<T>(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    T data = (T)xs.Deserialize(fs);
                    return data;
                }
            }
            else
            {
                return default;
            }
        }
    }
}
