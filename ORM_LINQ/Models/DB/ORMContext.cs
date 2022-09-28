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
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // eigener nutzer auf mysql mit begrenzten rechten (ohne)
            optionsBuilder.UseMySQL("Server=localhost;database=orm_test_01;user=swp-vogt;password=swp-vogt");
        }
    }
}
