using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models
{
    //  Beispiel 2
    //      1:n-Verknüpfung
    //      ein Article kann mehrere Evaluations haben
    //      eine Evalutaion gehört ganau zu eunem Artikel
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string description { get; set; }
        //usw.

        //  Navigaztions-Property
        //      aufgrund der List<Evaluation> erkennt ef, dass es sich eine 1:n-Verknüpfung
        //      zwischen Article (1-Seite) und Evaluation (n-Seite) handelt

        public virtual List<Evaluation> Evaluations { get; set; }

        public Article(string name, decimal price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.description = description;
        }

        public Article() : this("", 0.0m, "")
        {

        }

        public override string ToString()
        {
            return "articleId: "+this.ArticleId+"\tname: " + this.Name + "\tprice: " + this.Price;
        }

        
    }
}
