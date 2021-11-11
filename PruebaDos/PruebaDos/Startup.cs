using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDos.Repository;
using static PruebaDos.Model.Models;


namespace PruebaDos
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
            services.AddControllers();

            /*
             CADENA DE CONECCION A BASE DE DATOS:
                Source: NOMBRE DEL SERVIDO BASE DE DATOS
                Initial Catalog: NOMBRE DE LA BASE DE DATOS
                Trusted_Connection: True - Dejarlo en caso de que la base de datos no requiera autenticacion
                --- Si la base de datos tiene usuario, use los siguientes parametros y borre Trusted_Connection
                    User Id= Nombre del usuario de la base de datos;
                    Password= Password del usuario de la base de datos
                ConnectRetryCount: 0
             */
            var connection = @"Data Source=DESKTOP-GQFD5MQ;
                                Initial Catalog=tickets; 
                                
                                Trusted_Connection=True;
                                ConnectRetryCount=0";

            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));

            services.AddDistributedMemoryCache(); //This way ASP.NET Core will use a Memory Cache to store session variables
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITiketRepository, TiketRespository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
