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

            foreach (var SlideImage in images)
            {
                list.Add(SlideImage.ImagePath);
            }
            ip.sliderImages = list;

            ip.indexNews = Repository.GetLatestNews();

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
            return RedirectToAction("ListNews");
        }

        [Authorize]
        public ActionResult ListNews()
        {
            IEnumerable<News> newsList = Repository.GetNewsList();
            return View(newsList);
        }

        public ActionResult About()
        {
            var model = Repository.AboutReadOnly();
            return View(model);

            //return View(db.Abouts.ToList());
        }

        public ActionResult Service()
        {
            var model = Repository.ServiceReadOnly(10);
            return View(model);

            //return View(db.Service.ToList());
        }
    }
}
