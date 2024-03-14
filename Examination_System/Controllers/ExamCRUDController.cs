using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class ExamCRUDController : Controller
    {
        ITIContext DB;
        public ExamCRUDController(ITIContext Db)
        {
            DB = Db;
        }


        public IActionResult GetExams()
        {
            var model = DB.Exam.ToList();
            return View(model);
        }
        public IActionResult EditExams(int Exam_ID)
        {
            ViewBag.coursesList = DB.Course.ToList();
            if (Exam_ID == null)
            {
                return BadRequest();
            }

            var model = DB.Exam.FirstOrDefault(s => s.Exam_ID == Exam_ID);

            return View(model);
        }

        [HttpPost]

        public IActionResult EditExams(Exam exam)
        {
            DB.Exam.Update(exam);
            DB.SaveChanges();
            return RedirectToAction("GetExams");
        }
        public IActionResult DeleteExams(int id)
        {
            var exam = DB.Exam.SingleOrDefault(a => a.Exam_ID == id);
            if (exam == null)
            {
                return NotFound(); // Or handle the case where the exam doesn't exist
            }

            var questions = DB.Question.Where(sa => sa.Exam_ID == exam.Exam_ID).ToList();
            foreach (var question in questions)
            {
                var studentAnswers = DB.StudentAnswer.Where(s => s.Ques_ID == question.Ques_ID).ToList();
                foreach (var answer in studentAnswers)
                {
                    DB.StudentAnswer.Remove(answer);
                }
                DB.Question.Remove(question);
            }

            // Then delete the exam
            DB.Exam.Remove(exam);
            DB.SaveChanges();
            return RedirectToAction("GetExams");
        }
        public IActionResult CreateExams()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExams(Exam exam)
        {

            DB.Exam.Add(exam);
            DB.SaveChanges();
            return RedirectToAction("GetExams");

        }

    }
}
