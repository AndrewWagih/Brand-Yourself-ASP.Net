using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class ExperienceController : Controller
    {
        // Fetch Data
        public JsonResult FetchAllExperience(Experience ex)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Experiences.Select(x => new
            {
                id = x.id,
                position=x.position ,
                company=x.company ,
                date_from=x.date_from ,
                date_to = x.date_to ,
                description=x.description ,
                userId = x.user_id
            }).Where(x => x.userId == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewExperience(Experience exp)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Experiences.Add(exp);
                obj.SaveChanges();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateExperience(Experience exp)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Experience updatExp = (
                    from c in obj.Experiences where c.id == exp.id select c
                ).FirstOrDefault();
                updatExp.position = exp.position;
                updatExp.company = exp.company;
                updatExp.date_from = exp.date_from;
                updatExp.date_to = exp.date_to;
                updatExp.description = exp.description;
                obj.SaveChanges();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteExperience(Experience exp)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Experience deleteexp = (
                    from c in obj.Experiences where c.id == exp.id select c
                ).FirstOrDefault();
                obj.Experiences.Remove(deleteexp);
                obj.SaveChanges();
            }
            return Json(exp, JsonRequestBehavior.AllowGet);
        }
    }
}