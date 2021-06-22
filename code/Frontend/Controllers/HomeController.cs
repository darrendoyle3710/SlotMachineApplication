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
        private IConfiguration Configuration;
        private IRepositoryWrapper repository;

        public HomeController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper)
        {
            Configuration = configuration;
            repository = repositoryWrapper;
        }
        // displays all spins in spin table of database
        [Route("ViewSpins")]
        public ActionResult<IEnumerable<Spin>> ViewSpins()
        {
            var allSpins = repository.Spins.FindAll().ToList();
            return View(allSpins);
        }
        // deletes specific record based on id
        [Route("delete/{id:int}")]
        public ActionResult<Spin> Delete(int id)
        {
            var spinToDelete = repository.Spins.FindByCondition(s => s.ID == id).FirstOrDefault();
            if (spinToDelete == null)
            {
                Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> deleting" + spinToDelete);
            }
            repository.Spins.Delete(spinToDelete);
            repository.Save();

            return RedirectToAction("ViewSpins");
        }

        // parses the merge controller json value into usable viewbags and displays them appropriately 
        [HttpPost("Index")]
        public ActionResult<Spin> Create(AddSpin bindingModel)
        {
            var spinToCreate = new Spin { Animals = bindingModel.Animals, BonusBall = bindingModel.BonusBall, Prize = bindingModel.Prize, CreatedAt = DateTime.Now };
            repository.Spins.Create(spinToCreate);
            repository.Save();
            
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
            if (ViewBag.responseBonusNumber == ViewBag.responseNumber) ViewBag.bonus = true;
            else ViewBag.bonus = false;
            return View();
        }

    }
}
