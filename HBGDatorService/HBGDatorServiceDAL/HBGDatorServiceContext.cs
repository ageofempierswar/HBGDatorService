using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBGDatorServiceDAL.POCO;
namespace HBGDatorServiceDAL
{
    public class HBGDatorServiceContext : DbContext
    {
        public HBGDatorServiceContext()
        {
            Database.SetInitializer(new HBGDatorServiceContextInitializer(this));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SlideShowImage> SlideShowImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}