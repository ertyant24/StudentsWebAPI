using Microsoft.EntityFrameworkCore;

namespace StudentsWebAPI.Datas
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

	}
}
