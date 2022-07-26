namespace User.Models
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options):base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<SuperHero> SuperHeroes { get; set; } = null!;
	}
}

