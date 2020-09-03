namespace YardView.Data
{
    public class YardViewContext : DbContext
    {
        public YardViewContext (DbContextOptions<YardViewContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckedOutBook> CheckedOutBooks { get; set; }
    }
}