using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PerfumeStore_BrandNCountry.Controllers
{
    public class RegisterController : Controller
    {
        private PerfumeStoreDbContext db = new PerfumeStoreDbContext();
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Register(string name, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                return Json(new
                {
                    status = false,
                    msg = "Please input all field"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!ValidateEmail(email))
            {
                return Json(new
                {
                    status = false,
                    msg = "Format email error"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!password.Equals(confirmPassword))
            {
                return Json(new
                {
                    status = false,
                    msg = "Password confirm error"
                }, JsonRequestBehavior.AllowGet);
            }
            user_role data = db.user_role.FirstOrDefault(x => x.role_name == "user");
            user model = new user();
            model.user_id = 0;
            model.user_email = email;
            model.user_fullName = name;
            model.user_password = MD5Hash(password);
            model.user_roleId = data.role_id;
            model.user_status = 1;
            model.user_username = email.Split('@')[0];
            model.user_createdAt = DateTime.Now;
            db.users.Add(model);
            db.SaveChanges();
            return Json(new
            {
                status = true,
                msg = "Đăng ký thành công"
            }, JsonRequestBehavior.AllowGet);

        }
        private bool ValidateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}