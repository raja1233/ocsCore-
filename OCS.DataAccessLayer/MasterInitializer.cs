using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.DataAccessLayer
{
    public class MasterInitializer
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Seed(OnlineCatalogueSystemContext _context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _context.Database.EnsureCreated();
            if (_context.UserRoles.Any())
            {
                return;   // DB has been seeded
            }
            var userRoles = new UserRoles[]
            {
                new UserRoles { RoleName="Procurement",IsDeleted = false,IsActive=true},
                new UserRoles { RoleName="Buyer",IsDeleted = false,IsActive=true },
                new UserRoles { RoleName="Vendor",IsDeleted = false,IsActive=true },
            };
            foreach (var userRole in userRoles)
            {
                _context.UserRoles.Add(userRole);
            }
            _context.SaveChanges();

            //seed data for users//
            var users = new User[]
            {
                  new User
                {
                    AccessFailedCount = 0,
                   // Password = "d00f5d5217896fb7fd601412cb890830",
                    Password = "d00f5d5217896fb7fd601412cb890830",
                    UserName = "Procurement@yopmail.com",
                    IsActive = true,
                    IsDeleted = false,
                    RoleName = "Procurement",
                    FirstName="Super",
                    LastName="Admin",
                    RoleID = 1,
                    IsBlock = false,
                }
            };
            foreach (var user in users)
            {
                _context.User.Add(user);
            }
            _context.SaveChanges();
        }
    }
}
