using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class TrackCRUDController : Controller
    {
        ITIContext db;

        public TrackCRUDController(ITIContext _db)
        {
            db = _db;
        }
        public IActionResult TrackIndex()  //fn to display ist of Track
        {
            var model = db.Track.Include(a => a.Instructor).ToList(); ; // list of courses
            return View(model);
        }

        public IActionResult CreateTrack()
        {
            // Get the list of instructor IDs who are already supervisors in existing tracks
            var existingSupervisorIds = db.Track.Select(t => t.Supervisor).Distinct().ToList();

            // Filter the list of instructors to exclude those who are already supervisors
            var availableInstructors = db.Instructor.Where(i => !existingSupervisorIds.Contains(i.Ins_Id)).ToList();

            ViewBag.Instructorlist = availableInstructors;
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrack(Track trk)
        {
            db.Track.Add(trk);
            db.SaveChanges();
            return RedirectToAction("TrackIndex");
        }

        public IActionResult EditTrack(int TrackId)
        {
            // Get the list of instructor IDs who are already supervisors
            var existingSupervisorIds = db.Track.Select(t => t.Supervisor).Distinct().ToList();

            // Filter the list of instructors to exclude those who are already supervisors
            var availableInstructors = db.Instructor.Where(i => !existingSupervisorIds.Contains(i.Ins_Id)).ToList();
            ViewBag.Instructorlist = availableInstructors;

            if (TrackId == null)
            {
                return BadRequest();
            }

            var model = db.Track.SingleOrDefault(a => a.TrackId == TrackId);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditTrack(Track trk)
        {
            db.Track.Update(trk);
            db.SaveChanges();
            return RedirectToAction("TrackIndex");
        }

        public IActionResult DeleteTrack(int TrackId)
        {
            var model = db.Track.SingleOrDefault(a => a.TrackId == TrackId);
            var Track_ins = db.Track_Instructor.Where(sa => sa.TrackId == TrackId).ToList();
            foreach (var answer in Track_ins)
            {
                db.Track_Instructor.Remove(answer);
            }
            var Stu = db.Student.Where(sa => sa.TrackId == TrackId).ToList();
            foreach (var answer in Stu)
            {
                answer.TrackId = null;
                db.SaveChanges();
            }
            db.Track.Remove(model);
            db.SaveChanges();
            return RedirectToAction("TrackIndex");

        }

    }
}
