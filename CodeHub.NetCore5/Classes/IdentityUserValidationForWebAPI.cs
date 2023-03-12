using Microsoft.AspNetCore.Identity;
using CodeHub.NetCore5.Models;
using CodeHub.NetCore5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeHub.NetCore5.Controllers;

namespace CodeHub.NetCore6.Classes
{
    public class IdentityUserValidationForWebAPI
    {
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly SignInManager<CustomIdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;
        public IdentityUserValidationForWebAPI(UserManager<CustomIdentityUser> userManager,
            SignInManager<CustomIdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        
        /// <summary>
        /// This function is created by MUA in order to validate user/password from another project for WEB API
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<bool> ValidateIdentityUserForWebAPI(string Email, string Password)
        {
            var user = await userManager.FindByEmailAsync(Email);

            if (user != null && !user.EmailConfirmed && (await userManager.CheckPasswordAsync(user, Password)))
            {
                return false;
            }

            var result = await signInManager.PasswordSignInAsync(Email,
                                    Password, false, true);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
