using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.POCO;
using HBGDatorService.Models;

namespace HBGDatorService.Controllers
{
    public class HomeController : Controller
    {

        private HBGDatorServiceContext db = new HBGDatorServiceContext();

        public ActionResult Index()
        {
            IndexPageModel ip = new IndexPageModel();
            var images = Repository.GetAllSlideShowImages();
            List<string> list = new List<string>();
            list.Add("~/SlideImages/20160523_151339.jpg");
            list.Add("~/SlideImages/20160523_151430.jpg");

            foreach (var SlideImage in images)
            {
                list.Add(SlideImage.ImagePath);
            }
            ip.sliderImages = list;

            ip.indexNews = Repository.GetLatestNews();
            ip.indexAbout = Repository.GetAllAbouts();
            ip.indexService = Repository.GetAllServices();

            return View(ip);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditNews(int id = 0)
        {
            News newsToEdit = new News();
            newsToEdit.newsDate = DateTime.Now;
        
            if (id != 0)
            {
                newsToEdit = Repository.GetNewsById(id);
            }
            return View(newsToEdit);
            
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditNews(News updatedNews)
        {
            Repository.UpdateOrSaveNews(updatedNews);
            return RedirectToAction("ListNews");

        }
        [Authorize]
        public ActionResult DeleteNews(int id)
        {
            Repository.DeleteNews(id);
            return RedirectToAction("ListNews");
        }

        [Authorize]
        public ActionResult ListNews()
        {
            IEnumerable<News> newsList = Repository.GetNewsList();
            return View(newsList);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditAbout(int id = 0)
        {
            About aboutToEdit = new About();

            if (id != 0)
            {
                aboutToEdit = Repository.GetAboutsById(id);
            }
            return View(aboutToEdit);

        }
        [Authorize]
        [HttpPost]
        public ActionResult EditAbout(About updatedAbout)
        {
            Repository.UpdateOrSaveAbouts(updatedAbout);
            return RedirectToAction("ListAbout");

        }
        [Authorize]
        public ActionResult DeleteAbout(int id)
        {
            Repository.DeleteAbouts(id);
            return RedirectToAction("ListAbout");
        }

        public ActionResult ListAbout()
        {
            IEnumerable<About> aboutList = Repository.GetAboutList();
            return View(aboutList);
        }


        [Authorize]
        [HttpGet]
        public ActionResult EditService(int id = 0)
        {
            Service serviceToEdit = new Service();

            if (id != 0)
            {
                serviceToEdit = Repository.GetServiceById(id);
            }
            return View(serviceToEdit);

        }
        [Authorize]
        [HttpPost]
        public ActionResult EditService(Service updatedService)
        {
            Repository.UpdateOrSaveService(updatedService);
            return RedirectToAction("ListService");

        }
        [Authorize]
        public ActionResult DeleteService(int id)
        {
            Repository.DeleteService(id);
            return RedirectToAction("ListService");
        }

        public ActionResult ListService()
        {
            IEnumerable<Service> serviceList = Repository.GetServiceList();
            return View(serviceList);
        }


    }
}
