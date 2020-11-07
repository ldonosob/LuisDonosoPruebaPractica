using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TestLuisDonoso.Util
{
    public class Funciones
    {
        /// <summary>
        /// Método que serializa texto en MD5
        /// </summary>
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] hashResult = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < hashResult.Length; i++)
            {
                strBuilder.Append(hashResult[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}