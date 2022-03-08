using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Platform.Web.Services.Interfaces;

namespace Platform.Web.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (_db.Roles.Any(x => x.Name == "Admin"))
            {
                return;
            }

            _roleManager.CreateAsync( new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync( new IdentityRole("Author")).GetAwaiter().GetResult();
            _roleManager.CreateAsync( new IdentityRole("Moderator")).GetAwaiter().GetResult();
            _roleManager.CreateAsync( new IdentityRole("User")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,

            }, "Admin@123").GetAwaiter().GetResult();

            IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}
