using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BY_1._2.Controllers
{
    public class PersonalInfoController : Controller
    {
        // GET: PersonalInfo
        

        // Fetch Data
        public JsonResult FetchAllPersonalInfo()
        {
            
            //HttpCookie c = Request.Cookies["user"];
            //int id = Convert.ToInt32(c["id"]);
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);

            //int id = Convert.ToInt32(N);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Personal_info.Select(x => new
            {
                id = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                email = x.email,
                phone_number = x.phone_number,
                birthday = x.birthday,
                profession = x.profession,
                address = x.address,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);

            // personal_info fetchPersonal = (
            //        from c in obj.personal_info where c.user_id == id.user_id select c
            //    ).FirstOrDefault();
            //return Json(fetchPersonal, JsonRequestBehavior.AllowGet);
        }

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

        public JsonResult DeletePersonalInfo(Personal_info personal)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Personal_info deletePersonal = (
                    from c in obj.Personal_info where c.id == personal.id select c
                ).FirstOrDefault();
                obj.Personal_info.Remove(deletePersonal);
                obj.SaveChanges();
            }
            return Json(personal, JsonRequestBehavior.AllowGet);
        }
    }
}