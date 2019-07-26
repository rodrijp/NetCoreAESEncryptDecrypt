using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Password
{
    class Program
    {
        const string SALT = "adaaf3d45gfad34d"; // Random
        const string VECTOR = "aadf341asdf3dfgh"; 

        static byte[] GetKey(String keyString, int bytes)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(SALT);
            PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(keyString, saltBytes, "SHA256", 10);
            return _passwordBytes.GetBytes(bytes);
        }

        static String EncryptStringToBytes_Aes(String plainText, String keyString)
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

        static String DecryptStringToBytes_Aes(String cryptText, String keyString)
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

        static void Main(string[] args)
        {
            var keyString = "sadfsdafsda1Adasf324d";
            var plainText = "GOOGLE ES FANTASTICO Y MEJOR QUE BING";
            Console.WriteLine("keyString:" + keyString);
            Console.WriteLine("plainText:" + plainText);
            var cryptText = EncryptStringToBytes_Aes(plainText, keyString);
            Console.WriteLine("cryptText:" + cryptText);
            var decryptText = DecryptStringToBytes_Aes(cryptText, keyString);
            Console.WriteLine("decryptText:" + decryptText);
            Console.ReadKey();
        }



    }
}
