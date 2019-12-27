using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class EducationController : Controller
    {
        // Fetch Data
        public JsonResult FetchAllEducation(Education edu)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Educations.Select(x => new
            {
                id = x.id,
                school_name = x.school_name,
                description = x.description,
                date_from = x.date_from,
                date_to = x.date_to,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewEducation(Education edu)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Educations.Add(edu);
                obj.SaveChanges();
            }
            return Json(edu, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEducation(Education edu)
        {

            using (BYEntities1 obj = new BYEntities1())
            {
                Education updatEdu = (
                    from c in obj.Educations where c.id == edu.id select c
                ).FirstOrDefault();
                updatEdu.school_name = edu.school_name;
                updatEdu.description = edu.description;
                updatEdu.date_from = edu.date_from;
                updatEdu.date_to = edu.date_to;
                obj.SaveChanges();
            }
            return Json(edu, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEducation(Education edu)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Education deleteEdu = (
                    from c in obj.Educations where c.id == edu.id select c
                ).FirstOrDefault();
                obj.Educations.Remove(deleteEdu);
                obj.SaveChanges();
            }
            return Json(edu, JsonRequestBehavior.AllowGet);
        }

    }
}