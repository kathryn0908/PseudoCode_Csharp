

namespace YardView.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username{ get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }
        public virtual ICollection<CheckedOutBooks> CheckedOutBook { get; set; }
        
    }
}



       