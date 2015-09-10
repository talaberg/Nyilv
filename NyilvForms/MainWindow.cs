using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using System.Net;
using NyilvLib;
using NyilvLib.Entities;
using NyilvForms.Configuration;

using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;
using NyilvForms.Connection;
using NyilvLib.Forms;
using NyilvLib.Xml;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
        // ---------------------------------------------------------------------------------------------------------
        // Variables -----------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------

        //Data flow --------------------------
        UserData user;
        Connect myConnection;                   //Connection handler

        List<ObjectDataField> datafield;
        List<ComboboxItem> munkatarsak;
        List<ComboboxItem> cegFormak;

        ConfigHandler myConfig;

        //Signal flow ------------------------
        //bool dataGridViewCellChanged;           //Indicates if a dataGridView cell is modified
        int changedRowIndex;                    //Indicates the changed row index
        int currentRow;
        int currentGroup;                       //Inidcates the current group

        int currentCegID = 1;                   // Current CegID regerence

        int importcommand;                      // Registers, which import mode called the openFileDialog

        // UI elements : MainWindowGuiUpdate.cs       

        // ---------------------------------------------------------------------------------------------------------
        // Functions -----------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------
        public MainWindow()
        {

            InitializeComponent();
            FormMiscellaneousInit();


            DataGridViewColumn c = alapadatokDataGridView.Columns[0];
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Event functions ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MainWindow_Load(object sender, EventArgs e)
        {          
            myConfig = new ConfigHandler();
            myConfig.LoadConfig();

            Connect();

            //combobox update
            munkatarsak = new List<ComboboxItem>();
            UpdateMunkatarsak();

            cegFormak = new List<ComboboxItem>();
            UpdateCegFormak();
        }

        //      Main menu events ----------------------------------------------------------------------------------------------------------------------------------------
        // Import Ceg type xls files
        private void cegimportalasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdImport.FileName = "";
            importcommand = (int)ImportCaller.Ceg;
            ofdImport.ShowDialog();
            
        }
        // Import Dokumentumok type xls files
        private void dokumentumokImportalasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdImport.FileName = "";
            importcommand = (int)ImportCaller.Dokumentum;
            ofdImport.ShowDialog();
            
        }
        // OpenFileDialog handler event
        private void ofdImport_FileOk(object sender, CancelEventArgs e)
        {
            using (var client = new WebClient())
            {

                string s = ofdImport.FileName;
                if (importcommand == (int)ImportCaller.Ceg)
                {
                    client.UploadFileAsync(new Uri(ControllerFormats.ImportCeg.ControllerUrl), ofdImport.FileName.ToString());
                }
                else if (importcommand == (int)ImportCaller.Dokumentum)
                {
                    client.UploadFileAsync(new Uri(ControllerFormats.ImportDokumentum.ControllerUrl), ofdImport.FileName.ToString());
                }                
            }
        }
        // Implements Aremeles function
        private void aremelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aremeles a = new Aremeles();
            a.ShowDialog();
            if (a.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Aremeles(a.Emeles);                
            }
        }

        //      UI events  ----------------------------------------------------------------------------------------------------------------------------------------------
        // Find button handler
        private void btFind_Click(object sender, EventArgs e)
        {
            RunFindQUery();
        }       
        // Load all elements
        private void buttonLoadAll_Click(object sender, EventArgs e)
        {
            List<JoinedDatabase> ClientList = GetAllAlapadat();
            if (ClientList != null)
            {
                if (ClientList.Count != 0)
                {
                    UpdateAlapadatokField(ClientList);
                }
            }
            else
            {
                MessageBox.Show("Hiba az adatlekérdezés során! Ellenőrizze a csatlakozási beállításokat!");
            }
        }
        // Find element combobox change event
        private void comboBoxFindElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxElementItem Item = (ComboBoxElementItem)comboBoxFindElement.SelectedItem;
            System.TypeCode ItemTypeCode = Type.GetTypeCode(Item.Type);

            ComboBoxFindConditionUpdate(ItemTypeCode);

        }
        // Find textbox keydown event
        private void textBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunFindQUery();
            }
        }

        private void alapadatokDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
            /*
            if (dataGridViewCellChanged)
            {
                if (changedRowIndex > 0)
                {
                    UpdateDatabase((Alapadatok)alapadatokDataGridView.Rows[changedRowIndex].DataBoundItem);
                    dataGridViewCellChanged = false;
                }
                
            }*/


        }

        // DataGridView Cell value changed
        private void alapadatokDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridViewCellChanged = true;
            changedRowIndex = e.RowIndex;
        }
        // DataGridView row leave
        // Delete DataGridView element

        private void alapadatokDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != currentRow)
            {
                UpdateMiscJoinedDataBaseData(((JoinedDatabase)joinedDatabaseBindingSource.Current));
                currentRow = e.RowIndex;
            }           

            int clickedGroup = GuiConstants.GetGroup(alapadatokDataGridView.Columns[e.ColumnIndex].DataPropertyName.ToString());
            if (currentGroup != clickedGroup)
            {
                currentGroup = clickedGroup;                
            }
            UpdateDataField(currentGroup);
        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveAlapadatokElement(currentCegID);
        }
        // Dokumentumok Tree View ------
        private void treeViewDokumentumok_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeViewDokumentumok.GetNodeAt(p);
                if (node != null)
                {
                    currentnode = node;
                    contextMenuDokumentumokNode.Show(Control.MousePosition);
                    treeViewDokumentumok.SelectedNode = node;
                }
            }
        }

        //      Toolstrip events --------------------------------------------------------------------------------------------------------------------
        // Add document
        private void hozzaadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumentumok doc = new Dokumentumok{
                CegID = currentCegID,
                 Dokumentum_tipus = currentnode.Parent != null ? currentnode.Parent.Text : currentnode.Text,
            };

            ManageDocument m = new ManageDocument(doc);
            m.ShowDialog();
            if (m.DialogResult == DialogResult.OK)
            {
                UpdateDatabase(m.Document);
                UpdateDokumentumok(currentCegID);
            }

        }
        // Modify document
        private void modositasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DokumentumokModify();
        }
        // Delete document
        private void eltavolitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentnode.Parent != null)
	        {
		        RemoveDokumentumokElement((int)currentnode.Tag);
                UpdateDokumentumok(currentCegID);
	        }
            
        }
        // Szerkesztés
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (alapadatokDataGridView.ReadOnly == true)
            {
                alapadatokDataGridView.ReadOnly = false;
                toolStripButtonEdit.CheckState = CheckState.Checked;
            }
            else
            {
                alapadatokDataGridView.ReadOnly = true;
                toolStripButtonEdit.CheckState = CheckState.Unchecked;
            }
        }
        // Exit
        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private static void ApplyResourceToControl(ComponentResourceManager res, Control control)
        {
            foreach (Control c in control.Controls)
                ApplyResourceToControl(res, c);

            var text = res.GetString(String.Format("{0}.Text", control.Name));
            control.Text = text ?? control.Text;
        }

        private void csatlakozasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reconnect();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }



    }
}
