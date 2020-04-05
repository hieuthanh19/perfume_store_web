using PerfumeStore_BrandNCountry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PerfumeStore_BrandNCountry.Common;
using Model.EF;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class SignInController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        // GET: Admin/LogIn
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.username, model.password);
                if (result)
                {
                    var user = dao.GetByUsername(model.username);
                    var user_Role = db.user_role.FirstOrDefault(x => x.role_id == user.user_roleId);
                    if (user_Role.role_name == "user")
                    {
                        var userSession = new UserLogin();
                        userSession.userId = user.user_id;
                        userSession.username = user.user_username;
                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return Json(new
                        {
                            status = true,
                        }, JsonRequestBehavior.AllowGet); ;
                    }
                    else
                    {
                        return Json(new
                        {
                            status = false,
                            msg = "Username or password incorect"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        msg = "Username or password incorect"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                status = false,
                msg = "Please input all field"
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}