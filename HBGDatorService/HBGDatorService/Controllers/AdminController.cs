using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
using HBGDatorService.Models;
namespace HBGDatorService.Controllers
{
    public class AdminController : Controller // här har admin användare sina "powers".
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit() // editera din adminprofil, kan man väll ha nytta av, fast admin är ju en "valig användare" så dem kan ha samma edit.
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int ID)
        {
            return View();
        }
    }
}