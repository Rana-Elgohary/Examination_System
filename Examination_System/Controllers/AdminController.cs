using Examination_System.Models;
using Examination_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class AdminController : Controller
    {
        ITIContext db;

        public AdminController(ITIContext _db)
        {
            db = _db;
        }
        //1st report
        public IActionResult theStudentsInformationAccordingToTrackId(int TrackID)
        {
            var model = db.Student.Where(s => s.Track.TrackId == TrackID);
            return View(model);
        }

        //2ns report
        public IActionResult takesStdIDAndReturnsGradesInAllCourses(int StdID)
        {
            var studentGrades = from SC in db.StudentCourse
                                join C in db.Course on SC.CrsId equals C.Course_ID
                                where SC.StudentId == StdID
                                select new DisplayStudentGrades
                                {
                                    CourseName = C.Name,
                                    stdId = SC.StudentId,
                                    Grade = SC.Grade

                                };
            // Pass the data to the view
            return View(studentGrades.ToList());
        }
        //3rd report
        public IActionResult NameOfCourses_ForInstructor_NumOfStudent(int InsID)
        {
            var model = db.Instructor
                .Include(c => c.InstructorCourse)
                .ThenInclude(c => c.Course)
                .ThenInclude(c => c.studentCourses)
                .SingleOrDefault(x => x.Ins_Id == InsID );
            return View(model);
        }
        //4th report
        public IActionResult TopicsData_By_CourseID(int CoursesID)
        {
            var model = db.Course.Include(a => a.Topics).SingleOrDefault(x => x.Course_ID == CoursesID);
            return View(model);
        }

        public IActionResult GetQuestions_Choices(int ExId)
        {
            var model = db.Exam.Include(q => q.Questions).SingleOrDefault(x => x.Exam_ID == ExId);
            return View(model);
        }

        public IActionResult GetQuestions_Stu_Answers(int ExId, int StuId)
        {
            var model = db.Exam.Include(q => q.Questions).ThenInclude(s => s.StudentAnswers).SingleOrDefault(x => x.Exam_ID == ExId);
            ViewBag.StuId = StuId;
            return View(model);
        }
    }
}
