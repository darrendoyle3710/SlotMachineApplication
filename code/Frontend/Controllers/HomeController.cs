using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Frontend.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var mergedService = $"https://{Configuration["mergeServiceURL"]}/merge";
            var serviceThreeResponseCall = await new HttpClient().GetStringAsync(mergedService);
            var details = JObject.Parse(serviceThreeResponseCall);
            ViewBag.responsePrize = string.Concat("You Win " + details["Prize"] + "! " + "Bonus Ball was " + details["Bonus"]);
            ViewBag.responseNumber = string.Concat("Number: " + details["Number"]);
            ViewBag.responseAnimal = string.Concat("Animals: " + details["Animals"]);


            return View();
        }

    }
}
