using Examination_System.Models;
using Examination_System.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Examination_System.Controllers
{
    public class LoginController : Controller
    {
        ITIContext db;
        public LoginController(ITIContext _db) 
        {
            db = _db;
        }
        public IActionResult Login() // show form to submit std data
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)  // submitted data from the form 
        { //1-checkInDb
          //2- save in cookies for upcoming login(through SignInAsync func)

            //1)

            if (db.Student.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password) != null) 
            { 
                var result = db.Student.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                //user is found
                // (could signin)
                Claim c1 = new Claim(ClaimTypes.NameIdentifier, result.Id.ToString());
                //Claim c2 = new Claim("Pass", result.Password);
                ClaimsIdentity ci = new ClaimsIdentity("Cookies");
                ci.AddClaim(c1);
                //ci.AddClaim(c2);

                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);
                await HttpContext.SignInAsync(cp);
                return RedirectToAction("ShowCourses", "HomePage", new { id = result.Id });
            }
            else if (db.Instructor.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password) != null)
            {
                var result = db.Instructor.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                //user is found
                // (could signin)
                Claim c1 = new Claim(ClaimTypes.NameIdentifier, result.Ins_Id.ToString());
                //Claim c2 = new Claim("Pass", result.Password);
                ClaimsIdentity ci = new ClaimsIdentity("Cookies");
                ci.AddClaim(c1);
                //ci.AddClaim(c2);

                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);
                await HttpContext.SignInAsync(cp);
                return RedirectToAction("Instructor", "HomePage", new { id = result.Ins_Id }); 
            }
            else  // user not found
            {
                ModelState.AddModelError("", "Email and Password are Invalid");
                return View(model); // return to login view again with his incorrect data+error msg
            }
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }
    }
}
