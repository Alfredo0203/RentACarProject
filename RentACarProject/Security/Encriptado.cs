using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RentACarProject.Security
{
    public class Encriptado
    {
        //Método de encriptado
        public static string EncryptPassword (string pass)
        {
            using (SHA1Managed sha = new SHA1Managed ())
            {  
                var text = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(text.Length * 2);

                foreach (byte b in text)
                {
                    sb.Append(b.ToString());
                }
                return sb.ToString();
            }
        }
    }
}