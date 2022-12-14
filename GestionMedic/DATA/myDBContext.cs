using GestionMedic.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Reflection;
using System.IO;

namespace GestionMedic.DATA
{
    public class MyDbContext : DbContext
    {
        public DbSet<categories> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=gsb_csv;user=root;password=");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categories>().HasKey(c => c.id).HasName("PrimaryKey_Numero");
            modelBuilder.Entity<medicaments>().HasKey(m => m.id).HasName("PrimaryKey_Numero");
            modelBuilder.Entity<categories>().HasMany(c => c.medicaments).WithOne(m => m.categories).HasForeignKey(m => m.id_categorie);

        }


    }

}
