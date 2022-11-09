﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        //  Consvention over Configuration
        //      hält man sich an die Konventionen (z.B. Id bzw. KlassennameId), muss nichts konfiguriert werden (Primärschlüssel)
        public int CustomerId { get; set; } //  ->  Feldname in der Tabelle = Propertyname
                                            //      int Tabellendatentyp
        public string Firstname { get; set; }   //  Firstname (Feldname), longtext Datentyp
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public char Department { get; set; }    
        public decimal Salary { get; set; }
        public bool IsMarried { get; set; } // isMale im Unterricht
        public Gender Gender { get; set; }
        public virtual Address Address { get; set; }
        public virtual Bill bill { get; set; }

        public Customer(string firstname, string lastname, DateTime birthdate, char department, decimal salary, bool isMarried, Gender gender, Address address)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
            this.Department = department;
            this.Salary = salary;
            this.IsMarried = isMarried;
            this.Gender = Gender;
            this.Address = address;
        }

        public Customer() : this("","",DateTime.MinValue, '#', 0.0m, false, Gender.undefined, new Address())
        {

        }

        public override string ToString()
        {
            return base.ToString()+this.Firstname;
        }
        // ctor's + ToString()

    }
}
