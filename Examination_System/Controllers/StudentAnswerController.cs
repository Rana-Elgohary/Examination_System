using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class StudentAnswerController : Controller
    {
        ITIContext DB;
        public StudentAnswerController(ITIContext db)
        {
            DB = db;
        }
        public IActionResult AnswerHandling(int CRS_ID, int STD_ID, List<int> questionId, Dictionary<int, string> Answer, int ExamId)
        {
            var Studentanswer = new StudentAnswer();
            int count_deg = 0;
            for (var i = 0; i < questionId.Count; i++)
            {
                var quest = DB.Question.Where(a => a.Ques_ID == questionId[i]).ToList();
                var questionIdForCurrentQuest = questionId[i];
                Studentanswer.Stud_Id = STD_ID;
                Studentanswer.Ques_ID = questionId[i];
                var stu_ans = Answer[questionIdForCurrentQuest];
                var q = quest[0].Corr_Answer;
                var ques_deg = quest[0].Quest_Deg;

                Studentanswer.Student_Answer = Answer[questionIdForCurrentQuest];
                if (quest[0].Corr_Answer == Answer[questionIdForCurrentQuest])
                {
                    Studentanswer.If_Correct = true;
                    count_deg += ques_deg;
                }
                else
                {
                    Studentanswer.If_Correct = false;
                }

                DB.StudentAnswer.Add(Studentanswer);
                DB.SaveChanges();
            }
            //ViewBag.student_degree = count_deg;

            var model = Answer;
            var StuCourse = DB.StudentCourse.FirstOrDefault(x => x.StudentId == STD_ID && x.CrsId == CRS_ID );
            //var StuCourse = new StudentCourse();
            //StuCourse.StudentId = STD_ID;
            //StuCourse.CrsId = CRS_ID;
            StuCourse.Grade = count_deg;
            //DB.StudentCourse.Add(StuCourse);
            DB.SaveChanges();
            ViewBag.StdId = STD_ID;
            ///////////////////
            ViewBag.ExamId = ExamId;
            
            return RedirectToAction("Index", "ViewStudentAnswers", new { STD_ID = STD_ID, ExamId = ExamId, CRS_ID = CRS_ID });
        }
    }
}
