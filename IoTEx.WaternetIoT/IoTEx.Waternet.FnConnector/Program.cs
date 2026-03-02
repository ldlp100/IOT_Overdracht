using Azure.Core;
using Azure.Identity;
using IoTEx.WaternetIoT.DAL;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureLogging(logging =>
    {
        logging.AddFilter("Microsoft", LogLevel.Warning)
               .AddFilter("System", LogLevel.Warning)
               .AddFilter("Function", LogLevel.Debug);
        logging.SetMinimumLevel(LogLevel.Debug);
    })
    .ConfigureServices((host, services) =>
    {
        IConfiguration configuration = host.Configuration;
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddLogging();
        services.AddSingleton(configuration);
        using var loggerFactory = LoggerFactory.Create(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
        });

        var logger = loggerFactory.CreateLogger<Program>();
        try
        {
            
            
            if (configuration.GetSection("AzureAd") == null)
            {
                logger.LogError("Section AzureAd is not present");
            }
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = Microsoft.Identity.Web.Constants.Bearer;
                sharedOptions.DefaultChallengeScheme = Microsoft.Identity.Web.Constants.Bearer;
            }).AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));


            TokenCredential tokenCredential = new DefaultAzureCredential();

            if (configuration.GetConnectionString("IOT_DB") == null)
            {
                logger.LogError("ConnectioString IOT_DB is not present");
            }
            services.AddDbContext<IoTDBContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("IOT_DB")));

            //Add IOT HUB
            if (configuration["IOTEX_IOTHUB_CONN"] == null)
            {
                logger.LogError("IOTEX_IOTHUB_CONN is not present");
            }
            string connectionString = "" + configuration["IOTEX_IOTHUB_CONN"];
            if (string.IsNullOrEmpty(connectionString))
            {
                string hostIoTHUB = "" + configuration["IOTEX_IOTHUB_HOST"];

                services.AddScoped<ServiceClient>(provider =>
                {
                    TokenCredential tokenCredential = new DefaultAzureCredential();
                    return ServiceClient.Create(hostIoTHUB, tokenCredential);
                });
            }
            else
            {
                services.AddScoped<ServiceClient>(provider =>
                {
                    string connectionString = "" + configuration["IOTEX_IOTHUB_CONN"]; ;
                    return ServiceClient.CreateFromConnectionString(connectionString);
                });
            }
            if (configuration["IOTEX_IOTHUB_HOST"] == null)
            {
                logger.LogError("IOTEX_IOTHUB_HOST is not present");
            }
            ServiceClient serviceClient = ServiceClient.Create(configuration["IOTEX_IOTHUB_HOST"], tokenCredential);

            // Add the KustoService to the dependency injection container
            services.AddScoped<IKustoService>(provider =>
            {
                // Authenticate with the user-assigned managed identity using the Azure.Identity library

                string clusterUri = configuration["KustoCluster_URI"];
                bool RunLocal = configuration.GetValue<bool>("RunLocal");
                KustoService kustoService = null;
                if (RunLocal)
                {
                    //AccessToken token = credential.GetToken(new TokenRequestContext(new[] { clusterUri }));
                    string clientId = configuration["APP_CLIENT_ID"]; // "b1ece2c9-224b-48ca-bad2-cf9c15fac68e";
                    string secretId = configuration["APP_SECRET"]; //Y1N8Q~JYsw6QFX.RBbxnVMaY9Dr0p-gWRyJRBcPe";
                    string tenantId = configuration["APP_TENANT_ID"];//Configuration["AzureAd:TenantId"]
                    kustoService = new KustoService(clusterUri, tenantId, clientId, secretId);
                }
                else
                {

                    string ManagedIdentityClientId = configuration["ManagedIdentityClientId"];
                    kustoService = new KustoService(clusterUri, ManagedIdentityClientId);
                }
                kustoService.CreateTableTelemetry();
                kustoService.CreateTableMessage();
                kustoService.CreateTableDevice();

                return kustoService;

            });
        }
        catch (Exception ex)
        {
            
            logger.LogError(ex, "Error in ConfigureServices" + ex.Message + ex.StackTrace); 
        }
    })
    .Build();

host.Run();
