using System.ComponentModel.DataAnnotations;

namespace ORM_LINQ.Models
{
    public class City
    {
        [Key]
        public string Postalcode{ get; set; }
        public string Name { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public City(string postalcode, string name)
        {
            Postalcode = postalcode;
            Name = name;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}