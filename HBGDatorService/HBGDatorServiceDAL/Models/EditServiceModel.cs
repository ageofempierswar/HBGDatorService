using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBGDatorServiceDAL.Models
{
    public class EditServiceModel
    {
        public int ID { get; set; }
        public string Header { get; set; }
        [DataType(DataType.MultilineText)]
        public string Textfield { get; set; }

    }
}
