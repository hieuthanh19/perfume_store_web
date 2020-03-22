using PerfumeStore_BrandNCountry.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PerfumeStore_BrandNCountry.Common;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Controllers
{
    public class LogInController : Controller
    {
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
                    var userSession = new UserLogin();
                    userSession.userId = user.user_id;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
            }
            return View("Index");
           
        }
    }
}