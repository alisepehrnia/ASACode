using System.Data.Entity;
using MVCApp1.Models;

namespace MVCApp1
{
	public class App1DbContext : DbContext
	{
		public App1DbContext() : base("name=Model1")
		{
		}

		public DbSet<Student> Students { get; set; }
	}
}