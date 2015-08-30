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
        TreeNode currentnode;                   // Current Dokumentumok TreeNode reference



        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // UI update supplementary functions ----------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateAlapadatokField(List<JoinedDatabase> ClientList)
        {

            joinedDatabaseBindingSource.Clear();
            foreach (JoinedDatabase client in ClientList)
            {
                joinedDatabaseBindingSource.Add(client);
                UpdateMiscJoinedDataBaseData(client);
            }
            UpdateDataField(currentGroup);
            
        }
        private void UpdateMunkatarsak()
        {
            munkatarsak.Clear();
            List<Munkatarsak> m = GetMunkatarsak();

            munkatarsak.Add(new ComboboxItem(0, ""));

            foreach (var munkatars in m)
            {
                munkatarsak.Add(new ComboboxItem(munkatars.MunkatarsID, munkatars.Nev));
            }
        }

        private void UpdateCegFormak()
        {
            cegFormak.Clear();

            cegFormak.Add(new ComboboxItem(0, ""));

            int i = 1;

            foreach (var cegForma in Constants.CegesFormak.CegesFormakList)
            {
                cegFormak.Add(new ComboboxItem(i++, cegForma));
            }
        }

        private void UpdateDokumentumokField(List<Dokumentumok> documents)
        {
            throw new NotImplementedException();
            /*
            treeViewDokumentumok.Nodes.Clear();
            documents.OrderBy(c => c.Dokumentum_tipus);
            if (documents.Count != 0)
            {
                foreach (Dokumentumok doc in documents)
                {
                    TreeNode t;
                    if (treeViewDokumentumok.Nodes.ContainsKey(doc.Dokumentum_tipus))
                    {
                        t = treeViewDokumentumok.Nodes.Find(doc.Dokumentum_tipus, false)[0];
                    }
                    else
                    {
                        t = new TreeNode(doc.Dokumentum_tipus) { Name = doc.Dokumentum_tipus };
                        treeViewDokumentumok.Nodes.Add(t);
                    }

                    t.Nodes.Add(new TreeNode(doc.Datum.ToString()) { ToolTipText = doc.Megjegyzes, Tag = doc.DokumentumID });
                }
            }
            else
            {
                treeViewDokumentumok.Nodes.Add(new TreeNode("<Nincs megjelenítendő dokumentum>"));
            }
            */
        }

        void UpdateDataField(int group)
        {
            datafield = new List<ObjectDataField>();

            panelCegAdat.Controls.Clear();

            Size currSize = GetControlSize();

            JoinedDatabase currentDataSource = (JoinedDatabase)joinedDatabaseBindingSource.Current;
            switch (group)
            {
                case 1:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Azonosito.Text, currentDataSource.Azonosito));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Cegnev.Text, currentDataSource.Cegnev));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Adoszam.Text, currentDataSource.Adoszam));
                    datafield.Add(new ComboBoxDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Ceg_forma.Text, cegFormak, currentDataSource.Ceg_forma));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Ceg_forma.Text, currentDataSource.Ceg_forma));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), currSize, GuiConstants.Stat_szamjel.Text, currentDataSource.Stat_szamjel));
                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), currSize, GuiConstants.EU_adoszam.Text, currentDataSource.EU_adoszam));
                    datafield.Add(new TextBoxDataField(7, GetControlPos(7), GetLabelPos(7), currSize, GuiConstants.Cegjegyzek_szam.Text, currentDataSource.Cegjegyzek_szam));
                    datafield.Add(new TextBoxDataField(8, GetControlPos(8), GetLabelPos(8), currSize, GuiConstants.Nyilv_szam.Text, currentDataSource.Nyilv_szam));
                    
                    break;
                case 2:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Szerzodott_AZNAP_ceg.Text, currentDataSource.Nyilv_szam));
                    datafield.Add(new ComboBoxDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Felelos1.Text, munkatarsak, currentDataSource.Felelos1));
                    datafield.Add(new ComboBoxDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Felelos2.Text, munkatarsak, currentDataSource.Felelos2));
                    break;
                case 3:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Email.Text, currentDataSource.Email));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Hosszunev.Text, currentDataSource.Hosszunev));
                    datafield.Add(new DateTimeDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Megalakulas.Text, currentDataSource.Megalakulas));
                    datafield.Add(new DateTimeDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Bejegyzes.Text, currentDataSource.Bejegyzes));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), currSize, GuiConstants.Fotevekenyseg.Text, currentDataSource.Fotevekenyseg));
                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), currSize, GuiConstants.Fotevekenyseg.Text, currentDataSource.FotevekenysegData.Megnevezes,true));

                    ComboBox comTevekenyseg = ComboBoxTevekenysegekInit(currentDataSource.TevekenysegekList);
                    var currentTevekenyseg = currentDataSource.TevekenysegekList.Find(x => int.Parse(x.ID) == ((ComboboxItem)comTevekenyseg.SelectedItem).ID);
                    if (currentTevekenyseg == null)
                    {
                        currentTevekenyseg = new Tevekenysegek(); 
                    }

                    datafield.Add(new ComboBoxDataField(7, GetControlPos(7), GetLabelPos(7), currSize, GuiConstants.Telephelyek.Text, comTevekenyseg, new ComboboxChangeHandlerDelegate(ComboboxTevekenysegekChangeHandler)));
                    datafield.Add(new TextBoxDataField(8, GetControlPos(8), GetLabelPos(8), currSize, GuiConstants.Tevekenyseg_ID.Text, currentTevekenyseg.ID));
                    datafield.Add(new TextBoxDataField(9, GetControlPos(9), GetLabelPos(9), currSize, GuiConstants.Tevekenyseg_Megnevezes.Text, currentTevekenyseg.Megnevezes,true));
                    datafield.Add(new DateTimeDataField(10, GetControlPos(10), GetLabelPos(10), currSize, GuiConstants.Tevekenyseg_vege.Text, currentDataSource.Tevekenyseg_vege));
                    break;
                case 4:
                    var szekhely = currentDataSource.SzekhelyData;
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Szekhely.Text, szekhely.Cim));
                    datafield.Add(new DateTimeDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Telephely_Mettol.Text, szekhely.Mettol));
                    datafield.Add(new DateTimeDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Telephely_Meddig.Text, szekhely.Meddig));

                    ComboBox comTelepek = ComboBoxTelephelyekInit(currentDataSource.TelephelyekList);
                    var currentTelep = currentDataSource.TelephelyekList.Find(x => x.TelepID == ((ComboboxItem)comTelepek.SelectedItem).ID);
                    if (currentTelep == null)
                    {
                        currentTelep = new Telephelyek(); 
                    }

                    datafield.Add(new ComboBoxDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Telephelyek.Text, comTelepek, new ComboboxChangeHandlerDelegate(ComboboxTelephelyekChangeHandler)));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), currSize, GuiConstants.Telephely_Cim.Text, currentTelep.Cim));
                    datafield.Add(new DateTimeDataField(6, GetControlPos(6), GetLabelPos(6), currSize, GuiConstants.Telephely_Mettol.Text, currentTelep.Mettol));
                    datafield.Add(new DateTimeDataField(7, GetControlPos(7), GetLabelPos(7), currSize, GuiConstants.Telephely_Meddig.Text, currentTelep.Meddig));

                    datafield.Add(new TextBoxDataField(8, GetControlPos(8), GetLabelPos(8), currSize, GuiConstants.Felhasznalonev.Text, currentDataSource.Felhasznalonev));
                    datafield.Add(new TextBoxDataField(9, GetControlPos(9), GetLabelPos(9), currSize, GuiConstants.Jelszo.Text, currentDataSource.Jelszo));
                    break;
                case 5:
                    ComboBox comSzemelyek = ComboBoxCegesSzemelyekInit(currentDataSource.CegesSzemelyekList);
                    var currentSzemely = currentDataSource.CegesSzemelyekList.Find(x => x.CegSzemID == ((ComboboxItem)comSzemelyek.SelectedItem).ID);
                    if (currentSzemely == null)
                    {
                        currentSzemely = new CegesSzemelyek();
                    }

                    datafield.Add(new ComboBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Ugyvez_tagok.Text, comSzemelyek, new ComboboxChangeHandlerDelegate(ComboboxCegesSzemelyekChangeHandler)));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.CegesSzemely_Nev.Text, currentSzemely.Nev));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.CegesSzemely_Taj.Text, currentSzemely.Taj));
                    datafield.Add(new DateTimeDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.CegesSzemely_Szul_Ido.Text, currentSzemely.Szul_Ido));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), currSize, GuiConstants.CegesSzemely_Anyja.Text, currentSzemely.Anyja));
                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), currSize, GuiConstants.CegesSzemely_Cime.Text, currentSzemely.Cime));
                    datafield.Add(new TextBoxDataField(7, GetControlPos(7), GetLabelPos(7), currSize, GuiConstants.CegesSzemely_Adoazon.Text, currentSzemely.Adoazon));
                    datafield.Add(new DateTimeDataField(8, GetControlPos(8), GetLabelPos(8), currSize, GuiConstants.CegesSzemely_Mettol.Text, currentSzemely.Mettol));
                    datafield.Add(new DateTimeDataField(9, GetControlPos(9), GetLabelPos(9), currSize, GuiConstants.CegesSzemely_Meddig.Text, currentSzemely.Meddig));
                    datafield.Add(new TextBoxDataField(10, GetControlPos(10), GetLabelPos(10), currSize, GuiConstants.CegesSzemely_Megbizas_minosege.Text, currentSzemely.Megbizas_minosege));
                    break;
                case 6:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Toke.Text, currentDataSource.Toke));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Nyilvantarto_birosag.Text, currentDataSource.Nyilvantarto_birosag));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Ugyszam.Text, currentDataSource.Ugyszam));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Birosagi_hatarozat_szam.Text, currentDataSource.Birosagi_hatarozat_szam));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), currSize, GuiConstants.Kozhasznusag_fokozat.Text, currentDataSource.Kozhasznusag_fokozat));
                    break;
                case 7:
                    ComboBox comInaktiv_ido = ComboBoxInaktiv_idoszakokInit(currentDataSource.Inaktiv_idoszakokList);
                    var currentInaktiv_ido = currentDataSource.Inaktiv_idoszakokList.Inaktiv_idoszak.Find(x => x.Id == ((ComboboxItem)comInaktiv_ido.SelectedItem).ID);
                    if (currentInaktiv_ido == null)
                    {
                        currentInaktiv_ido = new Inaktiv_idoszak();
                    }

                    datafield.Add(new ComboBoxDataField(1, GetControlPos(1), GetLabelPos(1), currSize, GuiConstants.Inaktiv_idoszakok.Text, comInaktiv_ido, new ComboboxChangeHandlerDelegate(ComboboxInaktiv_idoszakokChangeHandler)));
                    datafield.Add(new DateTimeDataField(2, GetControlPos(2), GetLabelPos(2), currSize, GuiConstants.Inaktiv_idoszakok_Mettol.Text, currentInaktiv_ido.Mettol));
                    datafield.Add(new DateTimeDataField(3, GetControlPos(3), GetLabelPos(3), currSize, GuiConstants.Inaktiv_idoszakok_Meddig.Text, currentInaktiv_ido.Meddig));

                    datafield.Add(new CheckBoxDataField(4, GetControlPos(4), GetLabelPos(4), currSize, GuiConstants.Felfuggesztett.Text, currentDataSource.Felfuggesztett));
                    break;
                case 8:
                    datafield.Add(new RichTextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GetControlSize(6), GuiConstants.Egyeb_adatok.Text, currentDataSource.Egyeb_adatok));

                    break;
                default:
                    break;
            }

            foreach (var item in datafield)
            {
                panelCegAdat.Controls.Add(item.DataObj);
                panelCegAdat.Controls.Add(item.Label);
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

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // UI ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------

        void DataGridViewHeaderStyleUpdate()
        {
            alapadatokDataGridView.EnableHeadersVisualStyles = false;
            alapadatokDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif,
            8.0F, FontStyle.Bold);
            alapadatokDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int group = 0;
            int k = 0;
            for (int i = 0; i < alapadatokDataGridView.ColumnCount; i++)
            {
                DataGridViewColumn dtCol = alapadatokDataGridView.Columns[i];
                if (k == 0)
                {
                    k = GuiConstants.GroupDescription.GroupSize(++group);
                }

                switch (group)
                {
                    case 1:
                        dtCol.HeaderCell.Style.BackColor = Color.Gold;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 2:
                        dtCol.HeaderCell.Style.BackColor = Color.OliveDrab;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 3:
                        dtCol.HeaderCell.Style.BackColor = Color.SteelBlue;
                        dtCol.HeaderCell.Style.ForeColor = Color.Gold;
                        break;
                    case 4:
                        dtCol.HeaderCell.Style.BackColor = Color.OrangeRed;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 5:
                        dtCol.HeaderCell.Style.BackColor = Color.LightPink;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 6:
                        dtCol.HeaderCell.Style.BackColor = Color.LightSeaGreen;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 7:
                        dtCol.HeaderCell.Style.BackColor = Color.Chocolate;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    case 8:
                        dtCol.HeaderCell.Style.BackColor = Color.Wheat;
                        dtCol.HeaderCell.Style.ForeColor = Color.Black;
                        break;
                    default:
                        break;
                }
                k--;

            }
        }
    }
}
