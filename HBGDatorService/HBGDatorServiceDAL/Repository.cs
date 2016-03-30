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
                        where i.Active == true && i.ImagePath.StartsWith(@"~/Content/Images")
                        select (new ImageModel
                        {
                            ID = i.ID,
                            Active = i.Active,
                            ImagePath = i.ImagePath,
                            FileName = i.FileName
                        })).ToList();
            }
        }
    }
}
