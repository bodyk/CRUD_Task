﻿
using CRUD_Task.DAL.Implementations;
using CRUD_Task.DAL.Interfaces;
using CRUD_Task.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_Task.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>(opt => opt.UseSqlServer("Server=tcp:wondrmakr.database.windows.net,1433;" +
                                                                      "Initial Catalog=WondrMakrApiDb;Persist Security Info=False;" +
                                                                      "User ID=WondrMakr_admin;Password=AppDbStorage1;" +
                                                                      "Multiple ActiveResultSets=False;Encrypt=True;" +
                                                                      "TrustServerCertificat e=False;Connection Timeout=30;"));

            services.AddTransient<IUnitOfWork, IUnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
