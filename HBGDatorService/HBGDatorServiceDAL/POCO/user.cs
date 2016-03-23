﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBGDatorServiceDAL
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AdminLevel { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }


        public User()
        {

        }

        public User(string username, string password, int adminLevel, string email)
        {
            Username = username;
            Password = password;
            AdminLevel = adminLevel;
            Email = email;
            IsActive = true;

        }
    }
}