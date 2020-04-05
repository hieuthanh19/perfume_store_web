using PerfumeStore_BrandNCountry.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PerfumeStore_BrandNCountry.Common;
using Model.EF;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class LogInController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        // GET: Admin/LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.username, model.password);
                if (result)
                {
                    var user = dao.GetByUsername(model.username);
                    var role_name = db.user_role.Where(x => x.role_id == user.user_roleId).FirstOrDefault();
                    if(role_name != null && role_name.role_name != "user")
                    {
                        var userSession = new AdminLogin();
                        userSession.userId = user.user_id;
                        userSession.username = user.user_username;
                        userSession.role_name = role_name != null ? role_name.role_name : "";
                        Session.Add(CommonConstant.ADMIN_SESSION, userSession);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ViewBag.errorMsg = "Username or password is incorrect";
                    }
                }
                else
                {
                    ViewBag.errorMsg = "Username or password is incorrect";
                }
            }
            return View("Index");
           
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.ADMIN_SESSION] = null;
            return Redirect("/Admin");
        }
    }
}