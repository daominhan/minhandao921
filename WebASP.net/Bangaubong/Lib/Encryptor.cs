using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Bangaubong.Lib
{
    public class Encryptor
    {
        public string MD5Hash(string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
             MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for(int i=0;i<result.Length;i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}