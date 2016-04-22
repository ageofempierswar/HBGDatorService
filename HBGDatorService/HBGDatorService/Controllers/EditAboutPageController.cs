using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
using HBGDatorServiceDAL.POCO;

namespace HBGDatorService.Controllers
{
    [Authorize]
    public class EditAboutPageController : Controller
    {
        // GET: EditAboutPage
        public ActionResult EditAbout()
        {
            var currentAboutInfo = Repository.GetLatestAbouts();
            return View(currentAboutInfo);
        }
        [HttpPost]
        public ActionResult EditAbout(EditAboutModel model)
        {
            if (ModelState.IsValid)
            {
                var about = Repository.GetLatestAbouts();
                Repository.UpdateAbouts(Repository.SetAboutValues(model, about));
                return RedirectToAction("Index", "About");
            }
            return View(model);
        }
    }
}