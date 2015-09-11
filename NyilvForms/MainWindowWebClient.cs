using NyilvForms.Connection;
using NyilvLib;
using NyilvLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
        // -------------------------------------------------------------------------------------------------------
        // Connection --------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
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
        // -------------------------------------------------------------------------------------------------------
        // Web queries -------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
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
        List<Telephelyek> GetTelephelyek(List<int> ids)
        {
            var x = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetTelephelyek.ControllerUrl, ids);
            var resp = x.Result;
            

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<Telephelyek>>().Result;

                return adat;
            }
            else
            {
                return null;
            }
        }
        List<CegesSzemelyek> GetCegesSzemelyek(List<int> ids)
        {
            var x = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetCegesSzemelyek.ControllerUrl, ids);
            var resp = x.Result;


            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<CegesSzemelyek>>().Result;

                return adat;
            }
            else
            {
                return null;
            }
        }

        List<Tevekenysegek> GetTevekenysegek(List<string> ids, bool ev)
        {
            if (ev)
            {
                ids.Add(NyilvConstants.EVstring);
            }
            var x = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.GetTevekenysegek.ControllerUrl, ids);
            var resp = x.Result;


            if (resp.StatusCode == HttpStatusCode.OK)
            {
                var adat = resp.Content.ReadAsAsync<List<Tevekenysegek>>().Result;

                return adat;
            }
            else
            {
                return null;
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
        private void UploadChanges()
        {
            JoinedDatabase data = (JoinedDatabase)joinedDatabaseBindingSource.Current;
            if (data != null)
            {
                var resp = myConnection.Client.PostAsJsonAsync(myConfig.Configuration.HostAddress + ControllerFormats.UpdateDatabase.ControllerUrl, data).Result;
            }
            
        }

        void RemoveAlapadatokElement(int id)
        {
            var resp = myConnection.Client.GetAsync(new Uri(myConfig.Configuration.HostAddress + ControllerFormats.DeleteAlapadatById.ControllerUrl(id))).Result;

        }
        void RemoveDokumentumokElement(int id)
        {

            var resp = myConnection.Client.GetAsync(new Uri(myConfig.Configuration.HostAddress + ControllerFormats.DeleteDokumentumokById.ControllerUrl(id))).Result;
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
    }
}
