
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BY_1._2.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Loginn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Loginn(string em,string pass)
        {
            BYEntities1 obj = new BYEntities1();
            Userr myUser = obj.Userrs.SingleOrDefault(user => user.email == em &&
           user.password == pass);
            
            //BYEntities1 obj = new BYEntities1();
            //var info = obj.users.Select(x => new
            //{
            //    id = x.id,
            //    email = x.email,
            //    password = x.password,
            //}).Where(x => x.email == em && x.password == pass).ToList();
            if (myUser != null)
            {
                HttpCookie c = new HttpCookie("user");
                c["email"] = myUser.email;
                c["password"] = myUser.password;
                c["id"] = myUser.id.ToString(); ;
                
                Response.Cookies.Add(c);
                //return Json(myUser, JsonRequestBehavior.AllowGet);
               return Redirect("/Control/Courses");
            }
            else
            {
                return View();
            }
            //return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp([Bind(Include = "first_name,last_name,email,phone_number,password,birthday,gender")] Userr user)
        {

            BYEntities1 obj = new BYEntities1();
                    obj.Userrs.Add(user);
                    obj.SaveChanges();
                    HttpCookie c = new HttpCookie("user");
                      c["first_name"]=user.first_name;
                        c["last_name"]= user.last_name;
                        c["email"]= user.email;
                        c["phone_number"]= user.phone_number;
                        c["password"]= user.password;
                        c["birthday"]= user.birthday;
                        c["gender"]= user.gender;
                    Response.Cookies.Add(c);
                    return   Redirect("/Control/Personalnfo");


        }

        
        public ActionResult LogOut()
        {
            
                var c = new HttpCookie("user");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
                return Redirect("/Login/Loginn");
      
        }
        
}
}