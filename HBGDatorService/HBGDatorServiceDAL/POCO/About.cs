using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBGDatorServiceDAL.POCO
{
     public class About
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Textfield { get; set; }

        public About()
        {

        }

        public About(string header, string textfield)
        {
            Header = header; 
            Textfield = textfield;
        }
    }
}