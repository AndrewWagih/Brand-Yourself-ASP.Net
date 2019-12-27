using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        public JsonResult FetchAllSkills(Skill skill)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Skills.Select(x => new
            {
                id = x.id,
                skill_nam = x.skill_nam,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }


        public JsonResult addNewSkills(string skill_nam, string user_id)
        {
            int UI = Convert.ToInt32(user_id);
            Skill n = new Skill();
            n.skill_nam = skill_nam;
            n.user_id = UI;
            using (BYEntities1 obj = new BYEntities1())
            {
                
                obj.Skills.Add(n);
                obj.SaveChanges();
            }
           
            return Json(n, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateSkills(string skill,string id, string user_id)
        {
            int ID = Convert.ToInt32(id);
            int UI = Convert.ToInt32(user_id);
            Skill n = new Skill();
            n.id = ID;
            n.skill_nam = skill;
            n.user_id = UI;
            using (BYEntities1 obj = new BYEntities1())
            {
                Skill updateSkill = (
                    from c in obj.Skills where c.id == n.id select c
                ).FirstOrDefault();
                updateSkill.skill_nam = n.skill_nam;
                obj.SaveChanges();
            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSkills(string skill, string id, string user_id)
        {
            int ID = Convert.ToInt32(id);
            int UI = Convert.ToInt32(user_id);
            Skill n = new Skill();
            n.id = ID;
            n.skill_nam = skill;
            n.user_id = UI;
            using (BYEntities1 obj = new BYEntities1())
            {
                Skill deletelSkill = (
                    from c in obj.Skills where c.id == n.id select c
                ).FirstOrDefault();
                obj.Skills.Remove(deletelSkill);
                obj.SaveChanges();
            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }
    }
}