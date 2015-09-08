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

        // api/Alapadatok/remove/{id}
        [HttpGet]
        [Route(ControllerFormats.DeleteAlapadatById.ControllerFormat, Name = ControllerFormats.DeleteAlapadatById.ControllerName)]
        public IHttpActionResult DeleteAlapadatok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Alapadatok ceg = ctx.Alapadatok.Where(c => c.CegID == id).FirstOrDefault<Alapadatok>();
                    if (ceg == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ctx.Alapadatok.Remove(ceg);
                        ctx.SaveChanges();
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteAlapadatById.ControllerFormat + " succes: data removed.");
                        Trace.Flush();
                        DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: RemoveAlapadat with id " + id.ToString());
                        DatabaseListener.Trace.Flush();
                        return Ok();
                    }
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteAlapadatById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
        // api/Cegadatok/remove/{id}
        [HttpGet]
        [Route(ControllerFormats.DeleteCegadatokById.ControllerFormat, Name = ControllerFormats.DeleteCegadatokById.ControllerName)]
        public IHttpActionResult DeleteCegadatok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Cegadatok ceg = ctx.Cegadatok.Where(c => c.CegID == id).FirstOrDefault<Cegadatok>();
                    if (ceg == null)
                    {
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteCegadatokById.ControllerFormat + " error: data not found.");
                        Trace.Flush();
                        return NotFound();
                    }
                    else
                    {
                        ctx.Cegadatok.Remove(ceg);
                        ctx.SaveChanges();
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteCegadatokById.ControllerFormat + " succes: data removed.");
                        Trace.Flush();
                        DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: RemoveCegadat with id " + id.ToString());
                        DatabaseListener.Trace.Flush();
                        return Ok();
                    }
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteCegadatokById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
        // api/Dokumentumok/remove/{id}
        [HttpGet]
        [Route(ControllerFormats.DeleteDokumentumokById.ControllerFormat, Name = ControllerFormats.DeleteDokumentumokById.ControllerName)]
        public IHttpActionResult DeleteDokumentumok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Dokumentumok doc = ctx.Dokumentumok.Where(c => c.DokumentumID == id).FirstOrDefault<Dokumentumok>();
                    if (doc == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ctx.Dokumentumok.Remove(doc);
                        ctx.SaveChanges();
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteDokumentumokById.ControllerFormat + " succes: data removed.");
                        Trace.Flush();
                        DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: RemoveDokumentum with id " + id.ToString());
                        DatabaseListener.Trace.Flush();
                        return Ok();
                    }
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.DeleteDokumentumokById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
    }
}