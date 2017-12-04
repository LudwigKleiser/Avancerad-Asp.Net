using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpPost,Route("addcustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            databaseContext.Customer.Add(customer);
            databaseContext.SaveChanges();

            return Ok(customer.Id);
        }

        [HttpPost,Route("removecustomer")]
        public IActionResult RemoveCustomer(int id)
        {
            var userToRemove = databaseContext.CustomerById(id);

            databaseContext.Customer.Remove(userToRemove);
            databaseContext.SaveChanges();

            return Ok("Removed");

        }
        

        [HttpGet,Route("allcustomers")]

        public IActionResult AllCustomers()
        {
            return Ok(databaseContext.Customer);
        }
    }
}
