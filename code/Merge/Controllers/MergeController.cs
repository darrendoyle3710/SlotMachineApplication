using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // var numbersService = $"https://{Configuration["numbersServiceURL"]}/numbers";
            var animalsService = $"https://localhost:44348/animals";
            var animalsServiceResponseCall = await new HttpClient().GetStringAsync(animalsService);
            // var lettersService = $"https://{Configuration["lettersServiceURL"]}/letters";
            var numberService = $"https://localhost:44340/bonusnumber";
            var numberServiceTwoResponseCall = await new HttpClient().GetStringAsync(numberService);
            var mergedResponse = $"{animalsServiceResponseCall}{numberServiceTwoResponseCall}";
            return Ok(mergedResponse);
        }
    }
}
