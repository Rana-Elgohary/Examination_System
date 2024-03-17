using Examination_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Controllers
{
    public class TopicCRUDController : Controller
    {
        ITIContext DB;
        public TopicCRUDController(ITIContext Db)
        {
            DB = Db;
        }

        public IActionResult ShowAllTopics(int CrsId)
        {
            var model = DB.Topic.Where(t => t.Course_ID == CrsId);
            ViewBag.Crsid = CrsId;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTopic(int CrsId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTopic(Topic Model, int CrsId)
        {
            Model.Course_ID = CrsId;
            DB.Topic.Add(Model);
            DB.SaveChanges();
            return RedirectToAction("ShowAllTopics", "TopicCRUD", new { CrsId = Model.Course_ID });

        }

        public IActionResult EditTopic(int id)
        {

            var model = DB.Topic.SingleOrDefault(t => t.Topic_ID == id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }

        }

        [HttpPost]
        public IActionResult EditTopic(Topic model)
        {

            DB.Topic.Update(model);
            DB.SaveChanges();
            return RedirectToAction("ShowAllTopics", "TopicCRUD", new { CrsId = model.Course_ID });
        }

        public IActionResult DeleteTopic(int id)
        {

            var model = DB.Topic.SingleOrDefault(t => t.Topic_ID == id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {

                DB.Topic.Remove(model);
                DB.SaveChanges();
                return RedirectToAction("ShowAllTopics", "TopicCRUD", new { CrsId = model.Course_ID });
            }


        }
    }
}

