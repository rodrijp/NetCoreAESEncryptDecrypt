using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordLibrary
{
    public static class PasswordUtil
    {
        const string SALT = "adaaf3d45gfad34d"; // Random
        const string VECTOR = "aadf341asdf3dfgh";

        static byte[] GetKey(String keyString, int bytes)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(SALT);
            PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(keyString, saltBytes, "SHA256", 10);
            return _passwordBytes.GetBytes(bytes);
        }

        public static String EncryptStringToBytes_Aes(String plainText, String keyString)
        {

            byte[] encrypted;
            var key = GetKey(keyString, 32);
            var vector = GetKey(VECTOR, 16);
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = vector;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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
            return Convert.ToBase64String(encrypted);

        }

        public static String DecryptStringToBytes_Aes(String cryptText, String keyString)
        {

            var crypted = Convert.FromBase64String(cryptText);
            string plaintext = null;
            var key = GetKey(keyString, 32);
            var vector = GetKey(VECTOR, 16);
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = vector;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msDecrypt = new MemoryStream(crypted))
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
            // Return the encrypted bytes from the memory stream.
            return plaintext;
        }

        public static String HashString(String plainText, String keyString)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(SALT);
            var password = keyString + plainText;
            var hashed = KeyDerivation.Pbkdf2(
                     password: password,
                     salt: saltBytes,
                     prf: KeyDerivationPrf.HMACSHA512,
                     iterationCount: 10000,
                     numBytesRequested: 256 / 8);
            return Convert.ToBase64String(hashed);
        }


    }
}
