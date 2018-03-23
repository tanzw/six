using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Well.Common.Security
{
    public class CryptoService
    {
        internal const string PasswordKey = "P_@#123OP_@#123OP_@#123OP_@#1";

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">密文</param>
        /// <returns>明文</returns>
        public static string Decrypt(string text)
        {
            ICrypto crypto = new AESCrypto();
            return crypto.Decrypt(text, PasswordKey);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns>密文</returns>

        public static string Encrypt(string text)
        {
            ICrypto crypto = new AESCrypto();
            return crypto.Encrypt(text, PasswordKey);
        }


        #region MD5加密

        /// <summary>
        /// MD5加密32位
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt32(string text)
        {
            string result = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像

            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                result = result + s[i].ToString("X");
            }
            return result;
        }
        /// <summary>
        /// MD5加密64位
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt64(string text)
        {

            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(s);
        }
        #endregion


        #region SHA256

        /// <summary>
        /// SHA256方式获取哈希
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns>密文</returns>
        public static string SHA256Encrypt(string text)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            var encryptedBytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(text));
            return Convert.ToBase64String(encryptedBytes);
        }

        #endregion

    }
}
