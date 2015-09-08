using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib
{
    public static class NyilvConstants
    {
        public const string EVstring = "Table:TelephelyekEV";

        public static class CegesFormak
        {
            public const string ZRT = "Zrt";
            public const string NYRT = "Nyrt";
            public const string KFT = "Kft";
            public const string BT = "Bt";
            public const string EGYENI = "Egyéni vállalkozó";
            public const string ALAPITVANY = "Alapítvány";
            public const string EGYESULET = "Egyesület";
            public const string TARSASHAZ = "Társasház";
            public const string LAKASZOVETKEZET = "Lakásszövetkezet";
            public const string EGYEB = "Egyéb";

            public static List<string> CegesFormakList
            {
                get
                {
                    var lst = new List<string>();

                    lst.Add(CegesFormak.ZRT);
                    lst.Add(CegesFormak.NYRT);
                    lst.Add(CegesFormak.KFT);
                    lst.Add(CegesFormak.BT);
                    lst.Add(CegesFormak.EGYENI);
                    lst.Add(CegesFormak.ALAPITVANY);
                    lst.Add(CegesFormak.EGYESULET);
                    lst.Add(CegesFormak.TARSASHAZ);
                    lst.Add(CegesFormak.LAKASZOVETKEZET);
                    lst.Add(CegesFormak.EGYEB);

                    return lst;
                }
            }
        }
             
    }
}
