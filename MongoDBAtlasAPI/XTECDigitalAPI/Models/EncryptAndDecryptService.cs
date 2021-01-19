using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace XTECDigitalAPI.Models
{
    public class EncryptAndDecryptService
    {
        private string hash = "#SMZ19";

        public string encrypts(string password) {
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            password = Convert.ToBase64String(results, 0, results.Length);
            return password;
        }
        public string decrypts(string passwordEncrp)
        {
            byte[] data = Convert.FromBase64String(passwordEncrp);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            passwordEncrp = UTF8Encoding.UTF8.GetString(results);
            return passwordEncrp;
        }
    }
}