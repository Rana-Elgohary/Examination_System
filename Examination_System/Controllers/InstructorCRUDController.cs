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
        public IActionResult InsertInstructor(Instructor ins)
        {
            if (ModelState.IsValid)
            {
                DB.Instructor.Add(ins);
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
        public IActionResult EditInstructor(Instructor ins)
        {
            DB.Instructor.Update(ins);
            DB.SaveChanges();
            return RedirectToAction("ShowInstructors");
        }

        public IActionResult DeleteInstructor(int id)
        {
            var model = DB.Instructor.SingleOrDefault(a => a.Ins_Id == id);
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
