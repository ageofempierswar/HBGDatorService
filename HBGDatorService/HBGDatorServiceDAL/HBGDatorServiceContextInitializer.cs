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
    {
        private HBGDatorServiceContext context;
        private List<About> abouts; //används inte.

        protected override void Seed(HBGDatorServiceContext context)
        {
            context.Abouts.Add(new About("Header1", @"balblablalblablalbla",
                "Header2", "heuheuehuehueheuheuhe", "fwqojfwq", "fijsedfiwqfwwq"));
            context.SaveChanges();

            //context.Abouts.Add(new About("Team Nordahl","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean et enim quis sem blandit mollis eu sed nibh. Pellentesque eu neque erat. Nullam tempus purus velit, sed ullamcorper est suscipit ac. Aenean molestie odio ut purus tristique tempus. Suspendisse sed purus eget augue vulputate dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vel fermentum nunc. Nam nec dapibus tortor. Cras tellus nibh, fringilla ut facilisis et, fringilla sit amet erat. In tem...(line truncated)...",
            //              "Camargue","Maecenas finibus viverra tincidunt. Praesent vitae est sed sem pharetra consequat. Phasellus facilisis lacus velit, id lacinia elit facilisis sit amet. Nullam luctus, nisi sit amet bibendum convallis, justo felis sodales eros, nec rutrum tellus sapien ornare ex. Morbi fermentum tristique magna ut hendrerit. Mauris tincidunt ante ut libero mollis, eu pulvinar nunc dapibus. Fusce vestibulum nibh dui, ut blandit nisl pellentesque eu. In id sapien eget neque suscipit sollicitudin...(line truncated)...",
            //              "Our Ranch",
            //              "In congue, quam sed luctus aliquam, neque ipsum ultricies quam, at blandit magna sem a orci. Nulla leo quam, tempor nec lacus vitae, feugiat elementum lectus. Phasellus pellentesque rhoncus est quis luctus. Fusce imperdiet, eros quis volutpat ultricies, nulla nulla tincidunt purus, et varius urna libero in velit. Morbi vulputate convallis leo. Ut venenatis odio sit amet nisi condimentum semper. Etiam nunc tellus, mattis nec turpis eget, eleifend rhoncus tortor. Aenean id sem ...(line truncated)...)"));
            //context.SaveChanges(); vill testa hur det ser ut med denna texten men fick ej det att funka


        }
        public HBGDatorServiceContextInitializer(HBGDatorServiceContext h)
        {
            this.context = h;
            Seed(context);
            
        }
    }
}
