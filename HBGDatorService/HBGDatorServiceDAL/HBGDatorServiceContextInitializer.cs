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

        private List<UserAccount> permAdmins;

        protected override void Seed(HBGDatorServiceContext context)
        {
            permAdmins.ForEach(h => context.UserAccount.Add(h));
            base.Seed(context);
        }

        public HBGDatorServiceContextInitializer()
        {
            permAdmins = new List<UserAccount>()
            {
                new UserAccount { FirstName="Test", LastName="Test", Email="test@gmail.com", Admin=true, Username="Admin", Password="admin", ConfirmPassword="admin", RememberMe=true }
            };
        }

        public override void InitializeDatabase(HBGDatorServiceContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
