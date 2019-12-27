using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BY_1._2.Controllers
{
    public class CoursesController : Controller
    {
        public JsonResult FetchAllCourses(Course course)
        {
            HttpCookie c = Request.Cookies["user"];
            int id = Convert.ToInt32(c["id"]);
            BYEntities1 obj = new BYEntities1();
            var info = obj.Courses.Select(x => new
            {
                id = x.id,
                name = x.name,
                date_to = x.date_to,
                date_from = x.date_from,
                user_id = x.user_id
            }).Where(x => x.user_id == id).ToList();
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addNewCourses(Course course)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                obj.Courses.Add(course);
                obj.SaveChanges();
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCourses(Course course)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Course updateCourse = (
                    from c in obj.Courses where c.id == course.id select c
                ).FirstOrDefault();
                updateCourse.name = course.name;
                updateCourse.date_from = course.date_from;
                updateCourse.date_to = course.date_to;
                obj.SaveChanges();
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCourses(Course course)
        {
            using (BYEntities1 obj = new BYEntities1())
            {
                Course deleteCourse = (
                    from c in obj.Courses where c.id == course.id select c
                ).FirstOrDefault();
                obj.Courses.Remove(deleteCourse);
                obj.SaveChanges();
            }
            return Json(course, JsonRequestBehavior.AllowGet);
        }

    }
}