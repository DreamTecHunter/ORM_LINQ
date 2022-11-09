using ORM_LINQ.Models.DB;
using ORM_LINQ.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace ORM_LINQ;

public class Program
{
    //  ORM ... Object Relation Mapper
    //      Objekte (Klassen/Instanzen) werden auf Relationen (Tabellen)
    //      gemappt (es sind keine SQL-Befehle mehr notwendig:
    //      kein create table, insert, select, ...)

    //  EntityFramework ist der ORM von Microsoft

    //  LINQ to Entitities  ... die Datenbanktabellen können mit LINq
    //      abgefragt werden (fast identisch zu LINQ to Ibjects)
    public static async Task Main(string[] args)
    {
        Console.WriteLine("DB erzeugen!");
        using (ORMContext context = new ORMContext())
        {
            //  Vorsicht: alle Einträge in der DB (allen Tabellen) werden gelöscht 
            //      Lösung: Migration verwenden
            //await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            //  Achtung: der neue Customer ist nur im RAM vorhanden - er wurde noch nicht 
            //      zu Datenbank übertragen
            var entity = context.Customers.Where(context => context.Firstname == "Tobias" && context.Lastname == "Laser").ToList();
            if (entity.Count == 0)
            {
                context.Customers.Add(new Customer()
                {
                    Firstname = "Tobias",
                    Lastname = "Laser",
                    Birthdate = new DateTime(2003, 01, 30),
                    Department = 'W',
                    Gender = Gender.male,
                    IsMarried = false,
                    Salary = 2090.8m,
                    Address = new Address("16410", "Telfs", "Weißenbachgasse", "1"),
                });
                await SaveToDB(context);
            }
            entity = context.Customers.Where(context => context.Firstname == "Erik" && context.Lastname == "Schmölzer").ToList();
            if (entity.Count == 0)
            {
                context.Customers.Add(new Customer()
                {
                    Firstname = "Erik",
                    Lastname = "Schmölzer",
                    Birthdate = new DateTime(2004, 05, 15),
                    Department = 'W',
                    Gender = Gender.male,
                    IsMarried = false,
                    Salary = 2090.8m,
                    Address = new Address("01234", "SomeCity", "SomeStreet", "SomeNumber")
                });
                context.Customers.Add(new Customer()
                {
                    Firstname = "Erik",
                    Lastname = "Schmölzer",
                    Birthdate = new DateTime(2004, 05, 15),
                    Department = 'W',
                    Gender = Gender.male,
                    IsMarried = false,
                    Salary = 2090.8m,
                    Address = new Address("01234", "SomeCity", "SomeStreet", "SomeNumber")
                });
                await SaveToDB(context);
            }
            Console.WriteLine(context.Customers.Find(1));
            // einen Customer suchen und löschen
            Console.WriteLine("hier");
            return;
            Customer eric = await context.Customers.FindAsync(2);
            if (eric != null)
            {
                context.Customers.Remove(eric);
                await SaveToDB(context);
            }

            // einen Customer suchen und ändern
            Customer tobias = await context.Customers.FindAsync(3);
            if (tobias != null)
            {
                tobias.Address.City.Postalcode = "06410";
                Console.Write("Tobias wurde geändert");
                await SaveToDB(context);
            }

            // selber: 
            //  m:n -berziehung zwischen Artikel und Bill
            //      price in article - standardpreis
            //      price irgendwo - aktionspreis
            //      Anzahl der bestellten  artikel
        }
    }
    public static async Task SaveToDB(DbContext context)
    {
        try
        {
            //  Wichtig: erst durch den Aufruf von SavChangesAsync() werden die Daten zur 
            //      DB übertragen
            await context.SaveChangesAsync();
            Console.WriteLine("Worked!");

        }
        catch (DbUpdateConcurrencyException dbucEx)
        {
            Console.WriteLine("Fehler:\tDatenbank - gleichzeitiger zugriff");
        }
        catch (DbUpdateException dbuEx)
        {
            Console.WriteLine("Fehler:\t Datenbank-Update fehlgeschlagen");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler:\t" + ex.Message);
        }

    }
}