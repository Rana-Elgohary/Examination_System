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
        public async Task<IActionResult> InsertStudent(Student stu, IFormFile? imageFile)
        {
            string fileImage = imageFile.FileName;
            string fileExt = fileImage.Split('.').Last();

            if (ModelState.IsValid)
            {
                DB.Student.Add(stu);
                DB.SaveChanges();
                var st = DB.Student.FirstOrDefault(a => a.Email == stu.Email && a.Password == stu.Password);
                st.Image_ID = $"{stu.Id}.{fileExt}";
                using (var fs = new FileStream($"wwwroot/images/Students/{st.Id}.{fileExt}", FileMode.Create))
                {
                    await imageFile.CopyToAsync(fs);
                }
                DB.Student.Update(st);
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
        public async Task<IActionResult> EditStudent(Student stu, string OldStuImg, IFormFile? imageFile)
        {
            if(imageFile != null)
            {
                if (System.IO.File.Exists($"wwwroot/images/Students/{OldStuImg}"))
                {
                    System.IO.File.Delete($"wwwroot/images/Students/{OldStuImg}");
                }
                string fileImage = imageFile.FileName;
                string fileExten = fileImage.Split('.').Last();
                using (var fs = new FileStream($"wwwroot/images/Students/{stu.Id}.{fileExten}", FileMode.Create))
                {
                    await imageFile.CopyToAsync(fs);
                }
                stu.Image_ID = $"{stu.Id}.{fileExten}";
            }
            else
            {
                stu.Image_ID = OldStuImg;
            }

            DB.Student.Update(stu);
            DB.SaveChanges();
            return RedirectToAction("ShowStudents");
        }

        public IActionResult DeleteStudent(int id)
        {
            var model = DB.Student.SingleOrDefault(a => a.Id == id);
            if (System.IO.File.Exists($"wwwroot/images/Students/{model.Image_ID}"))
            {
                System.IO.File.Delete($"wwwroot/images/Students/{model.Image_ID}");
            }
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
