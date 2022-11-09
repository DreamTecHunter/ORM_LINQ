using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_LINQ.Models
{
    //  gehört zum Beispiel Article
    public class Evaluation
    {
        [Key]
        [Column("evaluation_id")]
        public int MyEvaluationId { get; set; }
        [Column("evaluation_text")]
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        [Column("stars")]
        [Required]
        public int Stars { get; set; }
        //NAvigations-Property
        public virtual Article Article { get; set; }
        public Evaluation(string text, int stars, Article article)
        {
            Text = text;
            Stars = stars;
            Article = article;
        }

        public Evaluation() : this("", 0,new Article())
        {

        }

           
           
           
        public override string ToString()
        {
            return base.ToString();
        }
    }
}