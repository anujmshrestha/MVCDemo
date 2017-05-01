using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        MVCDBEntities _db = new MVCDBEntities();

        public ActionResult Index()
        {
          //  List<tblUser> lstuser = _db.tblUsers.ToList();
          var users =_db.tblUsers.ToList();
           return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(tblUser user)
        {
            _db.tblUsers.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(tblUser ud)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == ud.UserId).FirstOrDefault();
             user.Username = ud.Username;
            user.Password = ud.Password;
            user.Usertype = ud.Usertype;
            user.Fullname = ud.Fullname;
            _db.SaveChanges();
            return RedirectToAction("Index");
            return View(user);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost,ActionName("Delete")]

        public ActionResult Delete_Post(int id)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            _db.tblUsers.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}