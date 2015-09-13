using NyilvLib;
using NyilvLib.Entities;
using NyilvLib.Forms;
using NyilvLib.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
        bool result = false;
        int tmpInt = 0;
        
        void SaveData()
        {
            List<Tevekenysegek> updatedTevekenysegek = new List<Tevekenysegek>();

            foreach (var item in datafield)
            {
                switch (currentGroup)
                {
                    case 1:
                        switch (item.Number)
                        {
                            case 1:
                                result = int.TryParse(((TextBoxDataField)item).Data.Text, out tmpInt);
                                if (result)
                                {
                                    ((JoinedDatabase)joinedDatabaseBindingSource.Current).Azonosito = tmpInt;
                                }
                                break;
                            case 2:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Cegnev = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 3:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Adoszam = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 4:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Ceg_forma = ((ComboBoxDataField)item).Data.Text;
                                break;
                            case 5:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Stat_szamjel = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 6:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).EU_adoszam = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 7:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Cegjegyzek_szam = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 8:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Nyilv_szam = ((TextBoxDataField)item).Data.Text;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (item.Number)
                        {
                            case 1:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Szerzodott_AZNAP_ceg = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 2:

                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Felelos1 = ((ComboboxItem)((ComboBoxDataField)item).Data.SelectedItem).Name;
                                break;
                            case 3:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Felelos2 = ((ComboboxItem)((ComboBoxDataField)item).Data.SelectedItem).Name;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (item.Number)
                        {
                            case 1:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Email = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 2:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Hosszunev = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 3:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Megalakulas = ((DateTimeDataField)item).Data.Value;
                                break;
                            case 4:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Bejegyzes = ((DateTimeDataField)item).Data.Value;
                                break;
                            case 5:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Fotevekenyseg = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 6:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).FotevekenysegDataText = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 7:
                                //Handled outside this case structure
                                break;
                            case 8:
                                //Updated in combobox events
                                break;
                            case 9:
                                //Updated in combobox events
                                break;
                            case 10:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Tevekenyseg_vege = ((DateTimeDataField)item).Data.Value;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        switch (item.Number)
                        {
                            case 1:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).SzekhelyData.Cim = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 2:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).SzekhelyData.Mettol = ((DateTimeDataField)item).Data.Value;
                                break;
                            case 3:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).SzekhelyData.Meddig = ((DateTimeDataField)item).Data.Value;
                                break;
                            case 4:
                                //Handled outside this case structure
                                break;
                            case 5:
                                //Updated in combobox events
                                break;
                            case 6:
                                //Updated in combobox events
                                break;
                            case 7:
                                //Updated in combobox events
                                break;
                            case 8:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Felhasznalonev = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 9:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Jelszo = ((TextBoxDataField)item).Data.Text;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        switch (item.Number)
                        {
                            case 1:
                                //Handled outside this case structure
                                break;
                            case 2:
                                //Updated in combobox events
                                break;
                            case 3:
                                //Updated in combobox events
                                break;
                            case 4:
                                //Updated in combobox events
                                break;
                            case 5:
                                //Updated in combobox events
                                break;
                            case 6:
                                //Updated in combobox events
                                break;
                            case 7:
                                //Updated in combobox events
                                break;
                            case 8:
                                //Updated in combobox events
                                break;
                            case 9:
                                //Updated in combobox events
                                break;
                            case 10:
                                //Updated in combobox events
                                break;
                            default:
                                break;
                        }
                        break;
                    case 6:
                        switch (item.Number)
                        {
                            case 1:
                                result = int.TryParse(((TextBoxDataField)item).Data.Text, out tmpInt);
                                if (result)
                                {
                                    ((JoinedDatabase)joinedDatabaseBindingSource.Current).Toke = tmpInt;
                                }
                                break;
                            case 2:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Nyilvantarto_birosag = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 3:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Ugyszam = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 4:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Birosagi_hatarozat_szam = ((TextBoxDataField)item).Data.Text;
                                break;
                            case 5:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Kozhasznusag_fokozat = ((TextBoxDataField)item).Data.Text;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 7:
                        switch (item.Number)
                        {
                            case 1:
                                //Handled outside this case structure
                                break;
                            case 2:
                                //Handled outside this case structure
                                break;
                            case 3:
                                //Handled outside this case structure
                                break;
                            case 4:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Felfuggesztett = ((CheckBoxDataField)item).Data.Checked;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 8:
                        switch (item.Number)
                        {
                            case 1:
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Egyeb_adatok = ((RichTextBoxDataField)item).Data.Text;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            // Update tevekenysegek xml ------------------------------------------------------------------------------
            List<string> tevekenysegek = new List<string>();
            foreach (var entry in ((JoinedDatabase)joinedDatabaseBindingSource.Current).TevekenysegekList)
            {
                tevekenysegek.Add(entry.ID);
            }
            string tevekenysegekXml = MyXmlParser.List2Xml(tevekenysegek, XmlConstants.TevekenysegekTag, XmlConstants.TevekenysegekCollection);
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).Tevekenyseg = tevekenysegekXml;

            // Update telephelyek xml ------------------------------------------------------------------------------
            List<int> telephelyek = new List<int>();
            foreach (var entry in ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList)
            {
                telephelyek.Add(entry.TelepID);
            }
            string telephelyekXml = MyXmlParser.List2Xml(telephelyek, XmlConstants.TelephelyTag, XmlConstants.TelephelyCollection);
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).Telephelyek = telephelyekXml;

            // Update ceges szemelyek xml ------------------------------------------------------------------------------
            List<int> cegesszemelyek = new List<int>();
            foreach (var entry in ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList)
            {
                cegesszemelyek.Add(entry.CegSzemID);
            }
            string cegesszemelyekXml = MyXmlParser.List2Xml(cegesszemelyek, XmlConstants.CegesSzemelyekTag, XmlConstants.CegesSzemelyekCollection);
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).Ugyvez_tagok = cegesszemelyekXml;

            // Update inaktiv idoszakok xml ------------------------------------------------------------------------------
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakok = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakokList.ToXml();

        }
        void ComboboxChangedHandler(object sender, EventArgs e)
        {
            bool ComboboxItemChanged = false;
            ObjectDataField item = (ObjectDataField)sender;

            bool handlerCondition = datafield.Count != 0;
            if (handlerCondition)
            {
                switch (currentGroup)
                {
                    case 3:
                        string item2find3 = ((ComboBoxDataField)datafield.Find(c => c.Number == 7)).Data.SelectedItem.ToString();
                        switch (item.Number)
                        {
                            case 9:
                                TextBoxDataField tb = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).TevekenysegekList.Find(c => c.ID == item2find3).ID = tb.Data.Text;
                                ComboboxItemChanged = true;
                                break;
                            case 10:
                                // no need to update
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        string item2find4 = ((ComboBoxDataField)datafield.Find(c => c.Number == 4)).Data.SelectedItem.ToString();
                        switch (item.Number)
                        {
                            case 5:
                                TextBoxDataField tb = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList.Find(c => c.Cim == item2find4).Cim = tb.Data.Text;
                                ComboboxItemChanged = true;
                                break;
                            case 6:
                                DateTimeDataField dt1 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList.Find(c => c.Cim == item2find4).Mettol = dt1.Data.Value;
                                break;
                            case 7:
                                DateTimeDataField dt2 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList.Find(c => c.Cim == item2find4).Meddig = dt2.Data.Value;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        bool result;
                        int tmpInt;
                        string item2find5 = ((ComboBoxDataField)datafield.Find(c => c.Number == 1)).Data.SelectedItem.ToString();
                        switch (item.Number)
                        {
                            case 2:
                                TextBoxDataField tb = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Nev = tb.Data.Text;
                                ComboboxItemChanged = true;
                                break;
                            case 3:
                                TextBoxDataField tb2 = sender as TextBoxDataField;
                                result = int.TryParse(tb2.Data.Text, out tmpInt);
                                if (result)
                                {
                                    ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Taj = tmpInt;
                                }
                                break;
                            case 4:
                                DateTimeDataField dt1 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Szul_Ido = dt1.Data.Value;
                                break;
                            case 5:
                                TextBoxDataField tb3 = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Anyja = tb3.Data.Text;
                                break;
                            case 6:
                                TextBoxDataField tb4 = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Cime = tb4.Data.Text;
                                break;
                            case 7:
                                TextBoxDataField tb5 = sender as TextBoxDataField;
                                result = int.TryParse(tb5.Data.Text, out tmpInt);
                                if (result)
                                {
                                    ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Adoazon = tmpInt;
                                }
                                break;
                            case 8:
                                DateTimeDataField dt2 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Mettol = dt2.Data.Value;
                                break;
                            case 9:
                                DateTimeDataField dt3 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Meddig = dt3.Data.Value;
                                break;
                            case 10:
                                TextBoxDataField tb6 = sender as TextBoxDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList.Find(c => c.Nev == item2find5).Megbizas_minosege = tb6.Data.Text;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 7:
                        string item2find7 = ((ComboBoxDataField)datafield.Find(c => c.Number == 1)).Data.SelectedItem.ToString();
                        switch (item.Number)
                        {
                            case 2:
                                DateTimeDataField tb = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakokList.Inaktiv_idoszak.Find(c => c.Intervallum == item2find7).Mettol = tb.Data.Value;
                                ComboboxItemChanged = true;
                                break;
                            case 3:
                                DateTimeDataField tb2 = sender as DateTimeDataField;
                                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakokList.Inaktiv_idoszak.Find(c => c.Intervallum == item2find7).Mettol = tb2.Data.Value;
                                ComboboxItemChanged = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }            
            if (ComboboxItemChanged)
            {
                UpdateDataField(currentGroup);
            }
            
        }


        bool UpdateDokumentumok(int ID)
        {
            throw new NotImplementedException();
            /*
            var resp = myConnection.Client.GetAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetDokumentumokById.ControllerUrl(ID)).Result;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<Dokumentumok>>().Result;

                UpdateDokumentumokField(adat);
                return true;
            }
            else
            {
                return false;
            }*/

        }
    }
}
