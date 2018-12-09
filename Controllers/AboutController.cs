using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreSampleApp.Controllers
{
    // Generic way to handle controller and actions
    // [Route("company/[controller]/[action]")]

    [Route("about")]
    public class AboutController : Controller
    {

        [Route("ResidentPhone")]
        public IActionResult Phone()
        {
            return View("Phone");
        }

        [Route("ResidentAddress")]
        public IActionResult Address()
        {
            return View("Address");
        }

        //[Route("ResidentPhone")]
        //public string Phone()
        //{
        //    return "7416220583";
        //}

        //[Route("ResidentAddress")]
        //public string Address()
        //{
        //    return "India";
        //}
    }
}