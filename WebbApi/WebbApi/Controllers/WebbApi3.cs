using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebbApi.Controllers
{
    [Route("api/demo3")]
    public class WebbApi3 : Controller
    {
        [HttpGet, Route("CheckFileFormat")]
        public IActionResult CheckFileFormat(string fileformat)
        {
            fileformat = fileformat.ToUpper();

            if (fileformat.Length != 3)
            {
                return BadRequest("Fel format på filformatet!");
            }

            if (fileformat == "GIF")
            {
                throw new Exception("Gillar inte GIF");
            }

            if (fileformat == "CAT")
            {
                return Content("<img src='' />, html.txt ");
            }

            if (fileformat == "PDF" || fileformat == "DOC" || fileformat == "JPG")
            {
                return Ok($"{fileformat} är ett bra format!");
            }

            return NotFound($"Hittade inte {fileformat}");

        }

        [HttpGet, Route("Lamp")]
        public IActionResult Lamp(bool color)
        {
            if(color)
            {
                string html = $"<body style='background-color:yellow'></body>";
                return Content(html, "text/html");
            }

            if(!color)
            {
                string html = $"<body style='background-color:grey'></body>";
                return Content(html, "text/html");
            }
            return Ok(color);
        }
        [HttpGet, Route("SplitChocolate")]
        public IActionResult SplitChocolate(double number)
        {
            if(number <= 0)
            {
                return BadRequest("Fel format på nummret");
            }
            int totalAmount = 25;
            double result = totalAmount / number;

            return Ok($"Alla får {result} choklad bitar var");
        }
        [HttpGet, Route("Getorder")]
        public IActionResult GetOrder(string input)
        {
            input = input.ToUpper();
            if(input.Length <= 6 || input.Length >=8)
            {
                return BadRequest("Wrong format");
            }
            if (!input[2].ToString().Contains("-"))
            {
                return BadRequest("Wrong format, must use -(xx-0000)");
            }
            
            try
            {
                Int32.Parse(input[3].ToString());
                Int32.Parse(input[4].ToString());
                Int32.Parse(input[5].ToString());
                Int32.Parse(input[6].ToString());
            }
            catch (Exception)
            {

                return BadRequest("Wrong format");
            }
            int x = Int32.Parse(input[3].ToString());
            if (x >= 3)
            {
                return NotFound("Number must be under 3000");
            }


            if(!CheckIfLetter(input[0]) || !CheckIfLetter(input[1]))
            {
                return BadRequest("First two characters must contain letters");
            }


            return Ok($"Order {input} was found");
        }
        [HttpGet, Route("SearchUser")]
        public IActionResult SearchUser(string input)
        {
            input = input.ToLower();
            if(input == "stewie")
            {
                throw new Exception("DATA ERROR!");
            }
            if (input == "peter")
            {
                return Content("<img src='/img/Explosion.jpg'/>", "text/html");
            }

            if (input == "lois"  ||
                input == "meg"   ||
                input == "chris" ||
                input == "brian")
            {
                return Content("<img src='/img/thumps-up.jpg'/>", "text/html");
            }

            return Content("<img src='/img/thumbs-down.jpg'/>", "text/html");
        }

        private bool CheckIfLetter(char characterToCompare)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'};
            characterToCompare = characterToCompare.ToString().ToLower().ToCharArray()[0];
            foreach (char letter in alphabet)
            {
                if (letter == characterToCompare)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
