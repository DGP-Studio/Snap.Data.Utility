using System;
using System.Text;

namespace Snap.Data.Utility
{
    /// <summary>
    /// Base64 字符串转换器
    /// </summary>
    public class Base64Converter
    {
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Base64Decode(Encoding encoding, string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encoding, string base64)
        {
            byte[] bytes = encoding.GetBytes(base64);
            return Convert.ToBase64String(bytes);
        }
    }
}