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
            //return View(Repository.GetAllAdmins());
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginModel model)
        {

            if (ModelState.IsValid)
            {
                bool isValid = Repository.AuthenticateAdminLogin(model.Username, model.Password);
                if (isValid)
                {

                    FormsAuthentication.SetAuthCookie(Repository.GetAdminId(model.Username).ToString(), false);
                    /* Denna kanske behövs. */

                    return RedirectToAction("Index", "Home"); 
                       
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

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterAdminModel model) // behöves inte eftersom admin sätts i databasen, tog med den ändå.
        {
            if (ModelState.IsValid)
            {
                Repository.RegisterAdmin(model);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Edit(int id) // editera din adminprofil, kan man väll ha nytta av, fast admin är ju en "valig användare" så dem kan ha samma edit.
        {
            var admin = Repository.GetAdminInformationForEditModel(id);
            return View(admin);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAdminModel model)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateAdminProfile(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}