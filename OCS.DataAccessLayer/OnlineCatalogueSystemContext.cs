using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.DataAccessLayer
{
    public class OnlineCatalogueSystemContext: DbContext
    {
        public OnlineCatalogueSystemContext(DbContextOptions<OnlineCatalogueSystemContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Models.AuthenticationToken> AuthenticationToken { get; set; }
    }
}
