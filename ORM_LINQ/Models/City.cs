using System.ComponentModel.DataAnnotations;

namespace ORM_LINQ.Models
{
    public class City
    {
        [Key]
        public string Postalcode{ get; set; }
        public string Name { get; set; }
        public City(string postalcode, string name)
        {
            Postalcode = postalcode;
            Name = name;
        }
    }
}