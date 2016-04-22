using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
namespace HBGDatorService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var images = Repository.GetAllSlideShowImages();
            List<string> list = new List<string>();
            list.Add("~/SlideImages/7cf0d7b2ceaf3358305aafa10b0f376c.jpg");
            list.Add("~/SlideImages/all-mass-effect-characters.jpg");
            list.Add("~/SlideImages/mass-effect-2-16685-1366x768.jpg");                       
            list.Add("~/SlideImages/mass-effect-3-17004-1366x768.jpg");
            list.Add("~/SlideImages/mass_effect_shepard_female_graphics_gun_1366x768_hd-wallpaper-15574.jpg");
            foreach (var SlideImage in images)
            {
                list.Add(SlideImage.ImagePath);
            }

            return View(list);
        }

        public ActionResult About()
        {
            var model = Repository.AboutReadOnly();
            return View(model);
        }

        public ActionResult Service()
        {
            var model = Repository.ServiceReadOnly(10);
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
