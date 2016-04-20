﻿using System;
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
        //GET: EditServicePage
        public ActionResult EditService()
        {
            var currentServiceInfo = Repository.GetLatestService();
            return View(currentServiceInfo);
        }
        [HttpPost]
        public ActionResult EditService(EditServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var service = Repository.GetLatestService();
                Repository.UpdateService(Repository.SetServiceValues(model, service));
                return RedirectToAction("Index", "Service");
            }
            return View(model);
        }
    }
}