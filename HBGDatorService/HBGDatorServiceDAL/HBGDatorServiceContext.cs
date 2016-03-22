using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBGDatorServiceDAL.POCO;
namespace HBGDatorServiceDAL
{
    class HBGDatorServiceContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
    }
}
