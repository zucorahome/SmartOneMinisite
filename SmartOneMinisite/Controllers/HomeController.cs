using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartOneMinisite.Data;
using SmartOneMinisite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOneMinisite.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly IConfiguration _configuration;

      public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
      {
         _logger = logger;
         _configuration = configuration;
      }

      public IActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public IActionResult Index([FromQuery] String SignupEmailAddress)
      {
         
         String response = new SmartOneMinisiteDb().AddUSignupEmail(_configuration, SignupEmailAddress);
         String result = "{\"Status\":\"true\",\"message\":\"" + response + "\"}";
         return Json(result);
      }
      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
