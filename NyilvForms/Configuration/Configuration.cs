using NyilvLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NyilvForms.Configuration
{
    public class ConfigHandler
    {
        public Config Configuration { get; set; }

        string configFile = "AppConfiguration.xml";
        public string ConfigFile { get { return configFile; } set { configFile = value; } }

        public void SaveConfig()
        {
            using (MemoryStream xmlStream = new MemoryStream())
            {
                XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 

                // Initializes a new instance of the XmlDocument class.          
                XmlSerializer xmlSerializer = new XmlSerializer(Configuration.GetType());

                xmlSerializer.Serialize(xmlStream, Configuration);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);

                //FileStream fStream = new FileStream(configFile, FileMode.Create);

                using (StreamWriter outStream = new StreamWriter(configFile, false))
                {
                    //Save document
                    xmlDoc.Save(outStream);
                }
            }
        }
        public void LoadConfig()
        {           
            XmlDocument doc = new XmlDocument();

            Configuration = new Config();

            if (File.Exists(configFile))
            {
                using (StreamReader inStream = new StreamReader(configFile))
                {
                    doc.Load(inStream);
                }
                
                XmlSerializer oXmlSerializer = new XmlSerializer(Configuration.GetType());

                //The StringReader will be the stream holder for the existing XML file 
                Configuration = (Config)oXmlSerializer.Deserialize(new StringReader(doc.InnerXml));

            }
            else
            {
                Configuration.HostAddress = WebApi.DefaultHostAddress;
                Configuration.EncryptedPassword = "";
                Configuration.Username = "";
                this.SaveConfig();
            }
        }
    }

    public class Config
    {
        string hostAddress;
        string username;
        string encryptedPassword;

        public Config()
        {
            hostAddress = username = encryptedPassword = "";
        }
        public string HostAddress { get { return hostAddress; } set { hostAddress = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string EncryptedPassword { get { return encryptedPassword; } set { encryptedPassword = value; } }
    }
}
