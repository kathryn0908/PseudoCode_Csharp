
namespace YardView.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<CheckedOutBooks> CheckedOutBook { get; set; }
        
    }
}