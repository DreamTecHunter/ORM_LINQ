using ORM_LINQ.Models.DB;
using ORM_LINQ.Models;

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
            context.Customers.Add(new Customer()
            {
                Firstname="Tobias", Lastname="Laser", Birthdate=new DateTime(2003,1,30), Department = 'W', 
                Gender = Gender.male, IsMarried = false, Salary=2090.8m
            });

            //  Wichtig: erst durch den Aufruf von SavChangesAsync() werden die Daten zur 
            //      DB übertragen
            await context.SaveChangesAsync();
        }

    }
}