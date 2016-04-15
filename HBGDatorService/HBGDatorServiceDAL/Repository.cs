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
        public static int GetAdminId(string username)
         {
             using (var context = new HBGDatorServiceContext())
             {
                 return
                     (from u in context.Users
                      where u.Username == username
                      select u.ID).FirstOrDefault();
             }
 
         }
        public static string GetAdminEmail()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return
                    (from u in context.Users
                     where u.AdminLevel == 1
                     select u.Email).FirstOrDefault();
            }
        }
        public static bool AuthenticateAdminLogin(string username, string password)
         {
             using (var context = new HBGDatorServiceContext())
             {
                 return
                     (from a in context.Users
                      where a.Username == username && a.Password == password && a.IsActive
                      select a).Any();
             }
         }
 
         public static EditAdminModel GetAdminInformationForEditModel(int id)
         {
             using (var context = new HBGDatorServiceContext())
             {
                 return (from u in context.Users
                         where u.ID == id
                         select new EditAdminModel
                         {
                             Email = u.Email
                         }).FirstOrDefault();
             }
         }
        public static AboutReadOnlyModel AboutReadOnly()
        {
            using (var contex = new HBGDatorServiceContext())
            {

                return (from a in contex.Abouts
                        select new AboutReadOnlyModel()
                        {
                            Header1 = a.Header1,
                            Header2 = a.Header2,
                            Header3 = a.Header3,
                            Textfield1 = a.Textfield1,
                            Textfield2 = a.Textfield2,
                            Textfield3 = a.Textfield3
                        }).ToList().LastOrDefault();

            }
        }

        public static void UpdateAdminProfile(int adminId, EditAdminModel model)
        {
            using (var context = new HBGDatorServiceContext())
            {

                var admin = context.Users.Find(adminId);
                admin.Email = model.Email;
                admin.Password = model.Password;


                context.Entry(admin).State = EntityState.Modified;
                context.SaveChanges();
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
        public static EditAboutModel GetLatestAboutInformation()
        {
            using (var context = new HBGDatorServiceContext())
            {
                var query =
                    (from a in context.Abouts
                     orderby a.ID descending
                     select
                         new EditAboutModel()
                         {
                             ID = a.ID,
                             Header1 = a.Header1,
                             Header2 = a.Header2,
                             Header3 = a.Header3,
                             Textfield1 = a.Textfield1,
                             Textfield2 = a.Textfield2,
                             Textfield3 = a.Textfield3
                         }).FirstOrDefault();

                return query;
            }
        }

        public static About GetLatestAbout()
        {
            using (var context = new HBGDatorServiceContext())
            {
                var query =
                    (from a in context.Abouts
                     orderby a.ID descending
                     select a).FirstOrDefault();

                return query;
            }
        }
        public static void RemoveAdminByID(int id)
        {
            using (var context = new HBGDatorServiceContext())
            {
                var user = context.Users.Find(id);
                user.IsActive = false;
                context.SaveChanges();
            }
        }
        public static void RegisterAdmin(RegisterAdminModel model)
        {
            using (var context = new HBGDatorServiceContext())
            {
                var newAdmin = new AdminAccount()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    AdminLevel = model.AdminLevel,
                    IsActive = true,
                };

                context.Users.Add(newAdmin);
                context.SaveChanges();
            }
        }
        public static List<AdminModel> GetAllAdmins()
        {
            using (var context = new HBGDatorServiceContext())
            {
                return (from a in context.Users
                        where a.IsActive == true
                        select new AdminModel { Username = a.Username, AdminLevel = a.AdminLevel, ID = a.ID }).ToList();
            }
        }

        public static About SetAboutValues(EditAboutModel model, About about)
        {
            about.ID = model.ID;
            about.Header1 = model.Header1;
            about.Header2 = model.Header2;
            about.Header3 = model.Header3;
            about.Textfield1 = model.Textfield1;
            about.Textfield2 = model.Textfield2;
            about.Textfield3 = model.Textfield3;
            return about;
        }
    }

}
