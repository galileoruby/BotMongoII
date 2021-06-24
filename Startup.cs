
using Autofac;
using AutoMapper;
using BotMongoII.Database;
using BotMongoII.GraphQL;
using BotMongoII.GraphQL.Zip;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotMongoII
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MaperProfile());
                 
            });

            mapperConfig.AssertConfigurationIsValid();

            //automapper
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IMongoClient>(g =>
            {
                return new MongoClient(Configuration.GetSection("Database").GetSection("Conection").Value);
            });

            services.AddScoped(g =>
            g.GetService<IMongoClient>().StartSession()
            );

            services.AddGraphQL(
             (options, provider) =>
             {
                 // Load GraphQL Server configurations
                 var graphQLOptions = Configuration
              .GetSection("GraphQL")
              .Get<GraphQLOptions>();
                 options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                 options.EnableMetrics = graphQLOptions.EnableMetrics;
                 // Log errors
                 var logger = provider.GetRequiredService<ILogger<Startup>>();
                 options.UnhandledExceptionDelegate = ctx =>
                     logger.LogError("{Error} occurred", ctx.OriginalException.Message);
             })
         // Adds all graph types in the current assembly with a singleton lifetime.
         .AddGraphTypes()
         // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
         .AddDataLoader()
         .AddSystemTextJson();

            /*
                GraphQL.NET SDK uses the builder pattern to configure the required GraphQL services. 
                The AddGraphQL method configures certain global settings, such as the maximum depth of a query. 
                We also configured the logger to capture and log any unhandled GraphQL exceptions.
                The AddGraphTypes method scans the application's assembly to detect the types (schema, queries, and mutations)
                and registers them in the DI container with a singleton lifetime.
                The AddDataLoader method optimizes the calls to our repository so that data is served with as few database 
                requests as possible. 
                You can read more about this feature on the GraphQL.NET documentation.
                GraphQL.NET supports JSON serialization of requests and responses through both System.Text.JSON and Newtonsoft.JSON. 
                The AddSystemTextJson method instructs it to use System.Text.JSON to serialize requests and responses.
             */


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseRouting();




            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphQLAltair("/");

            app.UseGraphQL<ZipSchema>("/zip");
            app.UseGraphQL<AirSchema>("/air");             


        }


        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<AirRepository>().As<IAirRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ZipRepository>().As<IZipRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();             

            builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
            builder.RegisterType<AirSchema>().AsSelf().SingleInstance();

            builder.RegisterType<ZipQueryObject>().AsSelf().SingleInstance();
            builder.RegisterType<ZipSchema>().AsSelf().SingleInstance();

        }
    }
}
