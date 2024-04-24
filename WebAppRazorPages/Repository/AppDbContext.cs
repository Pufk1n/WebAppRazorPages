using Microsoft.EntityFrameworkCore;
using System;
using WebAppRazorPages.Model;
using WebAppRazorPages.Model.AuthApp;

namespace WebAppRazorPages.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Motorcycle>? Motorcycles { get; set; }
        public DbSet<AuthUser>? AuthUsers { get; set; }
    }
}
