using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class QuestionCRUDController : Controller
    {
        ITIContext DB;
        public QuestionCRUDController(ITIContext Db)
        {
            DB = Db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetQuestion(int Exam_ID)
        {
            var model = DB.Question.ToList();
            ViewBag.Examid = Exam_ID;
            return View(model);
        }
        public IActionResult EditQuestion(int id)
        {
            ViewBag.ExamsList = DB.Exam.ToList();
            if (id == null)
            {
                return BadRequest();
            }

            var model = DB.Question.FirstOrDefault(s => s.Ques_ID == id);
            return View(model);
        }

        [HttpPost]

        public IActionResult EditQuestion(Question model)
        {

            DB.Question.Update(model);
            DB.SaveChanges();
            return RedirectToAction("GetQuestion");
        }
        public IActionResult DeleteQuestion(int id)
        {
            var quest = DB.Question.SingleOrDefault(a => a.Ques_ID == id);
            if (quest == null)
            {
                return NotFound(); // Or handle the case where the exam doesn't exist
            }
            var studentAnswers = DB.StudentAnswer.Where(s => s.Ques_ID == quest.Ques_ID).ToList();
            foreach (var answer in studentAnswers)
            {
                DB.StudentAnswer.Remove(answer);
            }

            DB.Question.Remove(quest);
            DB.SaveChanges();
            return RedirectToAction("GetQuestion");
        }
        public IActionResult CreateQuestion(int Exam_id)
        {
            ViewBag.examID=Exam_id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestion(Question model)
        {

            DB.Question.Add(model);
            DB.SaveChanges();
            return RedirectToAction("GetQuestion");

        }

    }
}
