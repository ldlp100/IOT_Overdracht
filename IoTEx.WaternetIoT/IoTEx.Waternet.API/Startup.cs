using Azure.Core;
using Azure.Identity;
using IoTEx.Waternet.API.Controllers;
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.ViewModels;
using Kusto.Ingest.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;


namespace IoTEx.Waternet.API
{
    public class Startup
    {
        private bool isDev;

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {



            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {


            // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApi(options =>
                    {
                        Configuration.Bind("AzureAd", options);
                        options.Events = new JwtBearerEvents();

                        /// <summary>
                        /// Below you can do extended token validation and check for additional claims, such as:
                        ///
                        /// - check if the caller's tenant is in the allowed tenants list via the 'tid' claim (for multi-tenant applications)
                        /// - check if the caller's account is homed or guest via the 'acct' optional claim
                        /// - check if the caller belongs to right roles or groups via the 'roles' or 'groups' claim, respectively
                        ///
                        /// Bear in mind that you can do any of the above checks within the individual routes and/or controllers as well.
                        /// For more information, visit: https://docs.microsoft.com/azure/active-directory/develop/access-tokens#validate-the-user-has-permission-to-access-this-data
                        /// </summary>

                        //options.Events.OnTokenValidated = async context =>
                        //{
                        //    string[] allowedClientApps = { /* list of client ids to allow */ };

                        //    string clientappId = context?.Principal?.Claims
                        //        .FirstOrDefault(x => x.Type == "azp" || x.Type == "appid")?.Value;

                        //    if (!allowedClientApps.Contains(clientappId))
                        //    {
                        //        throw new System.Exception("This client is not authorized");
                        //    }
                        //};
                    }, options => { Configuration.Bind("AzureAd", options); });

            // The following flag can be used to get more descriptive errors in development environments
            IdentityModelEventSource.ShowPII = false;

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<BaseController>>();
            services.AddSingleton(typeof(ILogger), logger);


            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "IoTEx Waternet API", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{Configuration.GetValue<string>("AzureAd:TenantId")}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"https://login.microsoftonline.com/{Configuration.GetValue<string>("AzureAd:TenantId")}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {
                                    $"api://{Configuration.GetValue<string>("AzureAd:ClientId")}/IoTEx.User",
                                    "IoTEx.User"
                                }
                            }
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "oauth2",
                            In = ParameterLocation.Header
                        },
                        new[] { $"api://{Configuration.GetValue<string>("AzureAd:ClientId")}/IoTEx.User" }
                    }
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //services.AddSwaggerGen(
            //    options =>
            //    {
            //        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //        {
            //            Type = SecuritySchemeType.OAuth2,
            //            Flows = new OpenApiOAuthFlows()
            //            {
            //                Implicit = new OpenApiOAuthFlow()
            //                {
            //                    AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{Configuration.GetValue<string>("AzureAd:TenantId")}/oauth2/v2.0/authorize"),
            //                    TokenUrl = new Uri($"https://login.microsoftonline.com/{Configuration.GetValue<string>("AzureAd:TenantId")}/oauth2/v2.0/token"),
            //                    Scopes = new Dictionary<string, string> {
            //                        {
            //                            $"api://{Configuration.GetValue<string>("AzureAd:ClientId")}/IoTEx.User",
            //                            "IoTEx.User"
            //                        }
            //                    }

            //                }
            //            }
            //        });
            //        options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
            //            {
            //                new OpenApiSecurityScheme {
            //                    Reference = new OpenApiReference {
            //                            Type = ReferenceType.SecurityScheme,
            //                                Id = "oauth2"
            //                        },
            //                        Scheme = "oauth2",
            //                        Name = "oauth2",
            //                        In = ParameterLocation.Header
            //                },
            //                new []{ $"api://{Configuration.GetValue<string>("AzureAd:ClientId")}/IoTEx.User" }
            //            }
            //        });
            //    }
            //    );
            services.AddSwaggerGenNewtonsoftSupport();
            // Allowing CORS for all domains and HTTP methods for the purpose of the sample
            // In production, modify this with the actual domains and HTTP methods you want to allow
            services.AddCors(o => o.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            //DATABASE 
            string connectionstring = Configuration.GetConnectionString("IOT_DB");
            services.AddDbContext<IoTDBContext>(options =>
                    options.UseSqlServer(connectionstring));

            // Add the KustoService to the dependency injection container
            services.AddScoped<IKustoService>(provider=>
            {
                // Authenticate with the user-assigned managed identity using the Azure.Identity library
                KustoService kustoService = null;
                bool runLocal = Configuration.GetValue<bool>("Kusto:RunLocal");
                string? clusterUri = Configuration["Kusto:ClusterUri"];

                if (!runLocal)
                {                    
                    string? userAssignedClientId = Configuration.GetValue<string>("Kusto:ManagedIdentityClientId");
                    kustoService = new KustoService(clusterUri, userAssignedClientId);
                }
                else
                {
                    //AccessToken token = credential.GetToken(new TokenRequestContext(new[] { clusterUri }));
                    string? clientId = Configuration["Kusto:APP_CLIENT_ID"]; // "b1ece2c9-224b-48ca-bad2-cf9c15fac68e";
                    string? secret = Configuration["Kusto:APP_SECRET"]; //Y1N8Q~JYsw6QFX.RBbxnVMaY9Dr0p-gWRyJRBcPe";
                    string? tenantId = Configuration["Kusto:APP_TENANT_ID"];//Configuration["AzureAd:TenantId"]
                    kustoService = new KustoService(clusterUri,tenantId,clientId, secret);
                }
                
                kustoService.CreateTableTelemetry();
                kustoService.CreateTableMessage();
                kustoService.CreateTableDevice();
                
                return kustoService; 

            });

            services.AddAzureClients(builder =>
            {
                // Add a KeyVault client
                //builder.AddSecretClient(keyVaultUrl);

                // Add a storage account client
                
                builder.AddBlobServiceClient(new Uri(Configuration["Storage_Data_URI"]));

                builder.UseCredential(new DefaultAzureCredential());

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string d = Configuration.GetValue<string>("AzureAd:ClientId");


            if (env.IsDevelopment())
            {
                // Since IdentityModel version 5.2.1 (or since Microsoft.AspNetCore.Authentication.JwtBearer version 2.2.0),
                // Personal Identifiable Information is not written to the logs by default, to be compliant with GDPR.
                // For debugging/development purposes, one can enable additional detail in exceptions by setting IdentityModelEventSource.ShowPII to true.
                // Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    
                    c.OAuthClientId( Configuration.GetValue<string>("AzureAd:ClientId"));

                });
                this.isDev = true;
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId(Configuration.GetValue<string>("AzureAd:ClientId"));
                    c.OAuthUsePkce();
                    c.OAuthScopeSeparator(" ");
                    
                }
                );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("default");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public class StorageConfiguration
    {
        public string ServiceUri { get; set; }
    }
}
