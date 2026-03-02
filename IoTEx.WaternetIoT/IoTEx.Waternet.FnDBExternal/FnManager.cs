using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.PortalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IoTEx.Waternet.FnDBExternal
{
    public class FnManager
    {
        
        private readonly ILogger? _logger;
        protected readonly OADBContext? _dbContext;
        public readonly IConfiguration? _configuration;
        //private readonly ILogger<Function1> _logger;

        public FnManager(ILoggerFactory loggerFactory, IConfiguration configuration, OADBContext dbContext)
        {

            _configuration = configuration;
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<FnManager>();
        }

        [Function("FnSaveTelemetryToExternDB")]
        public async Task<IActionResult> FnSave([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                if (string.IsNullOrEmpty(requestBody))
                {
                    return new BadRequestObjectResult("Body is Empty");
                }
                OAMessageModel oaObject = JsonConvert.DeserializeObject<OAMessageModel>(requestBody);
                if (_dbContext == null)
                {
                    return new BadRequestObjectResult("DB Context is null");
                }
                if (oaObject == null)
                {
                    return new BadRequestObjectResult("oaObject is null");
                }
                _dbContext.OAMessages.Add(oaObject);
                _dbContext.SaveChanges();

                return new OkObjectResult("OK");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error in SaveMessage");
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
