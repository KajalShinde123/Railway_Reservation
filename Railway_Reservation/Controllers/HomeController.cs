using Railway_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Railway_Reservation.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext(); 
   
        public ActionResult Index()
        {
           

            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            return View();
        }
        public ActionResult afterlogin()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {




               // var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("afterlogin");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string email, string password,string role)
        {
            if (ModelState.IsValid)
            {




                // var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)&& s.Role.Equals(role)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Updatetrain");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("AdminLogin");
                }
            }

            return View();
        }



        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult reserve()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reserv(Reservation r)
        {
            db.Reservations.Add(r);
            db.SaveChanges();
            return View();
        }

        public ActionResult Updatetrain()
        {
            return View();
        }
    }
}
