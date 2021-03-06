﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace HBGDatorServiceDAL.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Can not be empty")]
        [DisplayName("Ämne")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [EmailAddress(ErrorMessage = "Invalid adress, try again (example@teamnordahl.com)")]
        [DisplayName("Din Mail")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Meddelande")]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }

        [Required(ErrorMessage = "Invalid Captcha")]
        [DisplayName("Randomnummer")]
        public string ValidationNumber { get; set; }
    }
}
