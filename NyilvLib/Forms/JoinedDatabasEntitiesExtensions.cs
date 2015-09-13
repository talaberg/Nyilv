using NyilvLib.Entities;
using NyilvLib.Forms;
using NyilvLib.String;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib.Entities
{
    public partial class Telephelyek
    {
        public Telephelyek()
        {
            TelepID = 0;
        }
        public override string ToString()
        {
            List<string> str = new List<string>();
            if (this.Cim != null) str.Add(GuiConstants .Telephely_Cim.Text + GuiConstants.KulcsElvalasztojel.Text + this.Cim);
            if (this.Mettol != null) str.Add(GuiConstants.Telephely_Mettol.Text + GuiConstants.KulcsElvalasztojel.Text + this.Mettol.ToString());
            if (this.Meddig != null) str.Add(GuiConstants.Telephely_Meddig.Text + GuiConstants.KulcsElvalasztojel.Text + this.Meddig.ToString());

            return StringHandler.BuildGuiString(str, GuiConstants.MezoElvalasztojel.Text);
        }
    }
    public partial class Tevekenysegek
    {
        public override string ToString()
        {
            List<string> str = new List<string>();
            if (this.ID != null) str.Add(GuiConstants.Tevekenyseg_ID.Text + GuiConstants.KulcsElvalasztojel.Text + this.ID);
            if (this.Megnevezes != null) str.Add(GuiConstants.Tevekenyseg_Megnevezes.Text + GuiConstants.KulcsElvalasztojel.Text + this.Megnevezes);

            return StringHandler.BuildGuiString(str, GuiConstants.MezoElvalasztojel.Text);
        }
    }

    public partial class CegesSzemelyek
    {
        public override string ToString()
        {
            List<string> str = new List<string>();
            if (this.Nev != null) str.Add(GuiConstants.CegesSzemely_Nev.Text + GuiConstants.KulcsElvalasztojel.Text + this.Nev);
            if (this.Taj != null) str.Add(GuiConstants.CegesSzemely_Taj.Text + GuiConstants.KulcsElvalasztojel.Text + this.Taj.ToString());
            if (this.Szul_Ido != null) str.Add(GuiConstants.CegesSzemely_Szul_Ido.Text + GuiConstants.KulcsElvalasztojel.Text + this.Szul_Ido.ToString());
            if (this.Anyja != null) str.Add(GuiConstants.CegesSzemely_Anyja.Text + GuiConstants.KulcsElvalasztojel.Text + this.Anyja);
            if (this.Cime != null) str.Add(GuiConstants.CegesSzemely_Cime.Text + GuiConstants.KulcsElvalasztojel.Text + this.Cime.ToString());
            if (this.Adoazon != null) str.Add(GuiConstants.CegesSzemely_Adoazon.Text + GuiConstants.KulcsElvalasztojel.Text + this.Adoazon.ToString());
            if (this.Mettol != null) str.Add(GuiConstants.CegesSzemely_Mettol.Text + GuiConstants.KulcsElvalasztojel.Text + this.Mettol.ToString());
            if (this.Meddig != null) str.Add(GuiConstants.CegesSzemely_Meddig.Text + GuiConstants.KulcsElvalasztojel.Text + this.Meddig.ToString());
            if (this.Megbizas_minosege != null) str.Add(GuiConstants.CegesSzemely_Megbizas_minosege.Text + GuiConstants.KulcsElvalasztojel.Text + this.Megbizas_minosege);

            return StringHandler.BuildGuiString(str, GuiConstants.MezoElvalasztojel.Text);
        }
    }
    public static class MyExtensions
    {
        public static string ExtendedToString<T>(this List<T> list)
        {
            string str = "";
            if (list.Count == 0)
            {
                return "";
            }
            else
            {
                foreach (var item in list)
                {
                    if (str != "")
                    {
                        str += "\n";
                    }

                    str += item.ToString();
                }

                return str;
            }

        }
    }
}
