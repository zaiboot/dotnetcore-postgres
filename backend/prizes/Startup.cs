﻿namespace prizes
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Autofac;
    using Prizes.Api.Mapping;
    using Prizes.Api.Filters;
    using System.Reflection;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using prizes.Repository;
    using Prizes.Api.Settings;
    using Microsoft.Extensions.Options;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            
            services.AddOptions();
            services.Configure<PrizesSettings>(Configuration);
            
            services.AddDbContextPool<ApiDataContext>(options =>
            {               
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutofacRegistrations(builder);
        }

        private void AddAutofacRegistrations(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();
            builder.RegisterType<GlobalExceptionFilter>();


            #region REPOSITORY

            builder.RegisterAssemblyTypes(
                Assembly.GetAssembly(typeof(ICustomerRepository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            #endregion

            #region COMMON
           
           builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<PrizesSettings>>();
                return options.Value;
            }).InstancePerLifetimeScope();
            builder.Register(ctx =>
            {
                var logger = ctx.Resolve<ILogger<MappingEngine>>();

                IEnumerable<Assembly> assemblies = new[]
                {
                    Assembly.GetExecutingAssembly()
                };
                //This is how we tell mapping engine to be generated. The list of assemblies cannot be autogenerated
                return new MappingEngine(assemblies, logger);
            }).As<IMappingEngine>().InstancePerLifetimeScope();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            loggerFactory.AddLog4Net();
        }
    }
}
