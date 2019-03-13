using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentCrud.Data;

namespace StudentCrud
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IStudentRepository, StudentSQLRepository>();

            string connectionstring = "Server=(localdb)\\mssqllocaldb;Database=StudentExample;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<StudentContext>(opt =>
            {
                opt.UseSqlServer(connectionstring);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseStatusCodePagesWithReExecute("/Error/StatusPage", "?code={0}");
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
