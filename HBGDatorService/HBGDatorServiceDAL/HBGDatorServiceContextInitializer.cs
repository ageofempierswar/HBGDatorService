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
        private List<About> abouts;

        protected override void Seed(HBGDatorServiceContext context)
        {

            context.Abouts.Add(new About("Header1", @"balblablalblablalbla", "Header2", "heuheuehuehueheuheuhe", "fwqojfwq", "fijsedfiwqfwwq"));
            context.SaveChanges();

        }
        public HBGDatorServiceContextInitializer(HBGDatorServiceContext h)
        {
            this.context = h;
            Seed(context);
            
        }
    }
}
