using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerRegisterDatabase.Entities;

namespace CustomerRegisterDatabase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //var connString = @"Data Source=aspnetcustomers.database.windows.net;Initial Catalog=Customers;Integrated Security=False;User ID=ludde;Password=qwerty1!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.UseStatusCodePages();
            app.UseMvc();

        }
    }
}
