using IdentityModel;
using IdentityServer.Constants;
using IdentityServer.Data.Entities;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer.Data
{
    public static class DbMigrationService
    {
        public static void AddDbMigrate(this IServiceCollection service)
        {
            var sp = service.BuildServiceProvider();
            var persistedGContext = sp.GetRequiredService<PersistedGrantDbContext>();
            persistedGContext.Database.Migrate();

            var configurationContext = sp.GetRequiredService<ConfigurationDbContext>();
            configurationContext.Database.Migrate();

            var identityContext = sp.GetService<ApplicationDbContext>();
            identityContext.Database.Migrate();

            Migrate(sp, configurationContext, identityContext);
        }

        private static void Migrate(ServiceProvider sp, ConfigurationDbContext configurationContext, ApplicationDbContext identityContext)
        {
            if (!configurationContext.IdentityResources.AnyAsync().Result)
            {
                configurationContext.IdentityResources.Add(new IdentityResources.OpenId().ToEntity());
                configurationContext.IdentityResources.Add(new IdentityResources.Email().ToEntity());
                configurationContext.IdentityResources.Add(new IdentityResources.Profile().ToEntity());

                configurationContext.SaveChanges();
            }

            if (!configurationContext.ApiResources.AnyAsync().Result)
            {
                var api = new ApiResource("myAppoiments_api", "Web Api call")
                {
                    ApiSecrets = { new Secret("secret".Sha256()) },
                    Scopes =
                        {
                            "myAppoiments_api.full",
                            "myAppoiments_api.read",
                            "myAppoiments_api"
                        },
                    UserClaims =
                    {
                        ClaimTypes.NameIdentifier,
                        ClaimTypes.Name,
                        ClaimTypes.Email,
                        ClaimTypes.Role,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    }
                };

                //adding local API
                var localApi = new ApiResource(IdentityServerConstants.LocalApi.ScopeName);

                configurationContext.ApiResources.Add(api.ToEntity());
                configurationContext.ApiResources.Add(localApi.ToEntity());

                configurationContext.SaveChanges();
            }

            if (!configurationContext.ApiScopes.AnyAsync().Result)
            {
                var api = new ApiScope("myAppoiments_api", "Web Api call")
                {
                    UserClaims =
                    {
                        ClaimTypes.NameIdentifier,
                        ClaimTypes.Name,
                        ClaimTypes.Email,
                        ClaimTypes.Role,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    }
                };

                var localApi = new ApiScope(IdentityServerConstants.LocalApi.ScopeName);

                configurationContext.ApiScopes.Add(api.ToEntity());
                configurationContext.ApiScopes.Add(localApi.ToEntity());

                configurationContext.SaveChanges();

            }

            if (!configurationContext.Clients.AnyAsync().Result)
            {
                List<Client> clients = new List<Client>() {
                           new Client
                    {
                        ClientId = "mvc",
                        ClientSecrets = { new Secret("secret".Sha256()) },

                        AllowedGrantTypes = GrantTypes.Code,

                        // where to redirect to after login
                        RedirectUris = { "http://localhost:52484/signin-oidc" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { "http://localhost:52484/signout-callback-oidc" },

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "myAppoiments_api"
                        }
                    },
                    new Client
                {
                    ClientId = "myAppoiments_spa",
                    ClientName = "React Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysSendClientClaims = false,
                    RequireConsent = true,

                    RedirectUris = { Startup.Configuration.GetValue<string>("myAppoimentsRedirectURL") },
                    PostLogoutRedirectUris = { Startup.Configuration.GetValue<string>("myAppoimentsPostLogoutURL") },
                    AllowedCorsOrigins = { Startup.Configuration.GetValue<string>("myAppoimentsURL") },

                    ClientSecrets =                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "myAppoiments_api"
                    },
                }, new Client
                {
                    ClientId = "Swagger",
                    ClientName = "Swagger",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret = false,
                    RequireConsent = true,
                    AlwaysSendClientClaims = false,

                    RedirectUris = {Startup.Configuration.GetValue<string>("swaggerRedirectURL") },

                    ClientSecrets =                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myAppoiments_api"
                    },
                }
                };

                foreach (var client in clients)
                {
                    configurationContext.Clients.Add(client.ToEntity());
                }

                configurationContext.SaveChanges();
            }

            if (identityContext.Roles.CountAsync().Result == 0)
            {
                var roleManager = sp.GetService<RoleManager<ApplicationRole>>();

                roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = Role.CompanyUser
                }).Wait();
                roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = Role.PublicUser
                }).Wait();
            }

            if (identityContext.Users.CountAsync().Result == 0)
            {
                var userManager = sp.GetService<UserManager<ApplicationUser>>();

                userManager.CreateAsync(new ApplicationUser()
                {
                    DisplayName = "Company_user 1",
                    UserName = "c1@myappoiments.com",
                    Email = "c1@myappoiments.com",
                    UserType = UserType.CompanyUser

                }, "1qaz!QAZ").Wait();

                var user = userManager.Users.FirstOrDefaultAsync(x => x.UserName == "c1@myappoiments.com").Result;

                userManager.AddToRoleAsync(user, Role.CompanyUser).Wait();

                userManager.CreateAsync(new ApplicationUser()
                {
                    DisplayName = "Public_user 1",
                    UserName = "p1@myappoiments.com",
                    Email = "p1@myappoiments.com",
                    UserType = UserType.PublicUser

                }, "1qaz!QAZ").Wait();

                user = userManager.Users.FirstOrDefaultAsync(x => x.UserName == "p1@myappoiments.com").Result;

                userManager.AddToRoleAsync(user, Role.CompanyUser).Wait();
            }
        }
    }
}