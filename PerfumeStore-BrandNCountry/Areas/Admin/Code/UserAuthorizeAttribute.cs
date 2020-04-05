using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfumeStore_BrandNCountry.Areas.Admin.Code
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = (Common.AdminLogin)HttpContext.Current.Session[Common.CommonConstant.ADMIN_SESSION];
            if (session != null)
            {
                //Admin Default full permission
                if (session.role_name.ToLower().ToString() == "admin")
                {
                    return;
                }
                else
                {
                    var flag = true;
                    var controller = Convert.ToString(filterContext.RouteData.Values["controller"]);
                    var action = Convert.ToString(filterContext.RouteData.Values["action"]);
                    if (session.role_name.ToLower().ToString() == "store_staff")
                    {
                        if (controller.ToLower() == "dashboard" || controller.ToLower() == "orders" || controller.ToLower() == "orderitems")
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else if (session.role_name.ToLower().ToString() == "department_staff")
                    {
                        if (controller.ToLower() == "dashboard" || controller.ToLower() == "orders" || controller.ToLower() == "orderitems")
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else if (session.role_name.ToLower().ToString() == "inventory_staff")
                    {
                        if (controller.ToLower() == "user" || controller.ToLower() == "user_role")
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (!flag)
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                                RouteValueDictionary(new { area = "Admin", controller = "Dashboard", action = "Denied" }));
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { area = "Admin", controller = "Login", action = "Index" }));
            }

            }
        }
    }