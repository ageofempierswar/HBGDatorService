using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HBGDatorServiceDAL.Models
{
    public class AdminModel
    {

        [Required, MinLength(1), MaxLength(12)]
        public string Username { get; set; }

        [Required, MinLength(1), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int AdminLevel { get; set; }
    }
}