﻿using NyilvLib;
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
            }
            UpdateDataField(currentGroup);
            UpdateMiscJoinedDataBaseData();
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

            JoinedDatabase currentDataSource = (JoinedDatabase)joinedDatabaseBindingSource.Current;
            switch (group)
            {
                case 1:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Azonosito.Text, currentDataSource.Azonosito));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Cegnev.Text, currentDataSource.Cegnev));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), GuiConstants.Adoszam.Text, currentDataSource.Adoszam));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), GuiConstants.Ceg_forma.Text, currentDataSource.Ceg_forma));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), GuiConstants.Stat_szamjel.Text, currentDataSource.Stat_szamjel));
                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), GuiConstants.EU_adoszam.Text, currentDataSource.EU_adoszam));
                    datafield.Add(new TextBoxDataField(7, GetControlPos(7), GetLabelPos(7), GuiConstants.Cegjegyzek_szam.Text, currentDataSource.Cegjegyzek_szam));
                    datafield.Add(new TextBoxDataField(8, GetControlPos(8), GetLabelPos(8), GuiConstants.Nyilv_szam.Text, currentDataSource.Nyilv_szam));
                    break;
                case 2:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Szerzodott_AZNAP_ceg.Text, currentDataSource.Nyilv_szam));
                    datafield.Add(new ComboBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Felelos1.Text, munkatarsak, currentDataSource.Felelos1));
                    datafield.Add(new ComboBoxDataField(3, GetControlPos(3), GetLabelPos(3), GuiConstants.Felelos2.Text, munkatarsak, currentDataSource.Felelos2));
                    break;
                case 3:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Email.Text, currentDataSource.Email));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Hosszunev.Text, currentDataSource.Hosszunev));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(2), GuiConstants.Megalakulas.Text, currentDataSource.Megalakulas));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), GuiConstants.Bejegyzes.Text, currentDataSource.Bejegyzes));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), GuiConstants.Fotevekenyseg.Text, currentDataSource.Fotevekenyseg));
                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), GuiConstants.Tevekenyseg.Text, currentDataSource.Tevekenyseg));
                    datafield.Add(new TextBoxDataField(7, GetControlPos(7), GetLabelPos(7), GuiConstants.Tevekenyseg_vege.Text, currentDataSource.Tevekenyseg_vege));
                    break;
                case 4:
                    var lst = new List<int>();
                    lst.Add(int.Parse(alapadatokDataGridView.CurrentRow.Cells[18].Value.ToString()));
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Szekhely.Text, GetTelephelyek(lst)));

                    ComboBox c = ComboBoxTelephelyekInit(currentDataSource.TelephelyekList);
                    var currentTelep = currentDataSource.TelephelyekList.Find(x => x.TelepID == ((ComboboxItem)c.SelectedItem).ID);

                    datafield.Add(new ComboBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Telephelyek.Text, c));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), GuiConstants.Telephely_Cim.Text, currentTelep.Cim));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), GuiConstants.Telephely_Mettol.Text, currentTelep.Mettol));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), GuiConstants.Telephely_Meddig.Text, currentTelep.Meddig));

                    datafield.Add(new TextBoxDataField(6, GetControlPos(6), GetLabelPos(6), GuiConstants.Felhasznalonev.Text, currentDataSource.Felhasznalonev));
                    datafield.Add(new TextBoxDataField(7, GetControlPos(7), GetLabelPos(7), GuiConstants.Jelszo.Text, currentDataSource.Jelszo));
                    break;
                case 5:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Ugyvez_tagok.Text, currentDataSource.Ugyvez_tagok));
                    break;
                case 6:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Toke.Text, currentDataSource.Toke));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Nyilvantarto_birosag.Text, currentDataSource.Nyilvantarto_birosag));
                    datafield.Add(new TextBoxDataField(3, GetControlPos(3), GetLabelPos(3), GuiConstants.Ugyszam.Text, currentDataSource.Ugyszam));
                    datafield.Add(new TextBoxDataField(4, GetControlPos(4), GetLabelPos(4), GuiConstants.Birosagi_hatarozat_szam.Text, currentDataSource.Birosagi_hatarozat_szam));
                    datafield.Add(new TextBoxDataField(5, GetControlPos(5), GetLabelPos(5), GuiConstants.Kozhasznusag_fokozat.Text, currentDataSource.Kozhasznusag_fokozat));
                    break;
                case 7:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Inaktiv_idoszakok.Text, currentDataSource.Inaktiv_idoszakok));
                    datafield.Add(new TextBoxDataField(2, GetControlPos(2), GetLabelPos(2), GuiConstants.Felfuggesztett.Text, currentDataSource.Felfuggesztett));
                    break;
                case 8:
                    datafield.Add(new TextBoxDataField(1, GetControlPos(1), GetLabelPos(1), GuiConstants.Egyeb_adatok.Text, currentDataSource.Egyeb_adatok));
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
