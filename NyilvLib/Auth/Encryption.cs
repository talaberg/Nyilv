using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace NyilvLib.Auth
{
    public static class Encryption
    {
        public static string Encrypt(string original)
        {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {

                myRijndael.Key = new byte[] { 0x25, 0x16, 0xAF, 0xF3, 0x19, 0x87, 0x50, 0x16, 0x17, 0x56, 0x50, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                myRijndael.IV = new byte[] { 0x25, 0x16, 0xAF, 0xF3, 0x19, 0x87, 0x50, 0x16, 0x17, 0x56, 0x50, 0x20, 0x20, 0x20, 0x20, 0x20 };
                // Encrypt the string to an array of bytes. 
                byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                // From byte array to string
                string encryptedString = Convert.ToBase64String(encrypted);

                return encryptedString;
            }
        }
        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream. 
            return encrypted;

        }
    }
}
