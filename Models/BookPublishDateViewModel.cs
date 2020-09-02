namespace YardView.Models
{
    public class BookPublishDateViewModel
    {
        public List<Book> Books { get; set; }
        public SelectList PublishDate { get; set; }
        public string BookPublishDate { get; set; }
        public string SearchString { get; set; }
    }
}