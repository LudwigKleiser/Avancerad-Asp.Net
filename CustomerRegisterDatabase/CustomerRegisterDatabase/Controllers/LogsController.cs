using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/log")]
    public class LogsController : Controller
    {
        // GET: /<controller>/
        [HttpGet,Route("get")]
        public IEnumerable<string> Get()
        {
            var getDir = AppDomain.CurrentDomain.BaseDirectory;
            var log = System.IO.File.ReadAllLines($"{getDir}/log/nlog-own.log");

            return log;

        }
    }
}
