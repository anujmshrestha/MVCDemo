using MVCDemo.Models;
using MVCDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MVCDBEntities _db = new MVCDBEntities();
        public ActionResult Index()
        {
            List<UserViewModel> lstuserv = new List<UserViewModel>();
            var users = _db.tblUsers.ToList();
            foreach (var item in users)
            {
                lstuserv.Add(new UserViewModel()
                {
                    UserId = item.UserId,
                    Username = item.Username,
                    Password = item.Password,
                    Fullname = item.Fullname,
                    Usertype = item.Usertype
                });
            }

            return View(lstuserv);
        }

        public ActionResult Create()
        {
            return View();
        }
        public JsonResult CheckPassword(string password)
        {
            if(_db.tblUsers.Any(x=>x.Password==password))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel ud)
        {
            if (ModelState.IsValid)
            {
                tblUser uv = new tblUser();
                uv.Username = ud.Username;
                uv.Password = ud.Password;
                uv.Usertype = ud.Usertype;
                uv.Fullname = ud.Fullname;
                _db.tblUsers.Add(uv);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            }
            return View();
        }
        public ActionResult Edit(int id)
        {

            tblUser ud = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            UserViewModel uv = new UserViewModel();
                    uv.UserId = ud.UserId;
                    uv.Username = ud.Username;
                    uv.Password = ud.Password;
                    uv.Usertype = ud.Usertype;
                    uv.Fullname = ud.Fullname;

            return View(uv);

        }
        [HttpPost]
        public ActionResult Edit(UserViewModel uv)
        {
           
                tblUser ud = _db.tblUsers.Where(u => u.UserId == uv.UserId).FirstOrDefault();

                ud.UserId = uv.UserId;
                ud.Username = uv.Username;
                ud.Password = uv.Password;
                ud.Usertype = uv.Usertype;
                ud.Fullname = uv.Fullname;
                _db.SaveChanges();
                return RedirectToAction("Index");
               //return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tblUser ud = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();

            UserViewModel uv = new UserViewModel();
            uv.UserId = ud.UserId;
            uv.Username = ud.Username;
            uv.Password = ud.Password;
            uv.Usertype = ud.Usertype;
            uv.Fullname = ud.Fullname;

            return View(uv); 
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblUser ud= _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            UserViewModel uv = new UserViewModel();
            uv.Username = ud.Username;
            uv.Password = ud.Password;
            uv.Usertype = ud.Usertype;
            uv.Fullname = ud.Fullname;

            return View(uv);
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult Delete_Post(int id)
        {
            tblUser user = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            _db.tblUsers.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}