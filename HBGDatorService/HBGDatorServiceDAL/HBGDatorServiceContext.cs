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
            //    System.Data.Entity.Database.SetInitializer<HBGDatorServiceContext>(new System.Data.Entity.DropCreateDatabaseIfModelChanges<HBGDatorServiceContext>());

            Database.SetInitializer<HBGDatorServiceContext>(new HBGDatorServiceContextInitializer());

            //    /*
            //    Ovan uppdaterar databasen endast om modellen förändrats, men jag tror inte den kickar igång seed, nästa förändring får ni kolla
            //    */

            //    // Denna kör seed också, men ändrar inte databasen.

            //Database.SetInitializer<myDB>(new DropCreateDatabaseIfModelChanges<myDB>());
            //Database.SetInitializer(new HBGDatorServiceContextInitializer(this)); 

            //Om vi får about fel, ta bort kommentaren på koden framför, kör projektet en gång, stäng och kommentera ut det igen.
            //                                                                          /*
            //                                                                          Vet ej om SetInitializer behövs efter nästa förändring av modellen, eller om Seed kickas igång av den ovan.

            //                                                                           */
        }

        public DbSet<AdminAccount> Users { get; set; }
        public DbSet<SlideShowImage> SlideShowImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}