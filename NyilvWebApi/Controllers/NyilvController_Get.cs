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

        // GET api/Alapadatok/{id}
        [HttpGet]
        [Route(ControllerFormats.GetAlapadatById.ControllerFormat, Name = ControllerFormats.GetAlapadatById.ControllerName)]
        public IHttpActionResult GetAlapadatok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    var ceg = ctx.Alapadatok.SingleOrDefault(c => c.CegID == id);
                    if (ceg == null)
                    {
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetAlapadatById.ControllerFormat + " error: data not found.");
                        Trace.Flush();
                        return NotFound();
                    }
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetAlapadatById.ControllerFormat + " success: data sent.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: GetAlapadatok id " + id.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok(ceg);                    
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetAlapadatById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }
        // GET api/Cegadatok/{id}
        [HttpGet]
        [Route(ControllerFormats.GetCegadatokById.ControllerFormat, Name = ControllerFormats.GetCegadatokById.ControllerName)]
        public IHttpActionResult GetCegadatok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    var ceg = ctx.Cegadatok.SingleOrDefault(c => c.CegID == id);
                    if (ceg == null)
                    {
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetCegadatokById.ControllerFormat + " error: data not found.");
                        Trace.Flush();
                        return NotFound();
                    }
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetCegadatokById.ControllerFormat + " success: data sent.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: GetCegadatok id " + id.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok(ceg);
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetCegadatokById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }

        }

        // GET api/Dokumentumok/{id}
        [HttpGet]
        [Route(ControllerFormats.GetDokumentumokById.ControllerFormat, Name = ControllerFormats.GetDokumentumokById.ControllerName)]
        public IHttpActionResult GetDokumentumok(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    var doc = ctx.Dokumentumok.Where(c => c.CegID == id).ToList<Dokumentumok>();
                    if (doc == null)
                    {
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetDokumentumokById.ControllerFormat + " error: data not found.");
                        Trace.Flush();
                        return NotFound();
                    }
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetDokumentumokById.ControllerFormat + " success: data updated.");
                    Trace.Flush();
                    DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: GetDokumentumok id " + id.ToString());
                    DatabaseListener.Trace.Flush();
                    return Ok(doc);
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetDokumentumokById.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }

        }
        // GET api/Alapadatok/all
        [HttpGet]
        [Route(ControllerFormats.GetAlapadatAll.ControllerFormat)]
        public IHttpActionResult GetAll()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    var query = (
                            from ceg in ctx.Alapadatok
                            join kollega in ctx.Munkatarsak on ceg.Felelos1 equals kollega.MunkatarsID into join1
                            from kol1 in join1.DefaultIfEmpty()
                            join kollega in ctx.Munkatarsak on ceg.Felelos2 equals kollega.MunkatarsID into join2
                            from kol2 in join2.DefaultIfEmpty()
                            select new JoinedDatabase()
                            {
                                Container = ceg,
                                Felelos1 = (kol1 == null ? String.Empty : kol1.Nev),
                                Felelos2 = (kol2 == null ? String.Empty : kol2.Nev)
                            }
                        );

                    List<JoinedDatabase> cegek = query.ToList();
                    foreach (var ceg in cegek)
                    {
                        ceg.SetData();
                    }
                    return Ok(cegek);
                }
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.GetAlapadatAll.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }
        }

        // GET api/Munkatarsak
        [HttpGet]
        [Route(ControllerFormats.GetMunkatarsakAll.ControllerFormat)]
        public IHttpActionResult GetDokumentumok()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    var munkatarsak = new List<Munkatarsak>();
                    foreach (var munk in ctx.Munkatarsak)
                    {
                        munkatarsak.Add(munk);
                    }
                    if (munkatarsak.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(munkatarsak);
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/Telephelyek/{ids}
        [HttpPost]
        [Route(ControllerFormats.GetTelephelyek.ControllerFormat)]
        public IHttpActionResult GetTelephelyek([FromBody]List<int> ids)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    List<Telephelyek> Telepek = new List<Telephelyek>();

                    foreach (int id in ids)
                    {
                        Telephelyek hely = ctx.Telephelyek.Where(c => c.TelepID == id).FirstOrDefault();

                        if (hely != null)
                        {
                            Telepek.Add(hely);
                        }
                    }

                    if (Telepek == null)
                    {
                        return NotFound();
                    }
                    return Ok(Telepek);
                }
            }
            else
            {
                return NotFound();
            }

        }

        // GET api/CegesSzemelyek/{ids}
        [HttpPost]
        [Route(ControllerFormats.GetCegesSzemelyek.ControllerFormat)]
        public IHttpActionResult GetCegesSzemelyek([FromBody]List<int> ids)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    List<CegesSzemelyek> Telepek = new List<CegesSzemelyek>();

                    foreach (int id in ids)
                    {
                        CegesSzemelyek hely = ctx.CegesSzemelyek.Where(c => c.CegSzemID == id).FirstOrDefault();

                        if (hely != null)
                        {
                            Telepek.Add(hely);
                        }
                    }

                    if (Telepek == null)
                    {
                        return NotFound();
                    }
                    return Ok(Telepek);
                }
            }
            else
            {
                return NotFound();
            }

        }
        // GET api/Tevekenysegek/{ids}
        [HttpPost]
        [Route(ControllerFormats.GetTevekenysegek.ControllerFormat)]
        public IHttpActionResult GetTevekenysegek([FromBody]List<string> ids)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var ctx = new ModelNyilv())
                {
                    List<Tevekenysegek> tevekenysegek = new List<Tevekenysegek>();

                    if (ids.Contains(NyilvConstants.EVstring))
                    { //Table to use: TevekenysegekEV
                        ids.Remove(NyilvConstants.EVstring);

                        foreach (string id in ids)
                        {
                            TevekenysegekEV tevekenyseg = ctx.TevekenysegekEV.Where(c => c.ID == id).FirstOrDefault();

                            if (tevekenyseg != null)
                            {
                                tevekenysegek.Add(TevekenysegekEV2Tevekenysegek(tevekenyseg));
                            }
                            else
                            {
                                tevekenyseg = new TevekenysegekEV();
                                tevekenyseg.ID = id;
                                tevekenyseg.Megnevezes = NyilvConstants.EMPTY_TEVEKENYSEG;
                                tevekenysegek.Add(TevekenysegekEV2Tevekenysegek(tevekenyseg));
                            }
                        }

                    }
                    else
                    {//Table to use: Tevekenysegek
                        foreach (string id in ids)
                        {
                            Tevekenysegek tevekenyseg = ctx.Tevekenysegek.Where(c => c.ID == id).FirstOrDefault();

                            if (tevekenyseg != null)
                            {
                                tevekenysegek.Add(tevekenyseg);
                            }
                            else
                            {
                                tevekenyseg = new Tevekenysegek();
                                tevekenyseg.ID = id;
                                tevekenyseg.Megnevezes = NyilvConstants.EMPTY_TEVEKENYSEG;
                                tevekenysegek.Add(tevekenyseg);
                            }
                        }
                    }

                    if (tevekenysegek == null)
                    {
                        return NotFound();
                    }
                    return Ok(tevekenysegek);
                }
            }
            else
            {
                return NotFound();
            }

        }
        

    }
}
