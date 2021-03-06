﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL.Models;
namespace HBGDatorService.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error(int id)
        {

            ErrorModel model = new ErrorModel();
            Response.StatusCode = id;
            switch (Response.StatusCode)
            {
                case 401:
                    model.StatusCode = 401;
                    model.ErrorMessage = "Unauthorized";
                    break;
                case 400:
                    model.StatusCode = 400;
                    model.ErrorMessage = "Bad Request";
                    break;
                case 404:
                    model.StatusCode = 404;
                    model.ErrorMessage = "Not Found";
                    break;
                case 403:
                    model.StatusCode = 403;
                    model.ErrorMessage = "Forbidden";
                    break;
                case 500:
                    model.StatusCode = 500;
                    model.ErrorMessage = "Internal Server Error";
                    break;
                case 502:
                    model.StatusCode = 502;
                    model.ErrorMessage = " Bad Gateway";
                    break;

            }
            return View(model);
        }
    }
}