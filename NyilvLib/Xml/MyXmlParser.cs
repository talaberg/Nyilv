using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NyilvLib.Xml
{
    public static class MyXmlParser
    {
        public static string List2Xml(List<string> L, string tag, string elementsName = "elements")
        {
            string s;
            
           XmlDocument xmlDoc = new XmlDocument();
            
            using (MemoryStream xmlStream = new MemoryStream())
            {         
                XmlSerializer xmlSerializer = new XmlSerializer(L.GetType());

                xmlSerializer.Serialize(xmlStream, L);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                s = xmlDoc.OuterXml;
            }

            xmlDoc.InnerXml = new XElement(elementsName, L.Select(i => new XElement(tag, i))).ToString();

            s = xmlDoc.OuterXml;

            return s;
        }
        public static string List2Xml(List<int> L, string tag, string elementsName = "elements")
        {
            List<string> Ls = new List<string>();

            foreach (var item in L)
            {
                Ls.Add(item.ToString());   
            }
            string s = List2Xml(Ls, tag, elementsName);

            return s;
        }
        public static List<string> Xml2StringList(string s, string tag, string elementsName = "elements")
        {
            List<string> L = new List<string>();

            XmlDocument doc = new XmlDocument();

            using (XmlTextReader inStream = new XmlTextReader(new StringReader(s)))
            {
                doc.Load(inStream);
            }
            XmlNodeList NL = doc.GetElementsByTagName(tag);


            foreach (XmlNode node in NL)
            {
                L.Add(node.InnerText);
            }

            return L;
        }
        public static List<int> Xml2IntList(string s, string tag, string elementsName = "elements")
        {
            List<string> L = Xml2StringList(s, tag, elementsName);
            List<int> Li = new List<int>();

            foreach (var item in L)
            {
                int number;
                bool result = int.TryParse(item, out number);
                if (result)
                {
                    Li.Add(number);
                }
            }

            return Li;
        }

        public static string Class2Xml<T>(T myClass)
        {
            XmlSerializer x = new XmlSerializer(myClass.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            
            var settings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Auto, Indent = true 
            };

            using(StringWriter sW = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sW, settings))
            {
                x.Serialize(xw, myClass, ns);

                return sW.ToString();
            }
        }

    }
}
