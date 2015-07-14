using NyilvForms.Connection;
using NyilvLib;
using NyilvLib.Entities;
using NyilvLib.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
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

            switch (group)
            {
                case 1:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Azonosito.Text,alapadatokDataGridView.CurrentRow.Cells[0].Value));
                    datafield.Add(new TextBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Cegnev.Text, alapadatokDataGridView.CurrentRow.Cells[1].Value));
                    datafield.Add(new TextBoxDataField(3, new Point(125, 105), new Point(20, 105), GuiConstants.Adoszam.Text, alapadatokDataGridView.CurrentRow.Cells[2].Value));
                    datafield.Add(new TextBoxDataField(4, new Point(125, 140), new Point(20, 140), GuiConstants.Ceg_forma.Text, alapadatokDataGridView.CurrentRow.Cells[3].Value));
                    datafield.Add(new TextBoxDataField(5, new Point(125, 175), new Point(20, 175), GuiConstants.Stat_szamjel.Text, alapadatokDataGridView.CurrentRow.Cells[4].Value));
                    datafield.Add(new TextBoxDataField(6, new Point(125, 210), new Point(20, 210), GuiConstants.EU_adoszam.Text, alapadatokDataGridView.CurrentRow.Cells[5].Value));
                    datafield.Add(new TextBoxDataField(7, new Point(125, 245), new Point(20, 245), GuiConstants.Cegjegyzek_szam.Text, alapadatokDataGridView.CurrentRow.Cells[6].Value));
                    datafield.Add(new TextBoxDataField(8, new Point(125, 280), new Point(20, 280), GuiConstants.Nyilv_szam.Text, alapadatokDataGridView.CurrentRow.Cells[7].Value));
                    break;
                case 2:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Szerzodott_AZNAP_ceg.Text, alapadatokDataGridView.CurrentRow.Cells[8].Value));
                    datafield.Add(new ComboBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Felelos1.Text,munkatarsak, alapadatokDataGridView.CurrentRow.Cells[9].Value));
                    datafield.Add(new ComboBoxDataField(3, new Point(125, 105), new Point(20, 105), GuiConstants.Felelos2.Text, munkatarsak, alapadatokDataGridView.CurrentRow.Cells[10].Value));
                    break;
                case 3:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Email.Text, alapadatokDataGridView.CurrentRow.Cells[11].Value));
                    datafield.Add(new TextBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Hosszunev.Text, alapadatokDataGridView.CurrentRow.Cells[12].Value));
                    datafield.Add(new TextBoxDataField(3, new Point(125, 105), new Point(20, 105), GuiConstants.Megalakulas.Text, alapadatokDataGridView.CurrentRow.Cells[13].Value));
                    datafield.Add(new TextBoxDataField(4, new Point(125, 140), new Point(20, 140), GuiConstants.Bejegyzes.Text, alapadatokDataGridView.CurrentRow.Cells[14].Value));
                    datafield.Add(new TextBoxDataField(5, new Point(125, 175), new Point(20, 175), GuiConstants.Fotevekenyseg.Text, alapadatokDataGridView.CurrentRow.Cells[15].Value));
                    datafield.Add(new TextBoxDataField(6, new Point(125, 210), new Point(20, 210), GuiConstants.Tevekenyseg.Text, alapadatokDataGridView.CurrentRow.Cells[16].Value));
                    datafield.Add(new TextBoxDataField(7, new Point(125, 245), new Point(20, 245), GuiConstants.Tevekenyseg_vege.Text, alapadatokDataGridView.CurrentRow.Cells[17].Value));
                    break;
                case 4:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Szekhely.Text, alapadatokDataGridView.CurrentRow.Cells[18].Value));
                    datafield.Add(new TextBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Telephelyek.Text, alapadatokDataGridView.CurrentRow.Cells[19].Value));
                    datafield.Add(new TextBoxDataField(3, new Point(125, 105), new Point(20, 105), GuiConstants.Felhasznalonev.Text, alapadatokDataGridView.CurrentRow.Cells[20].Value));
                    datafield.Add(new TextBoxDataField(4, new Point(125, 140), new Point(20, 140), GuiConstants.Jelszo.Text, alapadatokDataGridView.CurrentRow.Cells[21].Value));
                    break;
                case 5:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Ugyvez_tagok.Text, alapadatokDataGridView.CurrentRow.Cells[22].Value));
                    break;
                case 6:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Toke.Text, alapadatokDataGridView.CurrentRow.Cells[23].Value));
                    datafield.Add(new TextBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Nyilvantarto_birosag.Text, alapadatokDataGridView.CurrentRow.Cells[24].Value));
                    datafield.Add(new TextBoxDataField(3, new Point(125, 105), new Point(20, 105), GuiConstants.Ugyszam.Text, alapadatokDataGridView.CurrentRow.Cells[25].Value));
                    datafield.Add(new TextBoxDataField(4, new Point(125, 140), new Point(20, 140), GuiConstants.Birosagi_hatarozat_szam.Text, alapadatokDataGridView.CurrentRow.Cells[26].Value));
                    datafield.Add(new TextBoxDataField(5, new Point(125, 175), new Point(20, 175), GuiConstants.Kozhasznusag_fokozat.Text, alapadatokDataGridView.CurrentRow.Cells[27].Value));
                    break;
                case 7:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Inaktiv_idoszakok.Text, alapadatokDataGridView.CurrentRow.Cells[28].Value));
                    datafield.Add(new TextBoxDataField(2, new Point(125, 65), new Point(20, 65), GuiConstants.Felfuggesztett.Text, alapadatokDataGridView.CurrentRow.Cells[29].Value));
                    break;
                case 8:
                    datafield.Add(new TextBoxDataField(1, new Point(125, 30), new Point(20, 30), GuiConstants.Egyeb_adatok.Text, alapadatokDataGridView.CurrentRow.Cells[30].Value));
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
 
        void DataGridViewHeaderColor()
        {
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
                    case 1 :
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

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Other functions ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Connect()
        {
            myConnection = new Connect();
            try
            {
                myConnection.ConnectToServer(myConfig.Configuration);


                if (myConnection.Response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Reconnect();
                }
            }
            catch (Exception)
            {
                Reconnect();
            }
        }
        private void Reconnect()
        {
            Login userLogin = new Login("Adja meg a csatlakozás paramétereit!", myConfig.Configuration);

            userLogin.ShowDialog();

            if (userLogin.DialogResult == DialogResult.OK)
            {
                user = new UserData(userLogin.Configuration.Username, userLogin.Configuration.EncryptedPassword);
                myConnection = userLogin.Connection;
                myConfig.Configuration = userLogin.Configuration;
                myConfig.SaveConfig();
            }
            else
            {
                //TBD
            }
        }

        List<JoinedDatabase> GetAllAlapadat()
        {
            var resp = myConnection.Client.GetAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetAlapadatAll.ControllerUrl).Result;

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<JoinedDatabase>>().Result;

                return adat;
            }
            else
            {
                return null;
            }
        }
        List<Munkatarsak> GetMunkatarsak()
        {
            var resp = myConnection.Client.GetAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetMunkatarsakAll.ControllerUrl).Result;

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<Munkatarsak>>().Result;

                return adat;
            }
            else
            {
                return null;
            }
        }

        void RunFindQUery()
        {
            if (textBoxFind.Text != "")
            {
                ComboBoxElementItem Item = (ComboBoxElementItem)comboBoxFindElement.SelectedItem;
                ComboBoxConditionItem ItemCondition = (ComboBoxConditionItem)comboBoxFindCondiditon.SelectedItem;

                var query = new MyQuery() { Item2Find = Item.Name, Condition = ItemCondition.Condition, Value = textBoxFind.Text };


                var resp = myConnection.Client.PutAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.FindAlapadat.ControllerUrl, query).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var adat = resp.Content.ReadAsAsync<List<JoinedDatabase>>().Result;


                    if (adat.Count != 0)
                    {
                        UpdateAlapadatokField(adat);
                        UpdateDokumentumok(adat.First().CegID);
                    }
                    else
                    {
                        treeViewDokumentumok.Nodes.Clear();
                        joinedDatabaseBindingSource.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Nem található, vagy elvault verziójú lekérdezés!");
                }               
            }
        }

        void ComboBoxFindElementInit()
        {
            foreach (var prop in new Alapadatok().GetType().GetProperties())
            {
                if (prop.Name != "CegID")
                {
                    var element = new ComboBoxElementItem() { Name = prop.Name, Type = prop.PropertyType };
                    comboBoxFindElement.Items.Add(element); 
                }                
            }
            comboBoxFindElement.ValueMember = "Name";
            comboBoxFindElement.SelectedIndex = 0;
        }

        void ComboBoxFindConditionUpdate(TypeCode ItemTypeCode)
        {
            comboBoxFindCondiditon.Items.Clear();
            switch (ItemTypeCode)
            {
                case TypeCode.Boolean:
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Igen", Condition = MyQuery.TrueCondition });
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Nem", Condition = MyQuery.FalseCondition });
                    break;
                case TypeCode.String:
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Tartalmazza", Condition = MyQuery.ContainsCondition });
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Pontosan", Condition = MyQuery.EqualsCondition });
                    break;
                case TypeCode.Int32:
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Egyenlő", Condition = MyQuery.EqualsCondition });
                    break;
                default:
                    comboBoxFindCondiditon.Items.Add(new ComboBoxConditionItem() { Name = "Egyenlő", Condition = MyQuery.EqualsCondition });
                    break;
            }

            comboBoxFindCondiditon.SelectedIndex = 0;
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        void UpdateDatabase(Alapadatok data)
        {

            var resp = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.UpdateAlapadat.ControllerUrl, data).Result;
            resp.EnsureSuccessStatusCode();

        }

        void UpdateDatabase(Dokumentumok data)
        {

            var resp = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.UpdateDokumentumok.ControllerUrl, data).Result;
            resp.EnsureSuccessStatusCode();

        }

        void RemoveAlapadatokElement(int id)
        {
            var resp = myConnection.Client.GetAsync(new Uri(myConfig.Configuration.HostAddress + ControllerFormats.DeleteAlapadatById.ControllerUrl(id))).Result;

        }
        void RemoveDokumentumokElement(int id)
        {

            var resp = myConnection.Client.GetAsync(new Uri(myConfig.Configuration.HostAddress + ControllerFormats.DeleteDokumentumokById.ControllerUrl(id))).Result;

        }
        void DokumentumokModify()
        {
            Dokumentumok doc;
            if (currentnode.Parent != null) // child clicked
            {
                doc = new Dokumentumok
                {
                    DokumentumID = (int)currentnode.Tag,
                    CegID = currentCegID,
                    Dokumentum_tipus = currentnode.Parent.Text,
                    Megjegyzes = currentnode.ToolTipText,
                    Datum = DateTime.Parse(currentnode.Text)
                };
            }
            else //category clicked
            {
                doc = new Dokumentumok
                {
                    CegID = currentCegID,
                    Dokumentum_tipus = currentnode.Text
                };
            }
            ManageDocument m = new ManageDocument(doc);
            m.ShowDialog();
            if (m.DialogResult == DialogResult.OK)
            {
                UpdateDatabase(m.Document);
                UpdateDokumentumok(currentCegID);
            }

        }

        private void Aremeles(double p)
        {
            throw new NotImplementedException();
            /*
            var resp = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.Aremeles.ControllerUrl, p).Result;
            resp.EnsureSuccessStatusCode();

            if (alapadatokDataGridView.CurrentCell != null)
            {
                UpdateCegadatok(currentCegID);
            }      */      
        }



    }
}
