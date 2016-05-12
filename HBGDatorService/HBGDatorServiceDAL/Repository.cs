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

        public static void UpdateUserProfile(UserAccount user)
        {
            using (var context = new HBGDatorServiceContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void RemoveUserByID(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                var user = context.Users.Find(id);
                user.IsActive = false;
                context.SaveChanges();
            }
        }

        public static List<UserAccount> GetAllUsers()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return (from i in context.UserAccount
                        where i.FirstName != null
                        select (new UserAccount
                        {
                            FirstName = i.FirstName,
                            LastName = i.LastName,
                            Email = i.Email
                        })).ToList();
            }
        }

        //------------------------------------------------------------------------------------------------------- Service

        public static ServiceReadOnlyModel ServiceReadOnly(int nrToShow)
        {
            using (var contex = new HBGDatorServiceContext())
            {
                ServiceReadOnlyModel s = new ServiceReadOnlyModel();
                s.services = contex.Services.Take(nrToShow).ToList();
                return s;
            }
        }

        public static void UpdateService(Service service)
        {
            using (var context = new HBGDatorServiceContext())
            {
                context.Entry(service).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static Service GetLatestService()
        {
            using (var context = new HBGDatorServiceContext())
            {
                EditServiceModel e = new EditServiceModel();
                Service a = context.Services.OrderByDescending(x => x.ID).FirstOrDefault();

                e.Header = a.Header;
                e.ID = a.ID;
                e.Textfield = a.Textfield;

                return a;
            }
        }

        public static Service SetServiceValues(EditServiceModel model, Service service)
        {
            service.ID = model.ID;
            service.Header = model.Header;
            service.Textfield = model.Textfield;
            return service;
        }

        //------------------------------------------------------------------------------------------------------- About

        public static AboutReadOnlyModel AboutReadOnly()
        {
            using (var contex = new HBGDatorServiceContext())
            {

                AboutReadOnlyModel a = new AboutReadOnlyModel();
                a.About = contex.Abouts.Take(3).ToList();

                return a;

            }
        }

        public static void UpdateAbouts(About about)
        {
            using (var context = new HBGDatorServiceContext())
            {
                context.Entry(about).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static About GetLatestAbouts()
        {
            using (var context = new HBGDatorServiceContext())
            {
                EditAboutModel e = new EditAboutModel();
                About a = context.Abouts.OrderByDescending(x => x.ID).FirstOrDefault();

                e.Header = a.Header;
                e.ID = a.ID;
                e.Textfield = a.Textfield;


                return a;
            }
        }

        public static About SetAboutValues(EditAboutModel model, About about)
        {
            about.ID = model.ID;
            about.Header = model.Header;
            about.Textfield = model.Textfield;
            return about;
        }
    }
}
