using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Diagnostics;

using NyilvLib;
using NyilvLib.Entities;

using System.Reflection;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NyilvLib.Auth;

namespace Nyilv.Controllers
{
    public partial class NyilvController : ApiController
    {

        // api/aremeles/{ar}
        [HttpPost]
        [Route(ControllerFormats.Aremeles.ControllerFormat)]
        public IHttpActionResult Aremeles([FromBody]double ar)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    foreach (var ceg in ctx.Cegadatok)
                    {
                        if (ceg.Tarifa != null)
                        {
                            ceg.Tarifa = (int)((double)ceg.Tarifa * ar);
                        }
                    }
                    ctx.SaveChanges();
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.Aremeles.ControllerFormat + " succes.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: Aremeles with value " + ar.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok();
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.Aremeles.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }

        //Import Ceg XLS file
        [HttpPost]
        [Route(ControllerFormats.ImportCeg.ControllerFormat)]
        public HttpResponseMessage PostImportCeg()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                int i = 0;
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + file + (i++).ToString() + ".xlsx");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                MyXlsImporter.ImportCeg(docfiles);

                List<Alapadatok> importedItems = MyXlsImporter.ImportAlapadatokResult;
                List<Cegadatok> importedCegadatokItems = MyXlsImporter.ImportCegadatokResult;

                using (var ctx = new ModelNyilv())
                {
                    foreach (Alapadatok item in importedItems)
                    {
                        Alapadatok Item2Modify = ctx.Alapadatok
                                .Where(c => c.CegID == item.CegID).FirstOrDefault<Alapadatok>();
                        if (Item2Modify == null)
                        {
                            ctx.Alapadatok.Add(item);
                        }
                        else
                        {
                            // ctx.Entry(Item2Modify).CurrentValues.SetValues(item);
                        }
                    }
                    foreach (Cegadatok item in importedCegadatokItems)
                    {
                        Cegadatok Item2Modify = ctx.Cegadatok
                                .Where(c => c.CegID == item.CegID).FirstOrDefault<Cegadatok>();
                        if (Item2Modify == null)
                        {
                            ctx.Cegadatok.Add(item);
                        }
                        else
                        {
                            // ctx.Entry(Item2Modify).CurrentValues.SetValues(item);
                        }
                    }
                    ctx.SaveChanges();
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: importCeg");
                DatabaseListener.Trace.Flush();
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
        //Import Dokumentum XLS file
        [HttpPost]
        [Route(ControllerFormats.ImportDokumentum.ControllerFormat)]
        public HttpResponseMessage PostImportDokumentum()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                int i = 0;
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + file + (i++).ToString() + ".xlsx");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                MyXlsImporter.ImportDokumentum(docfiles);

                List<Dokumentumok> importedItems = MyXlsImporter.ImportDokumentumokResult;

                using (var ctx = new ModelNyilv())
                {
                    foreach (Dokumentumok item in importedItems)
                    {
                        Dokumentumok Item2Modify = ctx.Dokumentumok
                                .Where(c => c.DokumentumID == item.DokumentumID).FirstOrDefault<Dokumentumok>();
                        if (Item2Modify == null)
                        {
                            ctx.Dokumentumok.Add(item);
                        }
                        else
                        {
                            // ctx.Entry(Item2Modify).CurrentValues.SetValues(item);
                        }
                    }

                    ctx.SaveChanges();
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: importDokumentum");
                DatabaseListener.Trace.Flush();
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        //Authentication
        [HttpPost]
        [Route(ControllerFormats.Authenticate.ControllerFormat)]
        public IHttpActionResult PostAuth([FromBody]UserData data)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            string userPassword = Decryption.Decyrpt(data.EncryptedPassword);

            var user = userManager.Find(data.Username, userPassword);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.Authenticate.ControllerFormat + " user: " + data.Username + " : authenitcated.");
                Trace.Flush();
                return Ok();
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.Authenticate.ControllerFormat + " user: " + data.Username + " : authentication failed.");
                Trace.Flush();
                return NotFound();
            }

        }
    }
}