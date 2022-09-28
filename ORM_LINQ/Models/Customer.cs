using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models
{
    //  Beispiel 1
    //  Beispiel für eine einzige Tabelle in der DB (ohne Verbindung zu anderen Tabellen)


    //  EntityFramework arbeitet sehr viel mit Namenskonventionen
    //      werden diese eingehalten, müssen die Tabellen, Felder, PK, ...
    //      nicht speziell angegeben werden
    //      trotzdem kann alles neu konfiguriert (andere Namen, ...) werden

    //  der ORM verwendet den Klassennamen um den Tabellennamen zu erzeugen

    //  wir schreiben vereinfachte Klassen (nur automatische Properties, keine ctors, ...)
    //      da wird die Klassen minimal halten wollen
    //  normalerweise muss das trotzdem gemacht werden
    public class Customer
    {
        //  wird ein Feld ID oder <Klassenname>ID gennant, 
        //      erzeugt der ORM daraus den PK
        public int CustomerId { get; set; } //  ->  Feldname in der Tabelle = Propertyname
                                            //      int Tabellendatentyp
        public string Firstname { get; set; }   //  Firstname (Feldname), longtext Datentyp
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public char Department { get; set; }    
        public decimal Salary { get; set; }
        public bool IsMarried { get; set; } // isMale im Unterricht
        public Gender Gender { get; set; }

        // ctor's + ToString()

    }
}
