namespace ORM_LINQ.Models
{
    //  gehört zum Beispiel Article
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public string Text { get; set; }
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
            return this.ToString();
        }
    }
}