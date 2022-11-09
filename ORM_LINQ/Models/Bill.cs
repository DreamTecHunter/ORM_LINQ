using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public decimal Prize { get; set; }
        public virtual List<Customer> Customer { get; set; }
        public virtual List<Article> Article { get; set; }

        public Bill(decimal prize)
        {
            Prize = prize;
        }

        public Bill() : this(0.0m)
        {

        }

        public override string ToString()
        {
            return this.ToString();
        }
    }
}
