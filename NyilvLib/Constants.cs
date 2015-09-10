using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NyilvLib
{
    public static class NyilvConstants
    {
        public const int CONTROL_HEIGHT = 20;
        public const int CONTROL_MARGIN = 10;
        public const int CONTROL_XPOS_BASE = 150;
        public const int CONTROL_YPOS_BASE = 40;
        public const int CONTROL_YPOS_STEP = 35;
        public const int LABEL_MARGIN = 5;
        public const int LABEL_XPOS_BASE = 20;
        public const int LABEL_YPOS_BASE = CONTROL_YPOS_BASE;
        public const int LABEL_YPOS_STEP = CONTROL_YPOS_STEP;  

        
        public enum ButtonTypes {Save=1};
        public static class SaveButtonProperties
        {
            public const string Text = "Mentés";
            public static Point Pos = new Point(LABEL_XPOS_BASE, LABEL_YPOS_BASE - LABEL_YPOS_STEP);

        }

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
