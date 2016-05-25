using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HBGDatorServiceDAL.POCO
{
    public class Service
    {
        public int ID { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Rubrik")]
        public string Header { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Innehåll")]
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
