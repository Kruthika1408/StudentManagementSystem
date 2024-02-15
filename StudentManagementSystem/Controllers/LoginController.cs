using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class LoginController : Controller
    {

        Student_DBEntities db = new Student_DBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objcheck)
        {
            if(ModelState.IsValid)
            {
                using (Student_DBEntities db = new Student_DBEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objcheck.username) && a.password.Equals(objcheck.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The userName or Password Incorrect");
                    }
                    
                }
            }
            return View(objcheck);

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
           

    }
}