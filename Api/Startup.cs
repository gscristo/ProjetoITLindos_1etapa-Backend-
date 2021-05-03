using Api.Config;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace Api
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
            ServiceInjection.Configure(services, Configuration);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                var apiVersionInfoDescription = new StringBuilder();

                apiVersionInfoDescription.AppendLine("<b>NOTES</b>");
                apiVersionInfoDescription.AppendLine("<p>");
                apiVersionInfoDescription.AppendLine("Api de integração para o Lean Learning");
                apiVersionInfoDescription.AppendLine("</p>");

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lean Learning API",
                    Description = apiVersionInfoDescription.ToString().Replace(Environment.NewLine, "<br>"),
                    Contact = new OpenApiContact
                    {
                        Name = "Powered by - IT Lean",
                        Email = "contato@itlean.com.br",
                        Url = new Uri("https://www.itlean.com.br"),
                    }
                });
            });

            services
                .AddMemoryCache()
                .AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    setupAction.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    setupAction.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            services
                .AddOptions()
                .AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
                });

            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => {/*c.SerializeAsV2 = true;*/});

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "Lean Learning API"); });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

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
