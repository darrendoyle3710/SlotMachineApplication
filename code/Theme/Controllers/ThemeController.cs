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
    public class ThemeController : ControllerBase
    {

        private static readonly string[] Themes = new[]
        {
            "Sadness","Guilt", "Adventure","Wisdom","Regret"
        };

        [HttpGet]
        public string Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 4);
            return Themes[returnIndex];
        }
    }
}
