using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models
{
    public class Address
    {
        // n:m
        public int AddressId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }

        public Address(string postalcode, string name, string street, string housenumber)
        {
            this.City = new City(postalcode, name);
            this.Street = street;
            Housenumber = housenumber;
        }

        public Address() : this("00000", "city", "street", "housenumber")
        {

        }

        public override string ToString()
        {
            return "AddressId: "+this.AddressId+"\t"+this.City.ToString()+"\t"+this.Street.ToString()+"\t"+this.Housenumber;
        }
    }
}
