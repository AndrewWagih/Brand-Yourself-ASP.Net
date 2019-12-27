using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class ControlController : Controller
    {
        // GET: Control
        // Personal Info View

        public ActionResult PersonalInfo()
        {
            
            return View();    
            
        }

        //Summary View
        public ActionResult Summary()
        {
            return View();
        }

        //Experience View
        public ActionResult Experience()
        {
            return View();
        }

        //Education View
        public ActionResult Education()
        {
            return View();
        }
        //Skills View
        public ActionResult Skills()
        {
            return View();
        }

        //Language View
        public ActionResult Language()
        {
            return View();
        }

        //Courses View
        public ActionResult Courses()
        {
            return View();
        }

        //Certificates View
        public ActionResult Certificates()
        {
            return View();
        }
        // fetch All Data 
        public JsonResult GetAllEmployee()
        {
            BYEntities1 obj = new BYEntities1();
            
            var info = obj.Userrs.Select(x => new
            {
                Id = x.id,
                First_name = x.first_name,
                Last_name = x.last_name,
                Email = x.email,
                Phone_number = x.phone_number,
                Password = x.password,
                Birthday = x.birthday,
                Gender = x.gender,
            }).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        // Add New Values 
        public JsonResult addNewPersonalInfo(Personal_info personal)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Personal_info.Add(personal);
                obj.SaveChanges();
            }
            return Json(personal, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdatePersonalInfo(Personal_info personal)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Personal_info updatePersonal = (
                    from c in obj.Personal_info where c.id == personal.id select c
                ).FirstOrDefault();
                updatePersonal.first_name = personal.first_name;
                updatePersonal.last_name = personal.last_name;
                updatePersonal.email = personal.email;
                updatePersonal.phone_number = personal.phone_number;
                updatePersonal.birthday = personal.birthday;
                updatePersonal.profession = personal.profession;
                updatePersonal.address = personal.address;
                obj.SaveChanges();
            }
            return Json(personal, JsonRequestBehavior.AllowGet);
        }

    }
}