using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(DatabaseContext databaseContext, ILogger<CustomerController> logger)
        {
            this.databaseContext = databaseContext;
            _logger = logger;
        }

        [HttpPost,Route("addcustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            databaseContext.AddCustomer(customer);
            _logger.LogInformation("Customer added");
            return Ok(customer.Id);
        }

        [HttpPost,Route("removecustomer")]
        public IActionResult RemoveCustomer(int id)
        {
            databaseContext.RemoveCustomer(id);

            return Ok("Removed");

        }

        [HttpGet,Route("editcustomer")]
        public IActionResult EditCustomer(int id)
        {
            var userToEdit = databaseContext.CustomerById(id);

            

            return Ok(userToEdit);
        }

        [HttpPost,Route("editcustomer")]
        public IActionResult EditCustomer(Customer customer)
        {
            var userToEdit = databaseContext.CustomerById(customer.Id);
            var dateEdited = DateTime.Now;
            userToEdit.FirstName = customer.FirstName;
            userToEdit.LastName = customer.LastName;
            userToEdit.Email = customer.Email;
            userToEdit.Age = customer.Age;
            userToEdit.Gender = customer.Gender;
            userToEdit.DateEdited = dateEdited;
            databaseContext.Customer.Update(userToEdit);
            databaseContext.SaveChanges();

            return Ok("edited");
        }
        

        [HttpGet,Route("allcustomers")]

        public IActionResult AllCustomers()
        {
            _logger.LogInformation("Getting all customers");
            return Ok(databaseContext.Customer);
        }

        [HttpGet,Route("seed")]
        public IActionResult Seed()
        {
            databaseContext.Seed();

            return Ok("Removed customers from database and added new ones from textfile");
        }
    }
}
