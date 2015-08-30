using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NyilvLib.Forms;

namespace NyilvLib.String
{
    public static class StringHandler
    {
        public static string BuildGuiString(List<string> str, string Elvalaszto)
        {
            string s = "";
            if (str.Count != 0)
            {
                foreach (var item in str)
                {
                    if (item != null)
                    {
                        if (s != "")
                        {
                            s += Elvalaszto;
                        }
                        s += item;
                    }                   
                }

            }
            return s;
        }
    }
}
