using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NyilvLib;
using System.Net.Http;
using NyilvForms.Configuration;
using NyilvLib.Auth;
using NyilvForms.Connection;

namespace NyilvForms
{
    public partial class Login : Form
    {
        string text;
        public Config Configuration { get; set; }
        public Connect Connection { get; set; }
        public Login(string text, Config c)
        {
            InitializeComponent();

            this.text = text;
            labelText.Text = text;

            Configuration = c;

            textBoxHost.Text = c.HostAddress;
            textBoxUsername.Text = c.Username;
            textBoxPassword.Text = Decryption.Decyrpt(c.EncryptedPassword);

            StartPosition = FormStartPosition.CenterParent;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            labelText.Text = "Autentikáció folyamatban, kérem várjon...";

            Configuration.Username = textBoxUsername.Text;

            Configuration.EncryptedPassword = Encryption.Encrypt(textBoxPassword.Text);

            Configuration.HostAddress = textBoxHost.Text;

            Connection = new Connect();

            try
            {
                Connection.ConnectToServer(Configuration);

                labelText.Text = text;

                if (Connection.Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Érvénytelen felhasználónév/jelszó kombináció!");
                } 
            }
            catch (Exception)
            {
                labelText.Text = text;
                MessageBox.Show("Csatlakozási hiba! A szerver nem elérhető vagy hibás a cím!");
            }


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOK_Click(sender, (EventArgs)e);
            }
        }
    }
}
