using Microsoft.EntityFrameworkCore;
using ORM_LINQ.Models;
using ORM_LINQ.Models.DB;

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
            var entity = context.Customers.Where(c => c.Firstname == "Tobias" && c.Lastname == "Laser").ToList<Customer>();
            if (entity.Count == 0)
            {
                var cTelfs = context.Cities.Where(c => c.Postalcode.Equals("06410")).ToList<City>();
                City telfs;
                if (cTelfs.Count == 0)
                {
                    telfs = new City("06410", "Telfs");
                }
                else
                {
                    telfs = cTelfs[0];
                }
                var aWeißenbachgasse1 = context.Addresses.Where(c => c.Street == "Weißenbachgasse" && c.Housenumber == "1").ToList<Address>();
                Address weißenbachgasse1;
                if (aWeißenbachgasse1.Count == 0)
                {
                     weißenbachgasse1= new Address(telfs, "Weißenbachgasse", "1");
                }
                else
                {
                    weißenbachgasse1 = aWeißenbachgasse1[0];
                }
                    
                context.Customers.Add(new Customer("Tobias", "Laser", new DateTime(2003, 01, 30), 'W', 2090.8m, false, Gender.male, weißenbachgasse1));
                Console.WriteLine(context.Customers.Find(1));
                await SaveToDB(context);
            }

            entity = context.Customers.Where(context => context.Firstname == "Erik" && context.Lastname == "Schmölzer").ToList<Customer>();
            Console.WriteLine(entity.Count);
            foreach(Customer customer in entity)
            {
                Console.WriteLine(customer);
            }
            if (entity.Count <= 1)
            {

                var cSomeCity = context.Cities.Where(c => c.Postalcode.Equals("06410")).ToList<City>();
                City someCity;
                if (cSomeCity.Count == 0)
                {
                    someCity = new City("012345", "SomeCity");
                }
                else
                {
                    someCity = cSomeCity[0];
                }
                var aSomeAddress = context.Addresses.Where(c => c.Street == "Weißenbachgasse" && c.Housenumber == "1").ToList<Address>();
                Address someAddress;
                if (aSomeAddress.Count == 0)
                {
                    someAddress = new Address(someCity, "Weißenbachgasse", "1");
                }
                else
                {
                    someAddress = aSomeAddress[0];
                }
                context.Customers.Add(new Customer("Erik", "Schmölzer", new DateTime(2004, 05, 15), 'W', 2090.8m, false, Gender.male, someAddress));
                if (entity.Count == 0)
                {
                    context.Customers.Add(new Customer("Erik", "Schmölzer", new DateTime(2004, 05, 15), 'W', 2090.8m, false, Gender.male, someAddress));
                }
                await SaveToDB(context);
            }

            
            // einen Customer suchen und löschen

            Customer eric = context.Customers.Where(c=> c.Firstname == "Erik" && c.Lastname== "Schmölzer").ToList<Customer>()[0];
            if (eric != null)
            {
                context.Customers.Remove(eric);
                await SaveToDB(context);
            }

            // einen Customer suchen und ändern
            Customer tobias = await context.Customers.FindAsync(1);
            if (tobias != null)
            {
                tobias.Salary = 10000.99m;
                Console.Write("Tobias wurde geändert");
                await SaveToDB(context);
            }

            // selber: 
            //  m:n -beziehung zwischen Artikel und Bill
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
            Console.WriteLine(dbucEx);
        }
        catch (DbUpdateException dbuEx)
        {
            Console.WriteLine("Fehler:\t Datenbank-Update fehlgeschlagen");
            Console.WriteLine(dbuEx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler:\t" + ex.Message);
            Console.WriteLine(ex);
        }

    }
}