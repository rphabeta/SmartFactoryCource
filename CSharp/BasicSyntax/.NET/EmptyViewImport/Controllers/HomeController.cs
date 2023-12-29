using EmptyViewImport01.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyViewImport01.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var students = new List<Student>
			{
				new Student{ID = 1, Name="홍길동", Hp="010-1111-1111"},
				new Student{ID = 2, Name="이순신", Hp="010-2222-2222"},
				new Student{ID = 3, Name="강감찬", Hp="010-3333-3333"}
			};
			return View(students);
		}

		public IActionResult About()
		{
			var students = new List<Student>
			{
				new Student{ID = 1, Name="홍길동", Hp="010-1111-1111"},
				new Student{ID = 2, Name="이순신", Hp="010-2222-2222"},
				new Student{ID = 3, Name="강감찬", Hp="010-3333-3333"}
			};
			return View(students);
		}
	}
}
