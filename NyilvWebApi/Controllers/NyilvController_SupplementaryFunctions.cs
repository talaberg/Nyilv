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
        int GenerateAlapadatokId()
        {
            int maxId = -1;
            using (var ctx = new ModelNyilv())
            {
                maxId = ctx.Alapadatok.FirstOrDefault(c => c.CegID == ctx.Alapadatok.Max(e => e.CegID)).CegID;

                // new ID: maxId + 1 :
                if (++maxId <= 0) // Overflow --> find new ID
                {
                    int i = 1;
                    while (ctx.Alapadatok.Where(c => c.CegID == i).FirstOrDefault<Alapadatok>() != null)
                    {
                        i++;
                        if (i <= 0) return -1; //Error
                    }
                    maxId = i;
                }
            }
            return maxId;

        }

    }
}