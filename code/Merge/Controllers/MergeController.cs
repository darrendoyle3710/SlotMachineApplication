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
            var coloursService = $"https://localhost:44340/colour";
            var serviceOneResponseCall = await new HttpClient().GetStringAsync(coloursService);
            // var lettersService = $"https://{Configuration["lettersServiceURL"]}/letters";
            var themesService = $"https://localhost:44348/theme";
            var serviceTwoResponseCall = await new HttpClient().GetStringAsync(themesService);
            var mergedResponse = $"{serviceOneResponseCall}{serviceTwoResponseCall}";
            return Ok(mergedResponse);
        }
    }
}
