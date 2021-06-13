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
using SlotMachineApplication.Library.Interfaces;
using SlotMachineApplication.Library.Models.Binding;
using SlotMachineApplication.Library.Models;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;
        private IRepositoryWrapper repository;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            Configuration = configuration;
            repository = repositoryWrapper;
        }

        [Route("Index")]
        public IActionResult Display()
        {
            var allSpins = repository.Spins.FindAll();
            return View(allSpins);
        }

        [HttpPost("Index")]
        public IActionResult Create(AddSpin bindingModel)
        {
            Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> bind model" + bindingModel.Animals + " " + bindingModel.Animals + " bonus " + bindingModel.BonusBall);
            // repository.Spins.Create(new Spin { Animals = bindingModel.Animals, BonusBall = bindingModel.BonusBall, Prize = bindingModel.Prize, CreatedAt = DateTime.Now });
            // repository.Save();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var mergedService = $"https://{Configuration["mergeServiceURL"]}/merge";
            var serviceThreeResponseCall = await new HttpClient().GetStringAsync(mergedService);
            var details = JObject.Parse(serviceThreeResponseCall);
            ViewBag.responsePrize = details["Prize"];
            ViewBag.responseBonusNumber = details["Bonus"];
            ViewBag.responseNumber = details["Number"];
            ViewBag.responseAnimal = details["Animals"];
            Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> view bags" + details["Animals"] + details["Number"] + details["Bonus"] + details["Prize"]);
            if (ViewBag.responseBonusNumber == ViewBag.responseNumber) ViewBag.bonus = "true";
            else ViewBag.bonus = "false";
            Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> num" + details["Number"] + " bonus " + details["Bonus"]);
            return View();
        }

    }
}
