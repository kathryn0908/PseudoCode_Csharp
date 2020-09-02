

namespace YardView.Models
{
    [AttributeUsage(AttributeTargets.Property,
    Inherited = false,
    AllowMultiple = true)]
    internal sealed class OptionalAttribute : Attribute { }
    public class User
    {
        public int Id { get; set; }
        public string Username{ get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }
     
        [Optional]
        public string Book { get; set; }

        [Display(Name = "Checkout Date")]
        [DataType(DataType.Date)]
        [Optional]
        public DateTime CheckoutDate { get; set; } 
        //DateTime optional
    }
}



       