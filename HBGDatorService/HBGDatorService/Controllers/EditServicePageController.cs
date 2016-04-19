using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
using HBGDatorServiceDAL.POCO;
namespace HBGDatorService.Controllers
{
    public class EditServicePageController : Controller
    {
        // GET: EditServicePage
        public ActionResult EditService()
        {
            var currentServiceInfo = Repository.GetLatestServiceInformation();
            return View(currentServiceInfo);
        }
        [HttpPost]
        public ActionResult EditAbout(EditServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var about = Repository.GetLatestService();
                Repository.UpdateAbouts(Repository.SetAboutValues(model, about));
                return RedirectToAction("Index", "About");
            }
            return View(model);
        }
    }
}