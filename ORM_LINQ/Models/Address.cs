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
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public virtual City City { get; set; }
        public virtual List<Customer> Customers{ get; set; }


        public Address(City city, string street, string housenumber)
        {
            this.City = city;
            this.Street = street;
            this.Housenumber = housenumber;
        }

        public Address() : this(new City("00000","somewhere"), "street", "housenumber")
        {

        }

        public override string ToString()
        {
            return "AddressId: "+this.AddressId+"\t"+this.City.ToString()+"\t"+this.Street.ToString()+"\t"+this.Housenumber;
        }

        public static implicit operator List<object>(Address v)
        {
            throw new NotImplementedException();
        }
    }
}
