using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace QueHice.Api.Extensions
{
    public static class SwaggerConfigurationExtension
    {
    
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    SwaggerConstants.Version,
                    new OpenApiInfo
                    {
                        Title = SwaggerConstants.Title,
                        Version = SwaggerConstants.Version,
                        Description = SwaggerConstants.Description,
                        Contact = new OpenApiContact
                        {
                            Name = SwaggerConstants.ContactName,
                            Email = SwaggerConstants.ContactEmail
                        }
                    }
                );

                // Set the comments path for the Swagger JSON and UI.
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var file in dir.EnumerateFiles(SwaggerConstants.JsonFileExt)) c.IncludeXmlComments(file.FullName);
                
                var securitySchema = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = SwaggerConstants.SecurityDescription,
                    Name = SwaggerConstants.SecurityTypeName,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SwaggerConstants.SecurityName,
                    BearerFormat = "JWT",
                };

                c.AddSecurityDefinition(SwaggerConstants.SecurityName, securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme, 
                                Id = "Bearer" 
                            }
                        },
                        new string[] {}

                    }
                });
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app, IConfiguration configuration,
            IWebHostEnvironment env)
        {
            app.UseSwagger();

            var basePath = env.IsDevelopment() ? string.Empty : configuration["ServiceBasePath"];

            app.UseSwaggerUI(c => { c.SwaggerEndpoint($"{basePath}{SwaggerConstants.EndpointUrl}", SwaggerConstants.EndpointName); });
        }
    }

         public static class SwaggerConstants
         {
            
                 public const string Version = "v1";
                 public const string Title = "Web API for Que Hice Hoy";
                 public const string Description = " Web API for Que hice hoy!";
                 public const string ContactName = "Jorge T";
                 public const string ContactEmail = "misuperbuzon@hotmail.com";            
                 public const string JsonFileExt = "*.xml";

                 public const string SecurityName = "Bearer";            
                 public const string SecurityDescription = "Please paste JWT Token with Bearer + White Space + Token into field";            
                 public const string SecurityTypeName = "Authorization";

                 public const string EndpointUrl = "/swagger/v1/swagger.json";
                 public const string EndpointName = "SERICY NOTIFICATIONS API V1.0";        
             }
         }
    
         
