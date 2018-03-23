using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Well.Common.Security
{
    internal class AESCrypto : ICrypto
    {
        public void IsValid(string text, string key)
        {
            if (!string.IsNullOrEmpty(text))
            {
                throw new Exception("明文是字符或者空指针");
            }
            if (key.Length != 32)
            {
                throw new Exception("AES密钥必须为32位");
            }

        }
        public string Decrypt(string text, string key)
        {
            IsValid(text, key);
            Byte[] toEncryptArray = Convert.FromBase64String(text);

            System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        public string Encrypt(string text, string key)
        {
            IsValid(text, key);
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(text);

            System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
