using Examination_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class StudentController : Controller
    {

        ITIContext DB;
        public StudentController(ITIContext db)
        {
            DB = db;
        }

        public IActionResult GenerateQuestions(int stdID, int CrsId)
        {
            var questions = DB.Question
               .Include(q => q.Exam) 
               .Where(q => q.Exam.Course_ID == CrsId)
               .ToList();

            Random rand = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                var value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;
            }

            ViewBag.StdId = stdID;
            ViewBag.CrsId = CrsId;
            var Em = DB.Exam.SingleOrDefault(e => e.Course_ID == CrsId);
            ViewBag.duration = Em.Duration;
            var StdName = DB.Student.SingleOrDefault(s => s.Id == stdID);
            ViewBag.StudentName = StdName.Name;
            var course = DB.Course.SingleOrDefault(c => c.Course_ID == CrsId);
            ViewBag.CrsName = course.Name;
            return View(questions);
        }
    }
}
