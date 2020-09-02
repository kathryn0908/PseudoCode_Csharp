namespace YardView.Data
{
    public class YardViewContext : DbContext
    {
        public YardViewContext (DbContextOptions<YardViewContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<User> User { get; set; }
    }
}