using System.ComponentModel.DataAnnotations;

namespace StudentsWebAPI.Datas
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[StringLength(30)]
		public string FullName { get; set; }

		[StringLength(50)]
		public string College { get; set; }

		[Range(20,40)]
		public int Age { get; set; }

		[StringLength(25)]
		public string Computer { get; set; }
		public bool IsSuccess { get; set; }

	}
}
