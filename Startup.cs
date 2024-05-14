using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace rsa_cripto_descripto
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

            services.AddControllers().AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
            }).AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                option.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Criptografia e descriptografia com RSA",
                    Version = "v1",
                    Description = $@"Exemplo prático e simples para criptografia e descriptografia com RSA<br><br>
<strong>NOTAS DA VERSÃO 1.0</strong>
<br>
- Somente está implementado o gerador de XML.
<br><br>",
                    Contact = new OpenApiContact()
                    {
                        Email = "trajanowilliam@msn.com",
                        Name = "William Trajano",
                        Url = new Uri("http://7xstudio.com.br")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "GNU - GENERAL PUBLIC LICENSE"
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectJavascript("/swagger/ui/js/custom.js");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de exemplo de criptografia RSA");
                c.RoutePrefix = "swagger";
                c.InjectStylesheet("/swagger/ui/css/custom.css");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
