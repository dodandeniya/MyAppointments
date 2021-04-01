using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;
using System.Linq;

namespace MyAppointments.Api.Swagger
{
    internal static class SwaggerConfiguration
    {
        internal static IServiceCollection AddSwaggerDoc(this IServiceCollection services, string identityUrl)
        {
            // Add security definition and scopes to document
            services.AddSwaggerDocument(document =>
            {
                document.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Description = "My Authentication",
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                            {
                                { "myAppoiments_api", "Web Api" }
                            },
                            AuthorizationUrl = identityUrl + "/connect/authorize"

                        },
                    }

                });
                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            }
            );

            return services;
        }

        internal static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = "Swagger",
                    AppName = "Swagger"
                };
            });
            return app;
        }
    }
}
