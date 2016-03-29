using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HBGDatorServiceDAL
{
    class HBGDatorServiceContextInitializer : DropCreateDatabaseAlways<HBGDatorServiceContext>
    {
    }
}
