using NyilvForms.Configuration;
using NyilvLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NyilvForms.Connection
{
    public class Connect
    {
        public HttpClient Client { get; set; }
        public HttpResponseMessage Response { get; set; }
        public void ConnectToServer(Config conf)
        {
            Client = new HttpClient();

            UserData data = new UserData(conf.Username, conf.EncryptedPassword);
            try
            {
                Response = Client.PostAsJsonAsync(conf.HostAddress + ControllerFormats.Authenticate.ControllerUrl, data).Result;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
