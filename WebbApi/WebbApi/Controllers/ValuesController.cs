using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;

namespace WebbApi.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
      
        [HttpGet, Route("helloworld")]
       public IActionResult HelloWorld(int times)
        {
            string timesToRepeat= "";
            for (int i = 0; i < times; i++)
            {
                timesToRepeat += "Hello World" + " ";
            }
                return Ok(timesToRepeat);
            
            
        }

        [HttpGet,Route("weekday")]
        public IActionResult WeekDay()
        {
            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();

            if (dayOfTheWeek == "Monday") return Ok("Idag är det måndag");
            if (dayOfTheWeek == "Tuesday") return Ok("Idag är det tisdag ");
            if (dayOfTheWeek == "Wednesday") return Ok("Idag är det Onsdag ");
            if (dayOfTheWeek == "Thursday") return Ok("Idag är det Torsdag ");
            if (dayOfTheWeek == "Friday") return Ok("Idag är det Fredag ");
            if (dayOfTheWeek == "Saturday") return Ok("Idag är det Lördag ");
            if (dayOfTheWeek == "Sunday") return Ok("Idag är det Söndag ");

            return Ok("Hello");
           
        }

        [HttpGet, Route("floskel")]
        public IActionResult Floskel()
        {

            string Url = "http://api.icndb.com/jokes/random";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);

            string result = doc.DocumentNode.SelectNodes("/html/body/pre/text()")[0].InnerText;



            return Ok(result);

            //string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            //if (dayOfTheWeek == "Monday") return Ok("Uh-oh. Sounds like somebody’s got a case of the mondays");
            //if (dayOfTheWeek == "Tuesday") return Ok("Idag är det tisdag ");
            //if (dayOfTheWeek == "Wednesday") return Ok("Idag är det Onsdag ");
            //if (dayOfTheWeek == "Thursday") return Ok("Idag är det Torsdag ");
            //if (dayOfTheWeek == "Friday") return Ok("Idag är det Fredag ");
            //if (dayOfTheWeek == "Saturday") return Ok("Idag är det Lördag ");
            //if (dayOfTheWeek == "Sunday") return Ok("Idag är det Söndag ");

            //return Ok("Hello");

        }
    }
}
