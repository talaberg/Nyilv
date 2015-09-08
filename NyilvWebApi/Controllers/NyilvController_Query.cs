using NyilvLib;
using NyilvLib.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Nyilv.Controllers
{
    public partial class NyilvController : ApiController
    {
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