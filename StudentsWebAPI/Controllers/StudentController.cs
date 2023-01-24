using Microsoft.AspNetCore.Mvc;
using StudentsWebAPI.Datas;
using StudentsWebAPI.Model;

namespace StudentsWebAPI.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class StudentController : Controller
	{

		private readonly DatabaseContext _context;

		public StudentController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetList()
		{
			List<Student> student = _context.Students.ToList();

			return Ok(student);
		}

		[HttpGet("{id}")]
		public IActionResult GetListById(int id)
		{
			Student student = _context.Students.FirstOrDefault(x => x.Id == id);

			if(student == null)
			{
				return NotFound();
			}
			

			return Ok(student);
		}

		[HttpPost]
		public IActionResult CreateStudent(CreateStudentModel model)
		{
			if (model.FullName == "string")
			{
				return BadRequest(model);
			}

			Student student = new Student();

			student.FullName = model.FullName;
			student.Computer = model.Computer;
			student.College = model.College;
			student.Age = model.Age;
			student.IsSuccess = model.IsSuccess;

			_context.Students.Add(student);
			_context.SaveChanges();
			

			return Created("", model);
		}
	}
}
