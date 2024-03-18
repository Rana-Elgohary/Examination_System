using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class CourseCRUDController : Controller
    {
        ITIContext db;

        public CourseCRUDController(ITIContext _db)
        {
            db = _db;
        }
        public IActionResult CourseIndex() 
        {
            var model = db.Course.ToList();
            return View(model);
        }

        public IActionResult CreateCourse()
        {
            ViewBag.Courselist = db.Course.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(Course crs)
        {
            db.Course.Add(crs);
            db.SaveChanges();
            return RedirectToAction("CourseIndex");
        }
        public IActionResult EditCourse(int Course_ID)
        {
            ViewBag.CourseList = db.Course.ToList();
            if (Course_ID == null)
            {
                return BadRequest();
            }
            var model = db.Course.SingleOrDefault(a => a.Course_ID == Course_ID);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]

        public IActionResult EditCourse(Course crs)
        {
            db.Course.Update(crs);
            db.SaveChanges();
            return RedirectToAction("CourseIndex");
        }
        public IActionResult DeleteCourse(int Course_ID)
        {
            var model = db.Course.SingleOrDefault(a => a.Course_ID == Course_ID);
            var Crs_INS = db.InstructorCourse.Where(sa => sa.CrsId == Course_ID).ToList();
            foreach (var InsCrs in Crs_INS)
            {

                db.InstructorCourse.Remove(InsCrs);
            }
            var Crs_STU = db.StudentCourse.Where(sa => sa.CrsId == Course_ID).ToList();
            foreach (var CrsSTU in Crs_STU)
            {

                db.StudentCourse.Remove(CrsSTU);
            }

            var model3 = db.Exam.Where(a => a.Course_ID == Course_ID).ToList();
            foreach(var Exam in model3)
            { 
                var questions = db.Question.Where(sa => sa.Exam_ID == Exam.Exam_ID).ToList();
                foreach (var question in questions)
                {
                    var studentAnswers = db.StudentAnswer.Where(s => s.Ques_ID == question.Ques_ID).ToList();
                    foreach (var answer in studentAnswers)
                    {
                        db.StudentAnswer.Remove(answer);
                    }
                    db.Question.Remove(question);
                }
                db.Exam.Remove(Exam);
            }
            var model2 = db.Topic.Where(a => a.Course_ID == Course_ID).ToList();
            foreach (var Trc in model2)
            {
                db.Topic.Remove(Trc);
            }

            db.Course.Remove(model);
            db.SaveChanges();
            return RedirectToAction("CourseIndex");

        }
    }
}
