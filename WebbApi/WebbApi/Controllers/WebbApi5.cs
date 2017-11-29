using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebbApi.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebbApi.Controllers
{
    [Route("api/demo5")]
    public class WebbApi5 : Controller
    {
       public List<TextPerson> GetDataFromTextFile()
        {
           var filePath = "C:/Users/ludde/OneDrive/Dokument/Avancerad ASP.net/Avancerad-Asp.Net/WebbApi/WebbApi/Data/Persons.txt";
           var data = System.IO.File.ReadAllLines(filePath);
            var textPersons = new List<TextPerson>();
            
            foreach (var person in data)
            {
                string[] splitString = person.Split(",");

                textPersons.Add(new TextPerson
                {
                    Id = splitString[0],
                    Firstname = splitString[1],
                    Lastname = splitString[2],
                    Gender = splitString[3],
                    Email = splitString[4],
                    Age = splitString[5]

                });
                
            }
            
            return textPersons;
           
            
        }

        [HttpGet,Route("FindPerson")]
        public IActionResult FindPersonById(string id, bool brief)
        {
            var persons = GetDataFromTextFile();
            if (brief)
            {
                try
                {
                    var personToGet = persons.SingleOrDefault(p => p.Id == id);
                    Convert.ToInt32(personToGet.Id);
                    var returnPerson = new SimplePerson
                    {
                        Firstname = personToGet.Firstname,
                        Lastname = personToGet.Lastname
                    };
                    
                    string json = JsonConvert.SerializeObject(returnPerson);
                    return Ok(returnPerson);
                }
                catch (Exception)
                {

                    return NotFound($"Id:et {id} finns inte");
                }
            }
            try
            {
                var dataToReturn = persons.SingleOrDefault(p => p.Id == id);
                Convert.ToInt32(dataToReturn.Id);
                //string json = JsonConvert.SerializeObject(dataToReturn);

                //write string to file
                //System.IO.File.WriteAllText(@"D:\path.txt", json);
                return Ok(dataToReturn);
            }
            catch (Exception)
            {

                return NotFound($"Id:et {id} finns inte");
            }
           

            
        }

        [HttpGet,Route("GetAllPersons")]
        public IActionResult ReturnAllPersons()
        {
            var persons = GetDataFromTextFile();
            //string json = JsonConvert.SerializeObject(persons);
            return Ok(persons);

            
        }

    }
}
