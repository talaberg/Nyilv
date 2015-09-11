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
                                
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                            case 10:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        switch (item.Number)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        switch (item.Number)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                            case 10:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 6:
                        switch (item.Number)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 7:
                        switch (item.Number)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 8:
                        switch (item.Number)
                        {
                            case 1:
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
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
