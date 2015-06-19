using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Nyilv
{
    public static class DatabaseListener
    {
       static TextWriterTraceListener dbListener = new TextWriterTraceListener(@"C:\Users\TG\BME-Cubby\DotnetHF\DotnetHF\NyilvWebApi\Trace_databaseTransactions.log", "dbListener");

       public static TextWriterTraceListener Trace { get { return dbListener;  } }
    }
}