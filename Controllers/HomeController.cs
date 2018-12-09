using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreSampleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreSampleApp.Controllers
{
    public class HomeController : Controller
    {
        // public string Index()

        // This is not generic
        // public ContentResult Index()  

        public IActionResult Index()
        {
            //this.Response.Headers
            //this.Request
            //this.HttpContext.Request.Headers

            // this returns Bad request 400 error
            //return this.BadRequest();
            //this.File();

            //return Content("Hello from Home Controller !!");

            //return "Hello from Home Controller !!";

            var model = new Resturants { Id = 1, Name = "Santu's Idli Place" };

            // ObjectResult does the Content Negiotiation, it looks for the type of content-type
            return new ObjectResult(model);
        }
    }
}