using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApp1.Models
{
	public class Student
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}