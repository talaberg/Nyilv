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

    }
}