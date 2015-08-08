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
        // Init functions ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FormMiscellaneousInit()
        {

            //Init ComboBox parameteres
            //Make ComboBoxes not editable

            comboBoxFindCondiditon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFindCondiditon.ValueMember = "Name";

            ComboBoxFindElementInit();

            dataGridViewCellChanged = false;


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
                comboBoxFindElement.Items.Add(element);
            }

            comboboxTelephelyek.ValueMember = "Name";
            comboboxTelephelyek.SelectedIndex = 0;

            return comboboxTelephelyek;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Data update ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------

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
    }
}
