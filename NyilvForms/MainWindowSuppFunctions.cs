using NyilvForms.Connection;
using NyilvLib;
using NyilvLib.Entities;
using NyilvLib.Forms;
using NyilvLib.Xml;
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
        // Init functions ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FormMiscellaneousInit()
        {

            //Init ComboBox parameteres
            //Make ComboBoxes not editable

            comboBoxFindCondiditon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFindCondiditon.ValueMember = "Name";

            ComboBoxFindElementInit();

            //dataGridViewCellChanged = false;


            //Datagridview header init
            foreach (DataGridViewColumn column in alapadatokDataGridView.Columns)
            {
                column.HeaderText = GuiConstants.GetHeader(column.HeaderText);
            }
            DataGridViewHeaderStyleUpdate();

            //Datafield init
            currentGroup = 1;

        }

        void ComboBoxFindElementInit()
        {
            comboBoxFindElement.DropDownStyle = ComboBoxStyle.DropDownList;

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
        ComboBox ComboBoxTelephelyekInit(List<Telephelyek> T)
        {
            ComboBox comboboxTelephelyek = new ComboBox();

            comboboxTelephelyek.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var t in T)
            {
                var element = new ComboboxItem(t.TelepID, t.Cim);
                comboboxTelephelyek.Items.Add(element);
            }

            comboboxTelephelyek.ValueMember = "Name";
            if (T.Count != 0)
            {
                comboboxTelephelyek.SelectedIndex = 0;
            }
            return comboboxTelephelyek;
        }
        ComboBox ComboBoxCegesSzemelyekInit(List<CegesSzemelyek> T)
        {
            ComboBox comboboxCegesSzemelyek = new ComboBox();

            comboboxCegesSzemelyek.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var t in T)
            {
                var element = new ComboboxItem(t.CegSzemID, t.Nev);
                comboboxCegesSzemelyek.Items.Add(element);
            }

            comboboxCegesSzemelyek.ValueMember = "Name";
            if (T.Count != 0)
            {
                comboboxCegesSzemelyek.SelectedIndex = 0;
            }

            return comboboxCegesSzemelyek;
        }

        ComboBox ComboBoxInaktiv_idoszakokInit(Inaktiv_idoszakok T)
        {
            ComboBox comboboxInaktiv = new ComboBox();

            comboboxInaktiv.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var t in T.Inaktiv_idoszak)
            {
                string toShow = t.Intervallum;
                var element = new ComboboxItem(t.Id, toShow);

                comboboxInaktiv.Items.Add(element);
            }

            comboboxInaktiv.ValueMember = "Name";
            if (T.Inaktiv_idoszak.Count != 0)
            {
                comboboxInaktiv.SelectedIndex = 0;
            }
            return comboboxInaktiv;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Data update ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateMiscJoinedDataBaseData()
        {
            // Get Telephelyek -------------
            string t = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Telephelyek;
            List<Telephelyek> T = new List<Telephelyek>();
            if (t != null)
            {
                List<int> telepek = MyXmlParser.Xml2IntList(t, XmlConstants.TelephelyTag, XmlConstants.TelephelyCollection);
                T = GetTelephelyek(telepek);
            }
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList = T;

            // Get Szekhely -------------
            int? id = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Szekhely;
            Telephelyek Sz = new Telephelyek();
            if (id != null)
            {
                List<int> szekhely = new List<int>();
                szekhely.Add((int)id);
                Sz = GetTelephelyek(szekhely).FirstOrDefault();
            }
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).SzekhelyData = Sz;

            // Get CegesSzemelyek -------------
            string ugyv = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Ugyvez_tagok;
            List<CegesSzemelyek> Ugyv = new List<CegesSzemelyek>();
            if (ugyv != null)
            {
                List<int> szemelyek = MyXmlParser.Xml2IntList(ugyv, XmlConstants.CegesSzemelyekTag, XmlConstants.CegesSzemelyekCollection);
                Ugyv = GetCegesSzemelyek(szemelyek);
            }
            ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList = Ugyv;

            // Get Inaktiv_idoszakok -------------
            if (((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakok != null)
            {
                string inaktiv_xml = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakok;
                ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakokList.Parse(inaktiv_xml);                
            }
            

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

        void ComboboxTelephelyekChangeHandler(object current)
        {
            string currentCim = current as string;
            Telephelyek currentTelep = ((JoinedDatabase)joinedDatabaseBindingSource.Current).TelephelyekList
                .Find(x => x.Cim == currentCim);

            datafield.Find(c => c.Number == 5).DataObj.Text = currentTelep.Cim;
            datafield.Find(c => c.Number == 6).DataObj.Text = currentTelep.Mettol.ToString();
            datafield.Find(c => c.Number == 7).DataObj.Text = currentTelep.Meddig.ToString();
        }
        void ComboboxCegesSzemelyekChangeHandler(object current)
        {
            string currentNev = current as string;
            CegesSzemelyek currentSzemely = ((JoinedDatabase)joinedDatabaseBindingSource.Current).CegesSzemelyekList
                .Find(x => x.Nev == currentNev);

            datafield.Find(c => c.Number == 2).DataObj.Text = currentSzemely.Nev;
            datafield.Find(c => c.Number == 3).DataObj.Text = currentSzemely.Taj.ToString();
            datafield.Find(c => c.Number == 4).DataObj.Text = currentSzemely.Szul_Ido.ToString();
            datafield.Find(c => c.Number == 5).DataObj.Text = currentSzemely.Anyja;
            datafield.Find(c => c.Number == 6).DataObj.Text = currentSzemely.Cime;
            datafield.Find(c => c.Number == 7).DataObj.Text = currentSzemely.Adoazon.ToString();
            datafield.Find(c => c.Number == 8).DataObj.Text = currentSzemely.Mettol.ToString();
            datafield.Find(c => c.Number == 9).DataObj.Text = currentSzemely.Meddig.ToString();
            datafield.Find(c => c.Number == 10).DataObj.Text = currentSzemely.Megbizas_minosege;
        }
        void ComboboxInaktiv_idoszakokChangeHandler(object current)
        {
            string currentIdo = current as string;
            Inaktiv_idoszak currentIdoszak = ((JoinedDatabase)joinedDatabaseBindingSource.Current).Inaktiv_idoszakokList.Inaktiv_idoszak
                .Find(x => x.Intervallum == currentIdo);

            datafield.Find(c => c.Number == 2).DataObj.Text = currentIdoszak.Mettol.ToString();
            datafield.Find(c => c.Number == 3).DataObj.Text = currentIdoszak.Meddig.ToString();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Error handling ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------

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
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Other functionalities ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
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

        Point GetLabelPos(int labelNum)
        {
            return new Point(Defines.LABEL_XPOS_BASE, (Defines.LABEL_YPOS_BASE + --labelNum * Defines.LABEL_YPOS_STEP));
        }
        Point GetControlPos(int controlNum)
        {
            return new Point(Defines.CONTROL_XPOS_BASE, (Defines.CONTROL_YPOS_BASE + --controlNum * Defines.CONTROL_YPOS_STEP));
        }
        Size GetControlSize()
        {
            Size s = new Size(0,Defines.CONTROL_HEIGHT);

            if (panelCegAdat.Width.CompareTo(Defines.CONTROL_XPOS_BASE) > 0)
	        {
                s = new Size(panelCegAdat.Width - Defines.CONTROL_XPOS_BASE - Defines.CONTROL_MARGIN, Defines.CONTROL_HEIGHT);
	        }

            return s;
        }
        
    }
}
