using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class InstructorCourseCRUDController : Controller
    {
        ITIContext DB;
        public InstructorCourseCRUDController(ITIContext Db)
        {
            DB = Db;
        }
        public IActionResult ShowInstructorCourse()
        {
            var model = DB.InstructorCourse.Include(a => a.instructor).Include(a => a.Course).ToList();
            return View(model);
        }
        public IActionResult AddInstructorCourse()
        {
            var model = DB.Instructor.ToList();
            ViewBag.Course = DB.Course.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddInstructorCourse(int InsId, int CRSID)
        {
            var InsCrs = new InstructorCourse
            {
                InstructorId = InsId,
                CrsId = CRSID
            };
            DB.InstructorCourse.Add(InsCrs);
            DB.SaveChanges();
            return RedirectToAction("ShowInstructorCourse");
        }
        public IActionResult DeleteInstructorCourse(string idstring)
        {
            string[] ids = idstring.Split(",");
            var model = DB.InstructorCourse.SingleOrDefault(a => a.InstructorId == int.Parse(ids[0]) && a.CrsId == int.Parse(ids[1]));
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                DB.InstructorCourse.Remove(model);
                DB.SaveChanges();
                return RedirectToAction("ShowInstructorCourse");
            }
        }
    }
}
