﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TrackMyJob.Domain.Repositories;
using TrackMyJob.Domain.Services;
using TrackMyJob.Framework.Constants;
using TrackMyJob.Framework.Filters;
using TrackMyJob.Framework.Middlewares;
using TrackMyJob.Framework.Repositories;
using TrackMyJob.Infrastructure.Repositories;
using TrackMyJob.Infrastructure.Services;

namespace TrackMyJob.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PrincipalDbContext>(options =>
            {
                //if (this.Environment.IsEnvironment("IntegrationTests"))
                //{
                options.UseInMemoryDatabase("IntegrationTests");
                //}
                //else
                //{
                //    options.UseMySQL(this.Configuration.GetConnectionString("RelationalConnection"));
                //}
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedCultures.Clear();
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
                options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") };
            });

            services.AddMvc().AddMvcOptions(setup => setup.Filters.Add<CommandResultFilterAttribute>());

            services.AddAutoMapper();

            services.AddMediatR();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                info: new Info
                {
                    Title = "TrackMyJob",
                    Version = "v1",
                    Description = "Track My Job App",
                    Contact = new Contact
                    {
                        Name = "Allan Cassiano Weber",
                        Url = "https:/github.com/allanweber"
                    }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "TrackMyJob.xml");
                s.IncludeXmlComments(xmlPath);
            });

            services.AddCors(o => o.AddPolicy(AppConstants.ALLOWALLHEADERS, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();

            services.AddScoped<IProjectService, ProjectService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            var cultureInfo = new CultureInfo("en-US");
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = new List<CultureInfo> { cultureInfo },
                SupportedUICultures = new List<CultureInfo> { cultureInfo },
            });

            app.UseMvcWithDefaultRoute();

            app.UseCors(AppConstants.ALLOWALLHEADERS);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "TrackMyJob");
            });
        }
    }
}
