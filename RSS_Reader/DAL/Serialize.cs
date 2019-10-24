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
    public class Serialize
    {

        public static void serialize(object o)
        {

            string path = Environment.CurrentDirectory + "\\xmlfile.xml";
            if (!File.Exists(path))
            {

                using (FileStream file = File.Create(path))
                {

                    XmlSerializer xsSubmit = new XmlSerializer(o.GetType());
                    xsSubmit.Serialize(file, o);              
                }

            }
            else
            {

                using(FileStream file = new FileStream(path, FileMode.Append))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(o.GetType());
                    xsSubmit.Serialize(file, o);

                }

            }






            
            
            


        }

        public static List<object> deSerialize()
        {

            string path = Environment.CurrentDirectory + "\\xmlfile.xml";
            XmlSerializer loadXML = new XmlSerializer(typeof(List<object>));

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var obj = loadXML.Deserialize(fs);

                    var lista = (List<object>)obj;

                    return lista;
                }
            }
            else
            {
                return new List<object>();
            }
        }
    }
}
