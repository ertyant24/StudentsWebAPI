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

			if (student == null)
			{
				return NotFound();
			}


			return Ok(student);
		}

		[HttpGet("{order}/{count}")]
		public IActionResult GetListByCount(string order, int count)
		{
			List<Student> student = null;

			if (order == "asc")
			{
				student = _context.Students.OrderBy(x => x.Age).Take(count).ToList();
			}

			if (order == "desc")
			{
				student = _context.Students.OrderByDescending(x => x.Age).Take(count).ToList();
			}

			if (order == "asc")
			{
				student = _context.Students.OrderBy(x => x.Id).ToList();
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

		[HttpPut("update/{id}")]
		public IActionResult UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentModel model)
		{
			Student student = _context.Students.FirstOrDefault(x => x.Id == id);

			if (student == null)
			{
				return NotFound();
			}

			student.Computer = model.Computer;
			student.College = model.College;
			student.Age = model.Age;
			student.IsSuccess = model.IsSuccess;
			student.FullName = model.FullName;

			_context.SaveChanges();

			return Ok(student);
		}

		[HttpDelete("delete/{id}")]
		public IActionResult DeleteStudent([FromRoute] int id)
		{
			Student student = _context.Students.Find(id);

			if(student != null)
			{
				_context.Students.Remove(student);
				_context.SaveChanges();
			}
			else
			{
				return NotFound();
			}

			return Ok(student);
		}
	}
}
