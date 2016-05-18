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
        //public HBGDatorServiceContext()
        //{
        //    System.Data.Entity.Database.SetInitializer<HBGDatorServiceContext>(new System.Data.Entity.DropCreateDatabaseIfModelChanges<HBGDatorServiceContext>());
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
        //}

        // context är en samling av DbSet som blir våra tabeller, som skappas av Initializern när projektet körs igång.

        public DbSet<AdminAccount> Users { get; set; }
        public DbSet<SlideShowImage> SlideShowImages { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}