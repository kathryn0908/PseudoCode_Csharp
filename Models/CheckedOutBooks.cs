//Would be the Join Table, not as familiar with how this is set up via C#

namespace YardView.Models 
{
    public class CheckedOutBooks
    {
        public int BookId { get; set; }
         public int UserId { get; set; }
        public  Book Book { get; set; }

        public  User User { get; set; }

        [Display(Name = "Checkout Date")]
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; } 

    }
}