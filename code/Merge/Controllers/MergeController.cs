﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        private IConfiguration Configuration;
        public MergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static readonly string[] Prizes = new[]
        {
            "Nothing","$100","$500", "$1500","$10000","Ferrari"
        };

        Dictionary<string, int> animalTracker = new Dictionary<string, int> { { "penguin", 0 }, { "cat", 0 }, { "tiger", 0 }, { "lion", 0 }, { "dog", 0 }, };

        private static readonly string[] Numbers = new[]
        {
            "1","2","3","4","5","6","7","8","9","0"
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var animalsService = $"https://{Configuration["animalServiceURL"]}/animals";
            var animalsServiceResponseCall = await new HttpClient().GetStringAsync(animalsService);
            var numberService = $"https://{Configuration["numberServiceURL"]}/bonusnumber";
            var numberServiceTwoResponseCall = await new HttpClient().GetStringAsync(numberService);
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 9);
            var prize = Prizes[0];
            if (numberServiceTwoResponseCall == Numbers[returnIndex]) prize = Prizes[1];
            

            //logic
            string compareStr = "";
            for (int i = 0; i < animalsServiceResponseCall.Length; i++)
            {
                compareStr += animalsServiceResponseCall[i];
                if (animalTracker.ContainsKey(compareStr))
                {
                    animalTracker[compareStr] += 1;
                    compareStr = "";
                }
            }

            foreach (KeyValuePair<string, int> animal in animalTracker)
            {
                if(animal.Value == 3)
                {
                    if (numberServiceTwoResponseCall == Numbers[returnIndex]) prize = Prizes[5];
                    else prize = Prizes[4];
                } 
                else if(animal.Value == 2)
                {
                    if (numberServiceTwoResponseCall == Numbers[returnIndex]) prize = Prizes[3];
                    else prize = Prizes[2];
                } 
                System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> bonus ball:" + Numbers[returnIndex] + " Key: {0}, Value: {1}", animal.Key, animal.Value);
            }
            string mergedResponse = $@"{{'Animals':'{ animalsServiceResponseCall}','Number':'{numberServiceTwoResponseCall}','Prize':' {prize}'}}";
            return Ok(mergedResponse);
        }
    }
}
