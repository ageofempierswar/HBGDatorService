using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HBGDatorServiceDAL.POCO
{
    public class News
    {
        [Key]
        public int newsID { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name ="Rubrik")]
        public string newsTopic { get; set; }

        [Display(Name = "Datum")]
        public DateTime newsDate { get; set; }

        [MaxLength(3000)]
        [Display(Name = "Nyhetsfält")]
        public string newsBody { get; set; }
    }
}
