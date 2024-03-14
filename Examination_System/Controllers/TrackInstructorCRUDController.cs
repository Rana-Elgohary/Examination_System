using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class TrackInstructorCRUDController : Controller
    {
        ITIContext DB;
        public TrackInstructorCRUDController(ITIContext Db)
        {
            DB = Db;
        }
        public IActionResult ShowTrackInstructor()
        {
            var model = DB.Track_Instructor.Include(a => a.instructor).Include(a => a.Track).ToList();
            return View(model);
        }
        public IActionResult InsertTrackInstructor()
        {
            ViewBag.Track = DB.Track.ToList();
            var model = DB.Instructor.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult InsertTrackInstructor(int Trackid, int Insid)
        {
            var TrackIns = new Track_Instructor
            {
                TrackId = Trackid,
                Ins_Id = Insid
            };
            DB.Track_Instructor.Add(TrackIns);
            DB.SaveChanges();
            return RedirectToAction("ShowTrackInstructor");
        }
        public IActionResult DeleteTrackInstructor(string idstring)
        {
            String[] ids = idstring.Split(',');
            var model = DB.Track_Instructor.SingleOrDefault(a => a.TrackId == int.Parse(ids[0]) && a.Ins_Id == int.Parse(ids[1]));
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                DB.Track_Instructor.Remove(model);
                DB.SaveChanges();
                return RedirectToAction("ShowTrackInstructor");
            }

        }
    }
}
