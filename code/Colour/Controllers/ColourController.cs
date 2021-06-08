using Microsoft.AspNetCore.Mvc;
using System;

namespace Colour.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColourController : ControllerBase
    {
        private static readonly string[] Colours = new[]
        {
            "Blue","Green", "Red","Yellow","Purple"
        };

        [HttpGet]
        public string Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 4);
            return Colours[returnIndex];
        }

    }
}
