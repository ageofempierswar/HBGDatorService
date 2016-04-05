using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;

namespace HBGDatorService.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {
            var model = Repository.AboutReadOnly();
            return View(model);
        } 
    }
}