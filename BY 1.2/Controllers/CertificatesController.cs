using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class CertificatesController : Controller
    {
        public JsonResult FetchAllCertificates(Certificate crt)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);

            BYEntities1 obj = new BYEntities1();
            var info = obj.Certificates.Select(x => new
            {
                id = x.id,
                title = x.title,
                date_to = x.date_to,
                date_from = x.date_from,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewCertificates(Certificate crt)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Certificates.Add(crt);
                obj.SaveChanges();
            }
            return Json(crt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCertificates(Certificate crt)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Certificate updateCrt = (
                    from c in obj.Certificates where c.id == crt.id select c
                ).FirstOrDefault();
                updateCrt.title = crt.title;
                updateCrt.date_from = crt.date_from;
                updateCrt.date_to = crt.date_to;
                obj.SaveChanges();
            }
            return Json(crt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCertificates(Certificate crt)
        {

            using (BYEntities1 obj = new BYEntities1())
            {
                Certificate deleteCir = (
                    from c in obj.Certificates where c.id == crt.id select c
                ).FirstOrDefault();
                obj.Certificates.Remove(deleteCir);
                obj.SaveChanges();
            }
            return Json(crt, JsonRequestBehavior.AllowGet);
        }

    }
}