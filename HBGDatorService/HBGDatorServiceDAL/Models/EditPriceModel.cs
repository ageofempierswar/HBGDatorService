using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HBGDatorServiceDAL.Models
{
    public class EditPriceModel
    {
        public int ID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Textfield { get; set; }
    }
}
