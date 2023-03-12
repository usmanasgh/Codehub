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
                var user = _userManager.Users.SingleOrDefault(p => p.PhoneNumber == model.PhoneNumber);
                if (user == null)
                {
                    return RedirectToAction(nameof(Login));
                }

                var result1 = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (result1 != PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
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