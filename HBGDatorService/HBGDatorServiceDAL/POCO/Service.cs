using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBGDatorServiceDAL.POCO
{
   public class Service
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Textfield { get; set; }

        public Service()
        {

        }
 
        public Service(string Header, string Textfield)
        {
           this.Header = Header;
            this.Textfield = Textfield;
        }
    }
}
