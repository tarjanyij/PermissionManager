using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Models;

namespace PermissionManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
     
        public DbSet<PermissionManager.Models.Office> Offices { get; set; }
        public DbSet<PermissionManager.Models.Permission> Permissions { get; set; }
        public DbSet<PermissionManager.Models.Person> Persons { get; set; }

        public DbSet<PermissionManager.Models.Rights> Rights { get; set; }
        public DbSet<PermissionManager.Models.OfficeRights> OfficeRights { get; set; }
        public DbSet<PermissionManager.Models.PermissionLog> PermissionLog { get; set; }
        public DbSet<PermissionManager.Models.PermissionPaper> PermissionPaper { get; set; }

    }
}
