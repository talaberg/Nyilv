using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyilvForms
{
    public partial class Aremeles : Form
    {
        double emeles;
        public double Emeles
        {
            get { return emeles; }
            set {emeles = value; }
        }
        public Aremeles()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != "")
            {
                double parsedValue;
                if (!double.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("Helytelen érték!");
                }
                else
                {
                    Emeles = (double.Parse(textBox1.Text) / 100 + 1);
                }                
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nem adott meg értéket!");
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
