using Codehub.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace CodeHub.Classes
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (CodehubEntities entities = new CodehubEntities())
            {
                //MUA : Converting to hash

                byte[] salt = new byte[16];
                RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                random.GetNonZeroBytes(salt);

                SHA384CryptoServiceProvider sh = new SHA384CryptoServiceProvider();
                byte[] plainbytes = Encoding.ASCII.GetBytes(password);

                var saltedBytes = Combine(salt, plainbytes);
                var sha = sh.ComputeHash(saltedBytes);

                return entities.AspNetUsers.Any(user =>
                       user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.PasswordHash == password);
            }
        }

        private static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
    }
}