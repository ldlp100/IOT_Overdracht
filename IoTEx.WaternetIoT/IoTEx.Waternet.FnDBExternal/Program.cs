using Azure.Core;
using Azure.Identity;
using IoTEx.WaternetIoT.DAL;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((host,services) =>
    {
        IConfiguration configuration = host.Configuration;

        services.AddAuthentication(sharedOptions =>
        {
            sharedOptions.DefaultScheme = Microsoft.Identity.Web.Constants.Bearer;
            sharedOptions.DefaultChallengeScheme = Microsoft.Identity.Web.Constants.Bearer;
        }).AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));


        TokenCredential tokenCredential = new DefaultAzureCredential();

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddLogging();
        services.AddSingleton(configuration);
        services.AddDbContext<OADBContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("IOTEX_EXTERNAL_DB")));
    })
    .Build();

host.Run();
