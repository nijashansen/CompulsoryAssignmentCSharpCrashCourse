using System;
using Core.ApplicationServices;
using Core.ApplicationServices.Impl;
using Core.DomainServices;
using Core.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Infrastructure.SQL;
using PetShop.Infrastructure.SQL.Repositories;
using PetShop.UI.restAPI.Data;

namespace PetShop.UI.restAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add CORS
            services.AddCors();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAnyOrigin",
            //                      builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});
            
            if (Environment.IsDevelopment())
            {
                // In-memory database:
                services.AddDbContext<PetShopContext>(opt => opt.UseInMemoryDatabase("PetShopApp"));
            } 
            else 
            {
                // Azure SQL database:
                services.AddDbContext<PetShopContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            

            app.UseDeveloperExceptionPage();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.pets.Add(new Pet
                    {
                        ID = 1,
                        Name = "Peter"
                    });
                    ctx.Add(new Pet
                    {
                        ID = 2,
                        Name = "Lone"
                    });
                    ctx.owners.Add(new Owner
                    {
                        id = 1,
                        name = "Orla"
                    });
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseMvc();
        }
    }
}
