using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.DAL
{
    public class DbInitializer
    {
        public static void Initialize(IoTDBContext context)
        {
            context.AppUsers.Add(new AppUserModel() { Role = AppUserModel.RoleEnum.Admin, Username = "laurent.lenne@iotexcellence.com" });

            AppUserModel user = context.AppUsers.FirstOrDefault(u => u.Username == "laurent.lenne@iotexcellence.com");
            if (user != null)
            {
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "DEFAULT_ALTITUDE") == null)
                {
                    context.AppConfigurations.Add(new AppConfigurationModel()
                    {
                        Name = "DEFAULT_ALTITUDE",
                        Description = "Define the default altitude for all new devices",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = "0"
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "DEFAULT_LATITUDE") == null)
                {
                    context.AppConfigurations.Add(new AppConfigurationModel()
                    {
                        Name = "DEFAULT_LATITUDE",
                        Description = "Define the default latitude for all new devices",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = "52.3397522"
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "DEFAULT_LONGITUDE") == null)
                {
                    context.AppConfigurations.Add(new AppConfigurationModel()
                    {
                        Name = "DEFAULT_LONGITUDE",
                        Description = "Define the default latitude for all new devices",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = "4.9149827"
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "FUNCTION_PARSER_GETCONFIG_API_URL") == null)
                {
                    context.AppConfigurations.Add(new AppConfigurationModel()
                    {
                        Name = "FUNCTION_PARSER_GETCONFIG_API_URL",
                        Description = "Define the PARSER API URL to get device configuration",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = ""
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "FUNCTION_PARSER_MAKECONFIGSTRING_API_URL") == null)
                {
                    context.AppConfigurations.Add( new AppConfigurationModel()
                    {
                        Name = "FUNCTION_PARSER_MAKECONFIGSTRING_API_URL",
                        Description = "Define the PARSER API URL to get create device configuration message",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = ""
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "COSMOSDB_END_POINT") == null)
                {
                    context.AppConfigurations.Add( new AppConfigurationModel()
                    {
                        Name = "COSMOSDB_END_POINT",
                        Description = "Define the COSMOSDB_END_POINT URL point",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = ""
                    });
                }
                if (context.AppConfigurations.FirstOrDefault(r => r.Name == "COSMOSDB_AUTH_KEY") == null)
                {
                    context.AppConfigurations.Add( new AppConfigurationModel()
                    {
                        Name = "COSMOSDB_AUTH_KEY",
                        Description = "Define the unique access key to the cosmos DB",
                        Created = DateTime.Now.ToUniversalTime(),
                        Updated = DateTime.Now.ToUniversalTime(),
                        CreatedById = user.Id,
                        UpdatedById = user.Id,
                        IsDeletable = false,
                        IsModifiable = true,
                        Value = ""
                    });
                }

            }

        }
    }
    
}
