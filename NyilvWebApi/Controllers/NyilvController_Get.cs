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
        
        // PUT: api/Alapadatok/find
        [HttpPut]
        [Route(ControllerFormats.FindAlapadat.ControllerFormat)]
        public IHttpActionResult PutFind([FromBody]MyQuery query)
        {
             throw new NotImplementedException();
            //TODO
            /*
            if (User.Identity.IsAuthenticated)
            {
                DatabaseListener.Trace.WriteLine(DateTime.Now.ToString() + ": user: " + User.Identity.Name.ToString() + "transaction: FindQuery");
                DatabaseListener.Trace.Flush();
                using (var ctx = new ModelNyilv())
                {
                    List<Alapadatok> result = null;

                    switch (query.Item2Find)
                    {
                        case "Azonosito":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                int val = (int)Int32.Parse(query.Value);
                                result = ctx.Alapadatok.Where(c => c.CegID == val).ToList<Alapadatok>();
                            }
                            break;

                        case "Szamlazas":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Szamlazas == query.Value).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.ContainsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Szamlazas.Contains(query.Value)).ToList<Alapadatok>();
                            }
                            break;

                        case "Felelos":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Felelos == query.Value).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.ContainsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Felelos.Contains(query.Value)).ToList<Alapadatok>();
                            }
                            break;

                        case "Cegnev":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Cegnev == query.Value).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.ContainsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Cegnev.Contains(query.Value)).ToList<Alapadatok>();
                            }
                            break;

                        case "Ceg_forma":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Ceg_forma == query.Value).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.ContainsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Ceg_forma.Contains(query.Value)).ToList<Alapadatok>();
                            }
                            break;

                        case "Hivatkozas":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Hivatkozas == query.Value).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.ContainsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Hivatkozas.Contains(query.Value)).ToList<Alapadatok>();
                            }
                            break;

                        case "Felfuggesztett":
                            if (query.Condition == MyQuery.EqualsCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Felfuggesztett == bool.Parse(query.Value)).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.TrueCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Felfuggesztett == true).ToList<Alapadatok>();
                            }
                            else if (query.Condition == MyQuery.FalseCondition)
                            {
                                result = ctx.Alapadatok.Where(c => c.Felfuggesztett != true).ToList<Alapadatok>();
                            }
                            break;

                        default:
                            break;
                    }

                    if (result == null)
                    {
                        Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.FindAlapadat.ControllerFormat + " succes: data not found.");
                        Trace.Flush();
                        return NotFound();
                    }
                    Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.FindAlapadat.ControllerFormat + " succes: data sent.");
                    Trace.Flush();
                    return Ok(result);
                }

  
            }
            else
            {
                Trace.TraceInformation(DateTime.Now.ToString() + ": " + ControllerFormats.FindAlapadat.ControllerFormat + " error: authentication failed.");
                Trace.Flush();
                return NotFound();
            }*/

        }
    }
}
