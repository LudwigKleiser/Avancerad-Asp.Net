using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebbApi.Controllers
{
    [Route("api/databinding")]
    public class DataBindingController : Controller
    {
        [HttpGet, Route("breakfast")]
        public IActionResult Breakfast(string input)
        {
            if (input.ToLower() == "ägg") return Ok($"Å nej, du borde inte äta {input} till frukost!");
            return Ok($"Ja, {input} är gott! ");

        }

        [HttpGet, Route("square")]
        public IActionResult Square(int value)
        {
            return Ok($"{value} * {value} = {value * value}");
        }

        [HttpGet, Route("listOfNumbers")]
        public IActionResult ListOfNumbers(int numbrFrom, int numbrTo)
        {
           

            var numbers =
              Enumerable
              .Range(numbrFrom, numbrTo)
              .ToArray();
            return Ok(numbers);
        }

        [HttpGet,Route("colorPicker")]
        public IActionResult ColorPicker(string color)
        {
            string html = $"<body style='background-color:{color}'></body>";
            return Content(html, "text/html");
        }
    }
}
