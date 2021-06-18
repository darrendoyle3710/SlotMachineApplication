using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Theme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {

        private static readonly string[] Animals = new[]
        {
            "penguin","cat", "tiger","lion","log"
        };

        //Generates a random combination of animals
        [HttpGet]
        public string Get()
        {
            var rnd = new Random();
            
            string randomAnimals = "";
            for (int i = 0; i < 3; i++)
            {
                var returnIndex = rnd.Next(0, 4);
                randomAnimals += Animals[returnIndex];
            }
            return randomAnimals;
        }
    }
}
