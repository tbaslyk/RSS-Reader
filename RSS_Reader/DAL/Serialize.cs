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

            using (FileStream file = File.Create(Environment.CurrentDirectory + "\\xmlfile.xml"))
            {

                XmlSerializer xsSubmit = new XmlSerializer(o.GetType());
                xsSubmit.Serialize(file, o);              
            }
            
            


        }


    }
}
