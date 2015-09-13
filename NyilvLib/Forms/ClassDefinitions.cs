using NyilvLib.Xml;
using NyilvLib.Forms;
using NyilvLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NyilvLib.String;

namespace NyilvLib.Forms
{
    
    public class Inaktiv_idoszak 
    {
        public static int IdCount = 0;

        public int Id;

        private DateTime? mettol;
        private DateTime? meddig;

        [XmlElement]
        public DateTime? Mettol
        {
            get
            {
                return mettol;
            }
            set
            {
                mettol = value;
                Intervallum = this.ToInterval();
            }
        }
        [XmlElement]
        public DateTime? Meddig
        {
            get
            {
                return meddig;
            }
            set
            {
                meddig = value;
                Intervallum = this.ToInterval();
            }
        }

        public string Intervallum;

        public Inaktiv_idoszak()
        {
            /*Meddig = new DateTime();
            Mettol = new DateTime();*/
            Intervallum = this.ToInterval();
            Id = Inaktiv_idoszak.IdCount++;
        }

        // Returns the date interval as string
        private string ToInterval()
        {
            string tol = "";
            string ig = "";
            if (mettol != null)
            {
                tol = ((DateTime)mettol).ToShortDateString();
            }
            if (meddig != null)
            {
                ig = ((DateTime)meddig).ToShortDateString();
            }
            return tol + " - " + ig;            
        }

        public override string ToString()
        {
            List<string> str = new List<string>();
            if (this.mettol != null) str.Add(GuiConstants.Inaktiv_idoszakok_Mettol.Text + GuiConstants.KulcsElvalasztojel.Text + this.mettol.ToString());
            if (this.meddig != null) str.Add(GuiConstants.Inaktiv_idoszakok_Meddig.Text + GuiConstants.KulcsElvalasztojel.Text + this.meddig.ToString());

            return StringHandler.BuildGuiString(str, GuiConstants.MezoElvalasztojel.Text);
        }
        public string ToXmlString()
        {
            return "<" + GuiConstants.Inaktiv_idoszakok_Mettol.Name + ">" + this.mettol.ToString() + "</" + GuiConstants.Inaktiv_idoszakok_Mettol.Name + ">" +
                   "<" + GuiConstants.Inaktiv_idoszakok_Meddig.Name + ">" + this.meddig.ToString() + "</" + GuiConstants.Inaktiv_idoszakok_Meddig.Name + ">";

        }
    }

    public class Inaktiv_idoszakok
    {
        [XmlElement]
        public List<Inaktiv_idoszak> Inaktiv_idoszak { get; set; }

        public Inaktiv_idoszakok()
        {
            Inaktiv_idoszak = new List<Inaktiv_idoszak>();
        }

        public void Parse(string xml)
        {
            Inaktiv_idoszak.Clear();

            Inaktiv_idoszakok I = new Inaktiv_idoszakok();

            if (xml != null)
            {
                XmlDocument doc = new XmlDocument();

                using (XmlTextReader inStream = new XmlTextReader(new StringReader(xml)))
                {
                    try
                    {
                        doc.Load(inStream);

                        // XmlNodeList NL = doc.GetElementsByTagName("Inaktiv_idoszak");
                        XmlNodeList NL = doc.SelectNodes("/" + XmlConstants.Inaktiv_idoszakokCollection + "/" + XmlConstants.Inaktiv_idoszakokTag);

                        foreach (XmlNode node in NL)
                        {
                            Inaktiv_idoszak ido = new Inaktiv_idoszak();

                            if (node[GuiConstants.Inaktiv_idoszakok_Meddig.Name] != null)
                            {
                                ido.Meddig = DateTime.Parse(node[GuiConstants.Inaktiv_idoszakok_Meddig.Name].InnerText);
                            }
                            if (node[GuiConstants.Inaktiv_idoszakok_Mettol.Name] != null)
                            {
                                ido.Mettol = DateTime.Parse(node[GuiConstants.Inaktiv_idoszakok_Mettol.Name].InnerText);
                            }

                            Inaktiv_idoszak.Add(ido);
                        }
                    }
                    catch (XmlException)
                    {
                        
                    }
                    
                }

            }
        }

        public string ToXml()
        {
            List<string> idoszakok = new List<string>();
            foreach (var item in Inaktiv_idoszak)
            {
                idoszakok.Add(item.ToXmlString());
            }
            return MyXmlParser.List2Xml(idoszakok,XmlConstants.Inaktiv_idoszakokTag,XmlConstants.Inaktiv_idoszakokCollection);
        }

        public override string ToString()
        {
            return this.Inaktiv_idoszak.ExtendedToString();
        }
    }

}
