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
            // var mergedService = $"https://{Configuration["mergeServiceURL"]}/merge";
            var mergedService = $"https://localhost:44370/merge";
            var serviceThreeResponseCall = await new HttpClient().GetStringAsync(mergedService);
            ViewBag.responseCall = serviceThreeResponseCall;
            return View();
        }
    
    }
}
