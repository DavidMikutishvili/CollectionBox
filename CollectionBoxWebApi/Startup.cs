using System.Text;
using CollectionBoxWebApi.DataLayer;
using CollectionBoxWebApi.DataLayer.Authentication;
using CollectionBoxWebApi.DataLayer.Repositories;
using CollectionBoxWebApi.DataLayer.Repositories.Implementations;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using CollectionBoxWebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace CollectionBoxWebApi
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
            services.AddCors();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");     
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddControllers();

            //services.AddSpaStaticFiles(configuration => {
            //    configuration.RootPath = "ClientApp/dist";
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequiredLength = 1;   
                options.Password.RequireNonAlphanumeric = false;   
                options.Password.RequireLowercase = false; 
                options.Password.RequireUppercase = false; 
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true; 
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders(); 

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
 
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddTransient<JwtService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAlcoholRepository, AlcoholRepository>();
            services.AddTransient<IStampRepository, StampRepository>();
            services.AddTransient<IBookTagRepository, BookTagRepository>();
            services.AddTransient<IAlcoholTagRepository, AlcoholTagRepository>();
            services.AddTransient<IStampTagRepository, StampTagRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                .WithOrigins(new[]{"http://localhost:3000",
                                   "http://localhost:8080",
                                   "http://localhost:8081",
                                   "http://localhost:4200"})
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllers();
            });

            //app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";
            //});
        }
    }
}
