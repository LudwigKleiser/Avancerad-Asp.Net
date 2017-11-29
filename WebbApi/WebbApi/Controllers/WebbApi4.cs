using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebbApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebbApi.Controllers
{
        [Route("api/demo4")]
    public class WebbApi4 : Controller
    {
        [HttpPost, Route("AddPerson")]
      public IActionResult AddPerson(Person person)
        {
            //if(person.Name.Length >20)
            //{
            //    return BadRequest("Namnet är för långt");
            //}

            //if(person.Age <= 0 || person.Age >= 120)
            //{
            //    return BadRequest("Åldern får bara vara mellan 0-120 år");
            //}

            if(!ModelState.IsValid)
            {
                //var errorList = ModelState.Values.SelectMany(m => m.Errors)
                //                 .Select(e => e.ErrorMessage)
                //                 .ToArray();
                return BadRequest(ModelState);
            }
            return Ok($"Du har angett en person med namnet: '{person.Name}' med åldern '{person.Age}'");
        }
    }
}
