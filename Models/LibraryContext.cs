class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CheckedOutBook> CheckedOutBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<CheckedOutBook>()
            .HasKey(t => new { t.UserId, t.BookId })

        modelBuilder.Entity<User>()
            .HasOne(u => u.User)
            .WithMany(c => c.CheckedOutBooks)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Book)
            .WithMany(c => c.CheckedOutBooks)
            .HasForeignKey(p => p.BookId);
    }
}

public class User
{
    public int Id { get; set; }
    public string Username{ get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string Password { get; set; }
    public virtual ICollection<CheckedOutBook> CheckedOutBooks { get; set; }
    
}
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public virtual ICollection<CheckedOutBook> CheckedOutBooks { get; set; }
    
}
public class CheckedOutBook
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public  Book Book { get; set; }

    public  User User { get; set; }

    [Display(Name = "Checkout Date")]
    [DataType(DataType.Date)]
    public DateTime CheckoutDate { get; set; } 

}