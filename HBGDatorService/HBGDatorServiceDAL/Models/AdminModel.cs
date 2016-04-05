using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HBGDatorServiceDAL.Models
{
    public class AdminModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int AdminLevel { get; set; }
    }
}