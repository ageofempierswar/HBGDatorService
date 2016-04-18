using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
namespace HBGDatorService.Controllers
{
    [Authorize]
    public class RegisterAdminController : Controller // denna controller används inte, men kan behövas senare.
    {
        // GET: RegisterAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}