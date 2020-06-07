using System.Reflection;
using PasswordLibrary;
using PasswordLibrary.Config;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Password
{
    class Program
    {

        static void Main(string[] args)
        {
            var keyString = "sadfsdafsda1Adasf324d";
            var plainText = "GOOGLE ES FANTASTICO Y MEJOR QUE BING";
            Console.WriteLine("keyString:" + keyString);
            Console.WriteLine("plainText:" + plainText);
            var cryptText = PasswordUtil.EncryptStringToBytes_Aes(plainText, keyString);
            Console.WriteLine("cryptText:" + cryptText);
            var decryptText = PasswordUtil.DecryptStringToBytes_Aes(cryptText, keyString);
            Console.WriteLine("decryptText:" + decryptText);
            var hashText = PasswordUtil.HashString(plainText, keyString);
            Console.WriteLine("hashText:" + hashText);
            
            var s = ServiceUtil.ServiceConfig.Services;
            ServiceUtil.Add(new Service() { Name = "pepe", Size = 12, IncludeEspecialChar = true });
            Console.WriteLine("File Created");

           


            Console.ReadKey();

        }



    }
}
