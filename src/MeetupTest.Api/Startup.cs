using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using MediatR;
using MeetupTest.Domain.Validators;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Api.Middleware;
using MeetupTest.Domain;
using MeetupTest.Persistence;

namespace MeetupTest.Api
{
    public class Startup
    {
        private IConfigurationRoot _configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddApplicationInsightsSettings(developerMode: true);

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'V");

            services.AddMvc();
            services.AddApiVersioning();
            services.AddLogging();
            services.AddSwaggerGen(
            options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new Info
                    {
                        Title = $"MeetupTest API v{description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                        Description = ".NET Core Meetup Test",
                        Contact = new Contact { Name = "Sean Adamson", Url = "https://github.com/Adamsons/Meetup" },
                    });
                }

                options.OperationFilter<SwaggerDefaultValues>();
            });

            services.AddMediatR();
            services.AddDomainServices();

            services.AddApplicationInsightsTelemetry(_configuration);

            services.AddTransient<IRequestValidator<CreateReservationRequest>, CreateReservationValidator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMvc();
            app.UseApiVersioning();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            });

#if DEBUG
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MeetupContext>();
                context.SeedData();
            }
#endif
        }
    }
}
