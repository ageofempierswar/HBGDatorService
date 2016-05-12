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
    public class HBGDatorServiceContextInitializer : DropCreateDatabaseAlways<HBGDatorServiceContext>//DropCreateDatabaseAlways i våra test(när vi lägger till nya saker) Modelchanges när vi ska ge bort projektet till HBGDatroservice
    //Modelchanges är standard i de flesta projekt som är större än en 5min lösning till skoluppgifter med tanke på hur stor en riktig lösning är, tex, den vi jobbar med nu.
    {

        private HBGDatorServiceContext context;
        private List<About> abouts;
        private List<Service> services;
        private List<UserAccount> permAdmins;

        protected override void Seed(HBGDatorServiceContext context)
        // Seed är det som lägger till våra ändringar/tillägg till databasen, som vi har i vår Initializer under denna, alla listor och saker vi adderar eller tar bort har vi här, som sedan läggs in i databasen av InitializeDatabase, det vi hade inann funkade, men vi hade inte savechanges så inget hände, därför det krashade hela tiden vad vi än gjorde. Dåck detta stämmer inte eftersom SaveChanges ska inte vehövas när man har public override void InitializeDatabase(HBGDatorServiceContext context)
        {
            abouts.ForEach(a => context.Abouts.Add(a));
            services.ForEach(s => context.Services.Add(s));
            permAdmins.ForEach(h => context.UserAccount.Add(h));
            context.SaveChanges();
        }

        public HBGDatorServiceContextInitializer()
        {

            abouts = new List<About>()
            {
                new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac Proin vitae auctor lectus." },

                new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tempor . Duis sit amet volutpat diam. Proin vitae auctor lectus." },

                new About { Header = "Team Nordahl",
                            Textfield = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate tur pharetra. Nulla pulvinar nisi quis sem molestie, in luctus mi scelerisque. Nulla facilisi. Duis sit amet volutpat diam. Proin vitae auctor lectus." }

            };

            services = new List<Service>() 
            // som du säkert såg i många av våra klasser, så gjorde vi typ header1-6 och textfield1-6, som är rent sagt rätt åt helvete, istället gör man en ny tex service för varje inlägg. Man gör tabeller på höjden, inte bredden, detta gör det också lättare för oss att ha add och remove metoder för inlägg i service eller about eller vad som, istället för att dem är permanenta skrivfält. (^.^)
            {
                new Service { Header = "Lagning", Textfield = "Fixa Datorn" },
                new Service { Header = "Felsök", Textfield = "Vi Felsöker" },
                new Service { Header = "Byte", Textfield = "Bytar" },
                new Service { Header = "Uppdatering", Textfield = "Uppdaterar windows" },
                new Service { Header = "Bygg", Textfield = "Bygger laptops" },
                new Service { Header = "Demontering", Textfield = "Plockar isär" }
            };

            permAdmins = new List<UserAccount>()
            {
                new UserAccount { FirstName="Test", LastName="Test", Email="test@gmail.com", Admin=true, Username="pelle", Password="pass", ConfirmPassword="pass", RememberMe=true }
            };
    }

        public override void InitializeDatabase(HBGDatorServiceContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
