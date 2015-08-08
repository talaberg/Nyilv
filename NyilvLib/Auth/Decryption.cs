using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NyilvLib.Auth
{
    public static class Decryption
    {
        public static string Decyrpt(string encryptedString)
        {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {

                myRijndael.Key = new byte[] { 0x25, 0x16, 0xAF, 0xF3, 0x19, 0x87, 0x50, 0x16, 0x17, 0x56, 0x50, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                myRijndael.IV = new byte[] { 0x25, 0x16, 0xAF, 0xF3, 0x19, 0x87, 0x50, 0x16, 0x17, 0x56, 0x50, 0x20, 0x20, 0x20, 0x20, 0x20 };

                byte[] encrypted = Convert.FromBase64String(encryptedString);

                // Decrypt the bytes to a string. 
                string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                return roundtrip;
            }
        }
        private static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                return "";
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}