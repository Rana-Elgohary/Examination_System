using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Controllers
{
    public class InstructorCRUDController : Controller
    {
        ITIContext DB;
        public InstructorCRUDController(ITIContext Db)
        {
            DB = Db;
        }

        public IActionResult ShowInstructors()
        {
            var model = DB.Instructor.ToList();
            return View(model);
        }

        public IActionResult InsertInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertInstructor(Instructor ins, IFormFile? imageFile)
        {
            string fileImage = imageFile.FileName;
            string fileExt = fileImage.Split('.').Last();
            if (ModelState.IsValid)
            {
                DB.Instructor.Add(ins);
                DB.SaveChanges();
                var instr = DB.Instructor.SingleOrDefault(a => a.Password == ins.Password && a.Email == ins.Email);
                instr.Img_Id = $"{instr.Ins_Id}.{fileExt}";
                using (var fs = new FileStream($"wwwroot/images/Instructors/{instr.Ins_Id}.{fileExt}", FileMode.Create))
                {
                    await imageFile.CopyToAsync(fs);
                }
                DB.Instructor.Update(instr);
                DB.SaveChanges();
                return RedirectToAction("ShowInstructors");
            }
            else
            {
                return View(ins);
            }
        }

        public IActionResult EditInstructor(int id)
        {
            var model = DB.Instructor.SingleOrDefault(i => i.Ins_Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstructor(Instructor ins, string OldInsImg, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                if (System.IO.File.Exists($"wwwroot/images/Instructors/{OldInsImg}"))
                {
                    System.IO.File.Delete($"wwwroot/images/Instructors/{OldInsImg}");
                }
                string fileImage = imageFile.FileName;
                string fileExten = fileImage.Split('.').Last();
                using (var fs = new FileStream($"wwwroot/images/Instructors/{ins.Ins_Id}.{fileExten}", FileMode.Create))
                {
                    await imageFile.CopyToAsync(fs);
                }
                ins.Img_Id = $"{ins.Ins_Id}.{fileExten}";
            }
            else
            {
                ins.Img_Id = OldInsImg;
            }

            DB.Instructor.Update(ins);
            DB.SaveChanges();
            return RedirectToAction("ShowInstructors");
        }

        public IActionResult DeleteInstructor(int id)
        {
            var model = DB.Instructor.SingleOrDefault(a => a.Ins_Id == id);
            if (System.IO.File.Exists($"wwwroot/images/Instructors/{model.Img_Id}"))
            {
                System.IO.File.Delete($"wwwroot/images/Instructors/{model.Img_Id}");
            }
            if (model == null)
            {
                return NotFound();
            }
            var INS_Crs = DB.InstructorCourse.Where(sa => sa.InstructorId == id).ToList();
            foreach (var InsCrs in INS_Crs)
            {

                DB.InstructorCourse.Remove(InsCrs);
            }
            var Track_Ins = DB.Track_Instructor.Where(sa => sa.Ins_Id == id).ToList();
            foreach (var TrcIns in Track_Ins)
            {

                DB.Track_Instructor.Remove(TrcIns);
            }
            var model2= DB.Track.Where(a=>a.Supervisor== id).ToList();
            foreach (var Trc in model2)
            {
                Trc.Supervisor =null;
                DB.SaveChanges();
            }
            DB.Instructor.Remove(model);
            DB.SaveChanges();
            return RedirectToAction("ShowInstructors");
        }
    }
}
