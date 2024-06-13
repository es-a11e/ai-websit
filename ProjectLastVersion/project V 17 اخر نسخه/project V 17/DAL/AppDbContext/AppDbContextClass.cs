using DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppDbContext
{
    public class AppDbContextClass:IdentityDbContext<ApplicationUser>
    {
        public AppDbContextClass(DbContextOptions<AppDbContextClass> options):base(options)
        {
            
        }
      

        public DbSet<Person> Persons { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
