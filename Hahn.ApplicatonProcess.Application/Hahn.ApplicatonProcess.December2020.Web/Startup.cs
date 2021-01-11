//using Askmethat.Aspnet.JsonLocalizer.Localizer;

using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data.IoC;
using Hahn.ApplicatonProcess.December2020.Domain.Context;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Repos;
using Hahn.ApplicatonProcess.December2020.Web.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Serilog;




namespace Hahn.ApplicatonProcess.December2020.Web
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

            services.AddControllers()
                   .AddFluentValidation(s =>
                   {
                       s.RegisterValidatorsFromAssemblyContaining<Startup>();
                       s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                   });

    


            #region "localization
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            #endregion

            #region "Entity Framework Inmemory Database"
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(databaseName: "Applicant"));
            #endregion


            //Transient lifetime services are created each time they are requested.

            //The first line registers the generic attributes. This means if you want to use it in the future with a new model, you don’t have to register anything else. 
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //the concrete implementation of the ApplicantRepository
            // services.AddTransient<IApplicantRepository, ApplicantRepository>();


            services.AddScoped<IGenericReadRepository, GenericReadRepository>();
            services.AddScoped<IGenericWriteRepository, GenericWriteRepository>();


            //Enabling CORS
            services.AddCors();
            services.AddApplication();
            #region "Swagger"
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hahn.ApplicatonProcess.Application API",
                    Description = "Hahn.ApplicatonProcess.Application.",

                });

            });

            #endregion



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
          

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.UseStaticFiles();

            // This will make the HTTP requests log as rich logs instead of plain text.
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            // Enabling middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API");
                
            });


            #region "Example Data" //When application will run bellow information will store in Memory database
            var options = new DbContextOptionsBuilder<ApplicationContext>()
              .UseInMemoryDatabase(databaseName: "Applicant")
              .Options;

            using (var context = new ApplicationContext(options))
            {
                var applicant = new Domain.Entities.Applicant
                {
                    Id = 1,
                    Name = "Md Sazzadul Islam",
                    FamilyName = "Sazzad",
                    CountryOfOrigin = "Bangladesh",
                    Address = "House No#8, Road No# 4/3, Block B, Section 12, Mirpur, Dhaka, Bangladesh",
                    EmailAdress = "netsazzad@gmail.com",
                    Age = 31,
                    Hired = true
                };

                context.Applicant.Add(applicant);
                context.SaveChanges();

            }

            #endregion

        }


    }
}
