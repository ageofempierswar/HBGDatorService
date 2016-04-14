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
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string Header4 { get; set; }
        public string Header5 { get; set; }
        public string Header6 { get; set; }
        public string Textfield1 { get; set; }
        public string Textfield2 { get; set; }
        public string Textfield3 { get; set; }
        public string Textfield4 { get; set; }
        public string Textfield5 { get; set; }
        public string Textfield6 { get; set; }
        public Service()
        {

        }

        public Service(string header1, string textfield1, string header2, string textfield2, string header3, string textfield3, string header4, string textfield4, string header5, string textfield5, string header6, string textfield6)
        {
            Header1 = header1;
            Header2 = header2;
            Header3 = header3;
            Textfield1 = textfield1;
            Textfield2 = textfield2;
            Textfield3 = textfield3;
            Header4 = header4;
            Header5 = header5;
            Header6 = header6;
            Textfield4 = textfield4;
            Textfield5 = textfield5;
            Textfield6 = textfield6;
        }
    }
}
