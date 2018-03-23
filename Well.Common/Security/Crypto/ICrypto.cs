using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Common.Security
{
    internal interface ICrypto
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">明文字符</param>
        /// <param name="key">密钥</param>
        /// <returns>加密字符</returns>
        string Encrypt(string text, string key);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="key">密钥</param>
        /// <returns>明文字符</returns>
        string Decrypt(string text, string key);

    }
}
