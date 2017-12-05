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
            userToEdit.FirstName = customer.FirstName;
            userToEdit.LastName = customer.LastName;
            userToEdit.Email = customer.Email;
            userToEdit.Age = customer.Age;
            userToEdit.Gender = customer.Gender;
            databaseContext.Customer.Update(userToEdit);
            databaseContext.SaveChanges();

            return Ok("edited");
        }
        

        [HttpGet,Route("allcustomers")]

        public IActionResult AllCustomers()
        {
            return Ok(databaseContext.Customer);
        }
    }
}
