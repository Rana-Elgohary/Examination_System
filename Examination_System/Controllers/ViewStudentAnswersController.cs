using Examination_System.Models;
using Examination_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class ViewStudentAnswersController : Controller
    {
        ITIContext DB;
        public ViewStudentAnswersController(ITIContext Db)
        {
            DB = Db;
        }
        public IActionResult Index(int ExamId, int STD_ID)
        {
            int stdId = STD_ID;
            int Examid = ExamId;
            var StudentAnswers = from Question in DB.Question
                                 join StudentAnswer in DB.StudentAnswer on Question.Ques_ID equals StudentAnswer.Ques_ID
                                 where Question.Exam_ID == Examid && StudentAnswer.Stud_Id == stdId
                                 select new DisplayStudentAnswers
                                 {
                                     Ques_ID = Question.Ques_ID,
                                     Quest = Question.Quest,
                                     Corr_Answer = Question.Corr_Answer,
                                     OPt1_Answer = Question.OPt1_Answer,
                                     OPt2_Answer = Question.OPt2_Answer,
                                     OPt3_Answer = Question.OPt3_Answer,
                                     Student_Answer = StudentAnswer.Student_Answer,
                                     If_Correct = StudentAnswer.If_Correct

                                 };
            return View(StudentAnswers.ToList());
        }
    }
}
