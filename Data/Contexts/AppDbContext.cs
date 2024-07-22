using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Core.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-6CT12S21\\SQLEXPRESS;Database=NTierArch;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
