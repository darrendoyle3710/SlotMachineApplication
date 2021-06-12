using Microsoft.AspNetCore.Mvc;
using System;

namespace Colour.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BonusNumberController : ControllerBase
    {
        private static readonly int[] Numbers = new[]
        {
            1,2,3,4,5,6,7,8,9,0
        };

        [HttpGet]
        public int Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 9);
            return Numbers[returnIndex];
        }

    }
}
