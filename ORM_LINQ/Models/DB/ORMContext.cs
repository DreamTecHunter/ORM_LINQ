using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ORM_LINQ.Models.DB
{
    //  Die von DBContext abgeleitete Klasse ist under Manager für den Zugriff
    //      auf die Datenbank
    //  diese Klasse ermöglicht das Laden, Speichern, Ändern, Hinzufügen und Abfragen von Einträgen
    public class ORMContext : DbContext
    {
        //  DBSet<Klassenname> ermöglicht den Zugriff auf die DB-Tabelle Customers
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        /*
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }

        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // eigener nutzer auf mysql mit begrenzten rechten (ohne)
            //optionsBuilder.UseMySQL("Server=localhost;database=orm_test_01;user=swp-vogt;password=swp-vogt");

            string connectionString = "Server=localhost;database=orm_test_01;user=swp-vogt;password=swp-vogt";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
