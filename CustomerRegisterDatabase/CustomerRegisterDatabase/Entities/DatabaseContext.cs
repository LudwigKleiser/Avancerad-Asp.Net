using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegisterDatabase.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> context) : base(context)
        {

        }
         public void RemoveCustomer(int id)
        {
            var userToRemove = CustomerById(id);
            Customer.Remove(userToRemove);

            SaveChanges();
        }

       
        public void AddCustomer(Customer customer)
        {
            var dateAdded = DateTime.Now;
            customer.DateCreated = dateAdded;
            Customer.Add(customer);
            SaveChanges();
        }
        public Customer CustomerById(int id)
        {
            var customerToReturn = Customer.Single(i => i.Id == id);

            return customerToReturn;
        }

        public List<Customer> GetDataFromTextFile()
        {
            var filePath = "wwwroot/customers.txt";
            var data = System.IO.File.ReadAllLines(filePath);
            var textCustomers = new List<Customer>();

            foreach (var person in data)
            {
                string[] splitString = person.Split(",");

                textCustomers.Add(new Customer
                {
                    //Id = Convert.ToInt32(splitString[0]),
                    FirstName = splitString[1],
                    LastName = splitString[2],
                    Gender = splitString[3],
                    Email = splitString[4],
                    Age = Convert.ToInt32(splitString[5])

                });


            }
            return textCustomers;
        }

        public void EmptyDataBase()
        {
            foreach (var customer in Customer)
            {
                Customer.Remove(customer);
            }

            SaveChanges();
        }

        public void Seed()
        {
            EmptyDataBase();
            var customersToAdd = GetDataFromTextFile();

            foreach (var customer in customersToAdd)
            {
                AddCustomer(customer);
            }
        }

    }
}
