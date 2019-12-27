using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            
                return View();
            

        }
        public JsonResult GetAllEmployee()  
        {
            BYEntities1 obj = new BYEntities1();
            var info = obj.Userrs.Select(x => new  
             {
                Id = x.id,
                First_name = x.first_name,
                Last_name =x.last_name,
                Email = x.email,
                Phone_number =x.phone_number,
                Password =x.password,
                Birthday =x.birthday,
                Gender =x.gender,
            }).ToList();  
            return Json(info, JsonRequestBehavior.AllowGet);  
        }  
    }
}