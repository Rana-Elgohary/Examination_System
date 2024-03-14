using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class StudentCourseCRUDController : Controller
    {
        ITIContext DB;
        public StudentCourseCRUDController(ITIContext Db)
        {
            DB = Db;
        }
        public IActionResult ShowStudentCourse()
        {
            var model = DB.StudentCourse.Include(a => a.student).Include(a => a.course).ToList();
            return View(model);
        }
        public IActionResult InsertStudentCourse()
        {
            ViewBag.Courseid = DB.Course.ToList();
            var model = DB.Student.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult InsertStudentCourse(int Course_ID, int Id)
        {
            var StuCrs = new StudentCourse
            {
                StudentId = Id,
                CrsId = Course_ID
            };
            DB.StudentCourse.Add(StuCrs);
            DB.SaveChanges();
            return RedirectToAction("ShowStudentCourse");
        }
        public IActionResult DeleteStudentCourse(string idstring)
        {
            String[] ids = idstring.Split(',');
            var model = DB.StudentCourse.SingleOrDefault(a => a.StudentId == int.Parse(ids[0]) && a.CrsId == int.Parse(ids[1]));
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                DB.StudentCourse.Remove(model);
                DB.SaveChanges();
                return RedirectToAction("ShowStudentCourse");
            }

        }
    }
}
