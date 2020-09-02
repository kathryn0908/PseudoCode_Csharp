
namespace YardView.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        
    }
}