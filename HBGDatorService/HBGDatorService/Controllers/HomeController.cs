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
            var model = Repository.AboutReadOnly(); // när jag trycker på about, så krashar sidan, och jag/vi vet inte varför, den säger att model.header är fel.
            return View(model); // kopplar mot rätt view, men header(och förmodligen dem andra också) är tomma/null
            // christoffer säger att home controller har en about, denna här controllern har ingen view, och sakerna som ska vara i header ligger i DAL
            // så vad är rätt/fel?

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}