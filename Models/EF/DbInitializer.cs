using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace HLAN.Models.EF
{
    public class DbInitializer
    {
        public static void InitializeAsync(HLANContext context, IServiceProvider service)
        {
            var logger = service.GetRequiredService<ILogger<DbInitializer>>();
           
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            logger.LogInformation("Start seeding the database.");

            AddRoles(service);

            AddUser(service, context);

            context.SaveChangesAsync();

            logger.LogInformation("Finished seeding the database.");
        }



        private static void AddRoles(IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var normalizer = service.GetRequiredService<ILookupNormalizer>();

            string[] roles = new string[] { "Admin", "Igrac", "Vlasnik", "Trener", "Sudac", "User" };

            foreach (string roleName in roles)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    var rola = new IdentityRole(roleName)
                    {
                        NormalizedName = normalizer.NormalizeName(roleName)
                    };
                    IdentityResult roleResult = roleManager.CreateAsync(rola).Result;
                }
            }
        }
        private static void AddUser(IServiceProvider service, HLANContext context)
        {
            var normalizer = service.GetRequiredService<ILookupNormalizer>();
            var userManager = service.GetRequiredService<UserManager<User>>();
            var logger = service.GetRequiredService<ILogger<DbInitializer>>();

            var user = new User
            {
                Ime = "Ante",
                Prezime = "Vulic",
                Broj = 1,
                Email = "avulic@foi.hr",
                NormalizedEmail = normalizer.NormalizeEmail("avulic@foi.hr"),
                EmailConfirmed = true,
                Pozicija = "FF",
                UserName = "avulic",
                NormalizedUserName = normalizer.NormalizeName("avulic"),
                Platio_clanarinu = true,
                PhoneNumber = "0919870537",
                PhoneNumberConfirmed = true,
                //OIB = "59586856896896896",
                Klub = null,
                Profilna = "logo",
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Adresa = "Trg hrvatskih Pavlina 2"
            };

            IdentityResult result = null;
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "AnteVulic.113");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User>(context);
                result = userStore.CreateAsync(user).Result;
            }
            if (!result.Succeeded)
            {
                logger.LogWarning("Default user not added");
                return;
            }

            AssignRoles(service, user.Email, "Admin");
            AssignRoles(service, user.Email, "Igrac");
        }

        public static async void AssignRoles(IServiceProvider services, string email, string roles)
        {
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            UserManager<User> _userManager = services.GetService<UserManager<User>>();
            User user = await _userManager.FindByEmailAsync(email);
            var result = _userManager.AddToRoleAsync(user, roles).Result;

            if (!result.Succeeded)
            {
                logger.LogWarning("Role for Default user not added");
            }
        }
    }
}
