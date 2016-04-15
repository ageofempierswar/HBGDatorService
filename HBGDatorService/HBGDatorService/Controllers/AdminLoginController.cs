using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
//using HBGDatorService.Helpers;
using HBGDatorService.Models;
namespace HBGDatorService.Controllers
{
    public class AdminLoginController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login() //används inte.
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginModel model) // ska ta en till adminvyn.
        {

            if (ModelState.IsValid)
            {
                bool isValid = Repository.AuthenticateAdminLogin(model.Username, model.Password);
                if (isValid)
                {

                    FormsAuthentication.SetAuthCookie(Repository.GetAdminId(model.Username).ToString(), false);
                    /* Denna kanske behövs. */

                    return RedirectToAction("Index", "Home"); 
                    //just nu (om det funkat) logga in som admin, på localhost????/Admin, som sedan skickar tillbaka dig
                    //till home med adminbehörighet
                       
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}