using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBGDatorServiceDAL.POCO
{
    public class Price
    {
        public int ID { get; set; }
        public string Textfield { get; set; }
        public Price()
        {
        }
        public Price(string Textfield)
        {
            this.Textfield = Textfield;
        }
    }

}
