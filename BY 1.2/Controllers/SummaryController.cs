using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class SummaryController : Controller
    {
        public JsonResult FetchAllSummary(Summary summaryy)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Summaries.Select(x => new
            {
                id = x.id,
                description = x.description,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewSummery(Summary summaryy)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Summaries.Add(summaryy);
                obj.SaveChanges();
            }
            return Json(summaryy, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateSummary(Summary summaryy)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Summary updatesummary = (
                    from c in obj.Summaries where c.id == summaryy.id select c
                ).FirstOrDefault();
                updatesummary.description = summaryy.description;
                obj.SaveChanges();
            }
            return Json(summaryy, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSummary(Summary summaryy)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Summary deleteSummary = (
                    from c in obj.Summaries where c.id == summaryy.id select c
                ).FirstOrDefault();
                obj.Summaries.Remove(deleteSummary);
                obj.SaveChanges();
            }
            return Json(summaryy, JsonRequestBehavior.AllowGet);
        }

    }
}