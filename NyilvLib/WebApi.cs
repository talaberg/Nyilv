using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib
{
    public static class WebApi
    {
        public static string DefaultHostAddress { get { return "http://localhost.fiddler:5112" /*"http://localhost:5112"*/; } }
    }
    public static class ControllerFormats
    {
        public static class GetAlapadatById
        {
            public const string ControllerFormat = "api/Alapadatok/{id}";
            public const string ControllerName = "GetAlapadatById";
            public static string ControllerUrl(int id) { return "/api/Alapadatok/" + id.ToString(); }
        }
        public static class GetCegadatokById
        {
            public const string ControllerFormat = "api/Cegadatok/{id}";
            public const string ControllerName = "ControllerGetCegadatokById";
            public static string ControllerUrl(int id) { return "/api/Cegadatok/" + id.ToString(); }
        }
        public static class GetDokumentumokById
        {
            public const string ControllerFormat = "api/Dokumentumok/{id}";
            public const string ControllerName = "ControllerGetDokumentumokById";
            public static string ControllerUrl(int id) { return "/api/Dokumentumok/" + id.ToString(); }
        }

        public static class GetAlapadatAll
        {
            public const string ControllerFormat = "api/Alapadatok/all";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class GetMunkatarsakAll
        {
            public const string ControllerFormat = "api/Munkatarsak/all";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class GetTelephelyek
        {
            public const string ControllerFormat = "api/Telephelyek";
            public const string ControllerName = "ControllerGetTelephelyek";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }            
        }
        public static class GetCegesSzemelyek
        {
            public const string ControllerFormat = "api/GetCegesSzemelyek";
            public const string ControllerName = "ControllerGetGetCegesSzemelyek";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }            
        }
        public static class GetTevekenysegek
        {
            public const string ControllerFormat = "api/GetTevekenysegek";
            public const string ControllerName = "ControllerGetTevekenysegek";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class FindAlapadat
        {
            public const string ControllerFormat = "api/Alapadatok/find";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class UpdateAlapadat
        {
            public const string ControllerFormat = "api/Alapadatok/update";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class UpdateCegadatok
        {
            public const string ControllerFormat = "api/Cegadatok/update";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class UpdateDokumentumok
        {
            public const string ControllerFormat = "api/Dokumentumok/update";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class DeleteAlapadatById
        {
            public const string ControllerFormat = "api/Alapadatok/delete/{id}";
            public const string ControllerName = "DeleteAlapadatokById";
            public static string ControllerUrl(int id) { return "/api/Alapadatok/delete/" + id.ToString(); }
        }
        public static class DeleteCegadatokById
        {
            public const string ControllerFormat = "api/Cegadatok/delete/{id}";
            public const string ControllerName = "DeleteCegadatokById";
            public static string ControllerUrl(int id) { return "/api/Cegadatok/delete/" + id.ToString(); }
        }
        public static class DeleteDokumentumokById
        {
            public const string ControllerFormat = "api/Dokumentumok/delete/{id}";
            public const string ControllerName = "DeleteDokumentumokById";
            public static string ControllerUrl(int id) { return "/api/Dokumentumok/delete/" + id.ToString(); }
        }

        public static class Aremeles
        {
            public const string ControllerFormat = "api/aremeles";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class ImportCeg
        {
            public const string ControllerFormat = "api/importCeg";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class ImportDokumentum
        {
            public const string ControllerFormat = "api/importDokumentum";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
        public static class Authenticate
        {
            public const string ControllerFormat = "api/Authenticate";
            public static string ControllerUrl { get { return "/" + ControllerFormat; } }
        }
    }
    public class UserData
    {
        string username;
        string encryptedpassword;
        public UserData(string user, string pass)
        {
            username = user;
            encryptedpassword = pass;
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string EncryptedPassword
        {
            get
            {
                return encryptedpassword;
            }
            set
            {
                encryptedpassword = value;
            }
        }
    }
}
