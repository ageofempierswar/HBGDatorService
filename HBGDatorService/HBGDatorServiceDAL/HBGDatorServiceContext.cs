using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBGDatorServiceDAL.POCO;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HBGDatorServiceDAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HBGDatorServiceContext : DbContext
    {
        public HBGDatorServiceContext() : base("HBGDatorServiceContext")
        {
            Database.SetInitializer<HBGDatorServiceContext>(new HBGDatorServiceContextInitializer());
        }

        public DbSet<SlideShowImage> SlideShowImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}