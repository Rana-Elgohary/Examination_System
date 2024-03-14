using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class StudentCRUDController : Controller
    {
        ITIContext DB;
        public StudentCRUDController(ITIContext Db)
        {
            DB = Db;
        }

        public IActionResult ShowStudents()
        {
            var model = DB.Student.Include(t => t.Track).ToList();
            return View(model);
        }

        public IActionResult InsertStudent()
        {
            ViewBag.TrackList = DB.Track.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult InsertStudent(Student stu)
        {
            if (ModelState.IsValid)
            {
                DB.Student.Add(stu);
                DB.SaveChanges();
                return RedirectToAction("ShowStudents");
            }
            else
            {
                ViewBag.TrackList = DB.Track.ToList();
                return View(stu);
            }
        }

        public IActionResult EditStudent(int id)
        {
            ViewBag.TrackList = DB.Track.ToList();
            var model = DB.Student.Include(a => a.Track).SingleOrDefault(a => a.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditStudent(Student stu)
        {
            DB.Student.Update(stu);
            DB.SaveChanges();
            return RedirectToAction("ShowStudents");
        }

        public IActionResult DeleteStudent(int id)
        {
            var model = DB.Student.SingleOrDefault(a => a.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            var Stu_Ans = DB.StudentAnswer.Where(sa => sa.Stud_Id == id).ToList();
            foreach (var answer in Stu_Ans)
            {
                
                DB.StudentAnswer.Remove(answer);
            }
            var Crs_Stu = DB.StudentCourse.Where(sa => sa.StudentId == id).ToList();
            foreach (var STCRS in Crs_Stu)
            {

                DB.StudentCourse.Remove(STCRS);
            }
            DB.Student.Remove(model);
            DB.SaveChanges();
            return RedirectToAction("ShowStudents");
        }
    }
}
