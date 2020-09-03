namespace YardView.Data
{
    public class YardViewContext : DbContext
    {
        public YardViewContext (DbContextOptions<YardViewContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CheckedOutBooks> CheckedOutBook { get; set; }
    }
}