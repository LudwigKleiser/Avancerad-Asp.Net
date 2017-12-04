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

        public DatabaseContext(DbContextOptions<DatabaseContext> context ): base(context)
        {

        }

       
           
        public Customer CustomerById(int id)
        {
            var customerToReturn = Customer.Single(i => i.Id == id);

            return customerToReturn;
        }

    }
}
