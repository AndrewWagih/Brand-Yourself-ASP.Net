using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class LanguageController : Controller
    {
        public JsonResult FetchAllLanguage(Language lang)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Languages.Select(x => new
            {
                id = x.id,
                language = x.language_name,
                mastery=x.mastery,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewLanguage(Language lang)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Languages.Add(lang);
                obj.SaveChanges();
            }
            return Json(lang, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateLang(Language lang)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Language updateLang = (
                    from c in obj.Languages where c.id == lang.id select c
                ).FirstOrDefault();
                updateLang.language_name = lang.language_name;
                updateLang.mastery = lang.mastery;
                obj.SaveChanges();
            }
            return Json(lang, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteLanguage(Language lang)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Language deleteLang = (
                    from c in obj.Languages where c.id == lang.id select c
                ).FirstOrDefault();
                obj.Languages.Remove(deleteLang);
                obj.SaveChanges();
            }
            return Json(lang, JsonRequestBehavior.AllowGet);
        }
    }
}
