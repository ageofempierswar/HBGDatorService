using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using HBGDatorServiceDAL.Models;
using HBGDatorServiceDAL.POCO;

namespace HBGDatorServiceDAL
{
    public static class Repository
    {

        //------------------------------------------------------------------------------------------------------- SlideShow

        public static List<ImageModel> GetAllSlideShowImages()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return (from i in context.SlideShowImages
                        where i.Active == true && i.ImagePath.StartsWith(@"~/SlideImages/")
                        select (new ImageModel
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName
                        })).ToList();
            }
        }
        public static void AddNewSlideShowFile(string fileName, string path)
        {
            using (var context = new HBGDatorServiceContext())
            {
                context.SlideShowImages.Add(new SlideShowImage()
                {
                    FileName = fileName,
                    ImagePath = path,
                    Active = true
                }
                    );
                context.SaveChanges();
            }
        }
        public static void DeleteSlideShowImage(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                var image = context.SlideShowImages.Find(id);
                context.SlideShowImages.Remove(image);
                context.SaveChanges();
            }
        }

        //------------------------------------------------------------------------------------------------------- Users/Admins

        public static List<UserAccount> GetAllUsers(int nrToGet)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.UserAccount.OrderByDescending(d => d.FirstName).Take(nrToGet).ToList();
            }
        }

        //------------------------------------------------------------------------------------------------------- Service

        public static List<Service> GetAllServices(int nrToGet = 4)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Services.OrderByDescending(d => d.ID).Take(nrToGet).ToList();
            }
        }
        public static Service GetServiceById(int idToGet)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Services.Where(n => n.ID == idToGet).FirstOrDefault();
            }
        }
        public static void UpdateOrSaveService(Service serviceToEdit)
        {
            using (var context = new HBGDatorServiceContext())
            {
                Service serviceExisting = context.Services.Where(n => n.ID == serviceToEdit.ID).FirstOrDefault();
                if (serviceExisting == null)
                {
                    context.Services.Add(serviceToEdit);
                    context.SaveChanges();
                }
                else
                {

                    serviceExisting.Header = serviceToEdit.Header;
                    serviceExisting.Textfield = serviceToEdit.Textfield;
                    context.Entry(serviceExisting).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public static void DeleteService(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                Service toRemove = context.Services.Where(n => n.ID == id).FirstOrDefault();
                if (toRemove != null)
                {
                    context.Services.Remove(toRemove);
                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public static IEnumerable<Service> GetServiceList()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Services.OrderByDescending(d => d.ID).ToList();
            }
        }

        //------------------------------------------------------------------------------------------------------- About

        public static List<About> GetAllAbouts(int nrToGet = 4)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Abouts.OrderByDescending(d => d.ID).Take(nrToGet).ToList();
            }
        }
        public static About GetAboutsById(int idToGet)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Abouts.Where(n => n.ID == idToGet).FirstOrDefault();
            }
        }
        public static void UpdateOrSaveAbouts(About aboutsToEdit)
        {
            using (var context = new HBGDatorServiceContext())
            {
                About aboutsExisting = context.Abouts.Where(n => n.ID == aboutsToEdit.ID).FirstOrDefault();
                if (aboutsExisting == null)
                {
                    context.Abouts.Add(aboutsToEdit);
                    context.SaveChanges();
                }
                else
                {

                    aboutsExisting.Header = aboutsToEdit.Header;
                    aboutsExisting.Textfield = aboutsToEdit.Textfield;
                    context.Entry(aboutsExisting).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public static void DeleteAbouts(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                About toRemove = context.Abouts.Where(n => n.ID == id).FirstOrDefault();
                if (toRemove != null)
                {
                    context.Abouts.Remove(toRemove);
                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public static IEnumerable<About> GetAboutList()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.Abouts.OrderByDescending(d => d.ID).ToList();
            }
        }

        //------------------------------------------------------------------------------------------------------- Price

            //Finns inte ännu.

        //------------------------------------------------------------------------------------------------------- News

        public static List<News> GetLatestNews(int nrToGet = 4)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.News.OrderByDescending(d => d.newsDate).Take(nrToGet).ToList();
            }
        }
        public static News GetNewsById(int idToGet)
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.News.Where(n => n.newsID == idToGet).FirstOrDefault();
            }
        }
        public static void UpdateOrSaveNews(News newsToEdit)
        {
            using (var context = new HBGDatorServiceContext())
            {
                News newsExisting = context.News.Where(n => n.newsID == newsToEdit.newsID).FirstOrDefault();
                if (newsExisting == null)
                {
                    context.News.Add(newsToEdit);
                    context.SaveChanges();
                }
                else
                {
                    newsExisting.newsBody = newsToEdit.newsBody;
                    newsExisting.newsDate = newsToEdit.newsDate;
                    newsExisting.newsTopic = newsExisting.newsTopic;
                    context.Entry(newsExisting).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public static void DeleteNews(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                News toRemove = context.News.Where(n => n.newsID == id).FirstOrDefault();
                if (toRemove != null)
                {
                    context.News.Remove(toRemove);
                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public static IEnumerable<News> GetNewsList()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return context.News.OrderByDescending(d => d.newsDate).ToList();
            }
        }
    }
}
