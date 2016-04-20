using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HBGDatorServiceDAL.POCO;
namespace HBGDatorServiceDAL
{
    public class HBGDatorServiceContextInitializer : DropCreateDatabaseIfModelChanges<HBGDatorServiceContext>
    //Databasen MÅSTE vara IfModelChanges, på grund av att alla users och allt man gjort kommer försvinna när man tex bytar sida, 
    //och det är ju inte jätte bra. (^_^)
    {

        private HBGDatorServiceContext context;
        private List<About> abouts;
        private List<Service> services;
        //private readonly List<User> users;

        protected override void Seed(HBGDatorServiceContext context)
        {
            abouts.ForEach(a => context.Abouts.Add(a));
            services.ForEach(s => context.Services.Add(s));
            context.SaveChanges();
        }

        public HBGDatorServiceContextInitializer()
        {
            //users = new List<User>()
            //{
            //    new User("admin", "admin",1, "teamnordahl123@gmail.com"),
            //    new User("Test1", "admin", 2, "teamnordahl123@gmail.com"),
            //    new User("Test2", "admin", 2, "teamnordahl123@gmail.com"),
            //};

            //this.context = h;
            //Seed(context);


            abouts = new List<About>()
            {
                new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vel fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tempor bibendum turpis eget sollicitudin. Praesent pharetra rhoncus metus, a cursus massa consectetur pharetra. Nulla pulvinar nisi quis sem molestie, in luctus mi scelerisque. Nulla facilisi. Duis sit amet volutpat diam. Proin vitae auctor lectus." },
                         new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tempor . Duis sit amet volutpat diam. Proin vitae auctor lectus." },

                        new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate tur pharetra. Nulla pulvinar nisi quis sem molestie, in luctus mi scelerisque. Nulla facilisi. Duis sit amet volutpat diam. Proin vitae auctor lectus." }

            };

            services = new List<Service>()
            {
                new Service { Header = "Lagning", Textfield = "Fixa Datorn" },
                new Service { Header = "Felsök", Textfield = "Vi Felsöker" },
                new Service { Header = "Byte", Textfield = "Bytar" },
                new Service { Header = "Uppdatering", Textfield = "Uppdaterar windows" },
                new Service { Header = "Bygg", Textfield = "Bygger laptops" },
                new Service { Header = "Demontering", Textfield = "Plockar isär" }


            };
        }

        public override void InitializeDatabase(HBGDatorServiceContext context)
        {

            //abouts.ForEach(a => context.Abouts.Add(a));
            //services.ForEach(s => context.Services.Add(s));
            //Ska tästa om det funkar där efter som  protected override void Seed(HBGDatorServiceContext context) ska inte finnas efter som hela den funktionen görs på automatik av "public override void InitializeDatabase(HBGDatorServiceContext context)"


            // users.ForEach(u => context.Users.Add(u));
            base.InitializeDatabase(context);
        }

    }
}
