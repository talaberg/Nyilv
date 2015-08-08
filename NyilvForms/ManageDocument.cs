using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NyilvLib.Entities;

namespace NyilvForms
{
    public partial class ManageDocument : Form
    {
        Dokumentumok givenDocument;
        public Dokumentumok Document
        { 
            get
                {
                    givenDocument.Datum = (DateTime?)datumDateTimePicker.Value;
                    givenDocument.Megjegyzes = megjegyzesTextBox.Text;
                    givenDocument.Dokumentum_tipus = dokumentum_tipusTextBox.Text;
                    return givenDocument;
                }
        }
        public ManageDocument()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
        public ManageDocument(Dokumentumok doc)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            datumDateTimePicker.Value = doc.Datum == null ? DateTime.Now : (DateTime)doc.Datum;
            dokumentum_tipusTextBox.Text = doc.Dokumentum_tipus == null ? "" : doc.Dokumentum_tipus;
            megjegyzesTextBox.Text = doc.Megjegyzes == null ? "" : doc.Megjegyzes;

            givenDocument = doc;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        //protected override showdialog
       
    }
}
