using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HBGDatorServiceDAL.Models
{
    public class EditServiceModel
    {
        public int ID { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string Header4 { get; set; }
        public string Header5 { get; set; }
        public string Header6 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield4 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield5 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield6 { get; set; }
    }
}
