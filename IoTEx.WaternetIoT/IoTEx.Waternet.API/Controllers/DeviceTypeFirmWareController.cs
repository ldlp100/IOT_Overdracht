
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/firmwares/")]

    public class DeviceTypeFirmwareController : BaseController
    {
        public DeviceTypeFirmwareController(ILogger logger, IoTDBContext context, IConfiguration configuration)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareViewModel>>>> GetAlls(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareModel> instances = _dBcontext.DeviceTypeFirmwares
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Parser)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<List<DeviceTypeFirmwareViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareModel, DeviceTypeFirmwareViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeFirmwareViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareViewModel>>>> GetAllsGrid(APIRequestDTO request, 
            Guid deviceTypeId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareModel> instances = _dBcontext.DeviceTypeFirmwares
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Parser)
                    .Where(o => o.DeviceTypeId == deviceTypeId);

                APIResultDTO<GridResult<DeviceTypeFirmwareViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareModel, DeviceTypeFirmwareViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeFirmwareViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpGet("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>>> Get(Guid id, Guid deviceTypeId)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareModel instance = await _dBcontext.DeviceTypeFirmwares
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Parser)
                    .FirstAsync(o => o.Id == id && o.DeviceTypeId == deviceTypeId);

                if (instance != null)
                {

                    APIResultDTO<DeviceTypeFirmwareViewModel> result = new APIResultDTO<DeviceTypeFirmwareViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareViewModel(instance);
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return Unauthorized();
        }

        [HttpPost]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>>> Create(Guid deviceTypeId, 
            DeviceTypeFirmwareViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceTypeFirmwareModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeId = deviceTypeId;

                _dBcontext.DeviceTypeFirmwares.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.Parser).Load();

                APIResultDTO<DeviceTypeFirmwareViewModel> result = new APIResultDTO<DeviceTypeFirmwareViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareViewModel(instance);
                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPut("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>>> Update(Guid deviceTypeId, Guid id, 
            DeviceTypeFirmwareViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceTypeFirmwareModel instance = _dBcontext.DeviceTypeFirmwares
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Parser)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceTypeId = deviceTypeId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareModel>(instance).Reference(o => o.Parser).Load();
                    APIResultDTO<DeviceTypeFirmwareViewModel> result = new APIResultDTO<DeviceTypeFirmwareViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareViewModel(instance);
                    return result;
                }
                catch
                {
                    throw;
                }
            }
            else
                return Unauthorized();

        }

        [HttpDelete("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareViewModel>>> Delete(Guid deviceTypeId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareModel instance = await _dBcontext.DeviceTypeFirmwares
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeId == deviceTypeId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypeFirmwares.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeFirmwareViewModel> result = new APIResultDTO<DeviceTypeFirmwareViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("{id}/getMetadata")]
        [RequiredScopeOrAppPermission(
             AcceptedScope = new string[] { },
             AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
         )]
        public async Task<ActionResult<APIResultDTO<string>>> GetMetadata(Guid deviceTypeId, Guid id)
        {
            if (IsUserKnown())
            {
                APIResultDTO<string> result = new APIResultDTO<string>();
                DeviceTypeFirmwareModel deviceTypeFirmware = _dBcontext.DeviceTypeFirmwares.FirstOrDefault(o => o.Id == id);
                if (deviceTypeFirmware != null)
                {
                    //look for PARSER ClassName
                    ParserModel parser = _dBcontext.Parsers.FirstOrDefault(o => o.Id == deviceTypeFirmware.ParserId);
                    if (parser != null)
                    {
                        if (!string.IsNullOrEmpty(parser.ClassName))
                        {
                            AppConfigurationModel appConfigurationModel = _dBcontext.AppConfigurations.FirstOrDefault(o => o.Name == "FUNCTION_PARSER_GET_METATA_API_URL");
                            if (appConfigurationModel!=null)
                            {
                                string URL = appConfigurationModel.Value;
                                string FUNCTION_PARSER_GET_METATA_API_URL = URL + "&" + parser.ClassName;
                                
                            }
                        }

                    }
                    result.IsOk = false;
                    result.Error = "PARSER_NOT_FOUND";
                    return result;
                }            
                result.IsOk = false;
                result.Error = "FIRMWARE_TYPE_NOT_FOUND";
                return result;


                
                


                    
                    
                    

            }
            else
                return Unauthorized();
        }
    }


}
