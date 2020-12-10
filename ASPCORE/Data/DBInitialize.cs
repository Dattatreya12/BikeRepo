using ASPCORE.AppDBContext;
using ASPCORE.Helpers;
using ASPCORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Data
{
    public class DBInitialize : IDBInitializer
    {
        private readonly VroomDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBInitialize(VroomDbContext db,
                                        UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void initialize()
        {
            //Add pending  migration if exists
            if(_db.Database.GetPendingMigrations().Count()>0)
            {
                _db.Database.Migrate();
            }
            
            //Exit if roles already exists
            if (_db.Roles.Any(r => r.Name == Helpers.Roles.Admin)) return;
            // Create Admin Role if roles are not exists
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();

            //Create Admin User
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
            }, "Admin@123").GetAwaiter().GetResult();

            //Assign Role to Admin User
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Admin"), Roles.Admin);
        }

       
    }
}
