using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using CollectionBoxWebApi.DataLayer.Helpers;
using CollectionBoxWebApi.DataLayer.Repositories;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CollectionBoxWebApi
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            //services.AddTransient<IGenericRepository<CollectionGallery>, GenericRepository<CollectionGallery>>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAlcoholRepository, AlcoholRepository>();
            services.AddTransient<IStampRepository, StampRepository>();
            services.AddTransient<IBookTagRepository, BookTagRepository>();
            services.AddTransient<IAlcoholTagRepository, AlcoholTagRepository>();
            services.AddTransient<IStampTagRepository, StampTagRepository>();
            services.AddControllers(); 
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
