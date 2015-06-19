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

using Microsoft.Synchronization;
using System.Globalization;
using System.Threading;
using NyilvForms.Connection;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
        bool dataGridViewCellChanged;           //Indicates if a dataGridView cell is modified
        int changedRowIndex;

        UserData user;
        Connect myConnection;

        ConfigHandler myConfig;

        TreeNode currentnode;                   // Current Dokumentumok TreeNode reference

        int currentCegID = 1;                   // Current CegID regerence
        enum ImportCaller { Ceg, Dokumentum };  // Enum for importcommand
        int importcommand;                      // Registers, which import mode called the openFileDialog

        public MainWindow()
        {

            InitializeComponent();
            FormMiscellaneousInit();


        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Event functions ----------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MainWindow_Load(object sender, EventArgs e)
        {          
            myConfig = new ConfigHandler();
            myConfig.LoadConfig();

            Connect();
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
            List<Alapadatok> ClientList = GetAllAlapadat();
            if (ClientList != null)
            {
                if (ClientList.Count != 0)
                {
                    UpdateAlapadatokField(ClientList);
                    UpdateCegadatok(ClientList.First().CegID);
                    UpdateDokumentumok(ClientList.First().CegID);
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

        // Datagridview cell switch event
        private void alapadatokDataGridView_CellSwitch(object sender, EventArgs e)
        {
            int index = alapadatokDataGridView.CurrentCell.RowIndex;
            if (index >= 0)
            {
                int ID = (int)alapadatokDataGridView.Rows[index].Cells[0].Value;
                currentCegID = ID;
                UpdateCegadatok(ID);
                UpdateDokumentumok(ID);
            }
        }
        private void alapadatokDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCellChanged)
            {
                UpdateDatabase((Alapadatok)alapadatokDataGridView.Rows[changedRowIndex].DataBoundItem);
                dataGridViewCellChanged = false;
            }
        }

        // DataGridView Cell value changed
        private void alapadatokDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewCellChanged = true;
            changedRowIndex = e.RowIndex;
        }
        // DataGridView row leave
        // Delete DataGridView element
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveAlapadatokElement(currentCegID);
            RemoveCegadatokElement(currentCegID);
        }
        // Delete Cegadatok field update
        private void buttonCegadatFrissit_Click(object sender, EventArgs e)
        {
            Cegadatok ceg = (Cegadatok)cegadatokBindingSource.Current;
            if (ceg != null)
            {
                UpdateDatabase(ceg);
            }
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
        private void tarifaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ( (tarifaTextBox.Text != "") && !Regex.IsMatch(tarifaTextBox.Text, @"^\d+$"))
            {
                e.Cancel = true;
                tarifaTextBox.Select(0, tarifaTextBox.Text.Length);

                string errorMsg = "Helytelen számformátum!";
                this.errorProvider.SetError(tarifaTextBox, errorMsg);
            }
            else
            {
                this.errorProvider.SetError(tarifaTextBox, null);
            }            
        }
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            string emailString = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            
            if (!Regex.IsMatch(emailTextBox.Text, emailString, RegexOptions.IgnoreCase) && (emailTextBox.Text != "") )
            {
                e.Cancel = true;
                emailTextBox.Select(0, emailTextBox.Text.Length);

                string errorMsg = "Helytelen e-mail formátum!";
                this.errorProvider.SetError(emailTextBox, errorMsg);
            }
            else
            {
                this.errorProvider.SetError(emailTextBox, null);
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

        private void FormMiscellaneousInit()
        {
            tarifaTextBox.DataBindings["Text"].NullValue = string.Empty;

            //Init ComboBox parameteres
            //Make ComboBoxes not editable
            comboBoxFindElement.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFindCondiditon.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBoxFindElementInit();
            comboBoxFindCondiditon.ValueMember = "Name";

            dataGridViewCellChanged = false;
            alapadatokDataGridView.ReadOnly = true;
        }


        private static void ApplyResourceToControl(ComponentResourceManager res, Control control)
        {
            foreach (Control c in control.Controls)
                ApplyResourceToControl(res, c);

            var text = res.GetString(String.Format("{0}.Text", control.Name));
            control.Text = text ?? control.Text;
        }

        class ComboboxLanguageItem
        {
          public ComboboxLanguageItem(CultureInfo value, string text) { Culture = value; Text = text; }
          public CultureInfo Culture { get; set; }
          public string Text { get; set; }
          public override string ToString() { return Text; }
        }

        private void csatlakozasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reconnect();
        }
    }
}
