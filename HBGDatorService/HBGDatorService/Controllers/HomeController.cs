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
            list.Add("~/Content/Images/7cf0d7b2ceaf3358305aafa10b0f376c.jpg");
            list.Add("~/Content/Images/all-mass-effect-characters.jpg");
            list.Add("~/Content/Images/mass-effect-2-16685-1366x768.jpg");
                                
            list.Add("~/Content/Images/mass-effect-3-17004-1366x768.jpg");
            list.Add("~/Content/Images/mass_effect_shepard_female_graphics_gun_1366x768_hd-wallpaper-15574.jpg");
            foreach (var SlideImage in images)
            {
                list.Add(SlideImage.ImagePath);
            }
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}