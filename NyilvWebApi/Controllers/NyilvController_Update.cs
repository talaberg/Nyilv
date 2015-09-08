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
        //Modify Alapadatok element
        [HttpPost]
        [Route(ControllerFormats.UpdateAlapadat.ControllerFormat)]
        public IHttpActionResult PostAlapadat([FromBody]Alapadatok adat)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Alapadatok Item2Modify = ctx.Alapadatok
                            .Where(c => c.CegID == adat.CegID).FirstOrDefault<Alapadatok>();
                    if (Item2Modify == null)
                    {
                        adat.CegID = GenerateAlapadatokId();
                        ctx.Alapadatok.Add(adat);
                        ctx.Cegadatok.Add(new Cegadatok { CegID = adat.CegID });
                    }
                    else
                    {
                        ctx.Entry(Item2Modify).CurrentValues.SetValues(adat);
                    }
                    ctx.SaveChanges();

                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateAlapadat.ControllerFormat + " succes: data updated.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: UpdateAlapadat at id " + adat.CegID.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok();
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateAlapadat.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
        //Modify Cegadatok element
        [HttpPost]
        [Route(ControllerFormats.UpdateCegadatok.ControllerFormat)]
        public IHttpActionResult PostCegadat([FromBody]Cegadatok adat)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Cegadatok Item2Modify = ctx.Cegadatok
                            .Where(c => c.CegID == adat.CegID).FirstOrDefault<Cegadatok>();
                    if (Item2Modify == null)
                    {
                        ctx.Cegadatok.Add(adat);
                    }
                    else
                    {
                        ctx.Entry(Item2Modify).CurrentValues.SetValues(adat);
                    }
                    ctx.SaveChanges();
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateCegadatok.ControllerFormat + " success: data updated.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: UpdateCegadat at id " + adat.CegID.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok();
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateCegadatok.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
        //Modify Dokumentumok element
        [HttpPost]
        [Route(ControllerFormats.UpdateDokumentumok.ControllerFormat)]
        public IHttpActionResult PostCegadat([FromBody]Dokumentumok adat)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    Dokumentumok Item2Modify = ctx.Dokumentumok
                            .Where(c => c.DokumentumID == adat.DokumentumID).FirstOrDefault<Dokumentumok>();
                    if (Item2Modify == null)
                    {
                        ctx.Dokumentumok.Add(adat);
                    }
                    else
                    {
                        ctx.Entry(Item2Modify).CurrentValues.SetValues(adat);
                    }
                    ctx.SaveChanges();

                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateDokumentumok.ControllerFormat + " succes: data updated.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: UpdateDokumentumok at id " + adat.DokumentumID.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok();
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.UpdateDokumentumok.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
    }
}