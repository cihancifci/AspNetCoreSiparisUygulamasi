using Microsoft.AspNetCore.Identity;
using SiparisNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiparisNetCore
{
    public class IdentityInitializer
    {
        public static void OlusturAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            AppUser appUser = new AppUser {
                name = "Cihan",
                surname = "Çifci",
                UserName = "chn"
            };
            if (userManager.FindByNameAsync("Yavuz").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser,"1").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "Admin"};
                var identityResult = roleManager.CreateAsync(role).Result;
                var result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
