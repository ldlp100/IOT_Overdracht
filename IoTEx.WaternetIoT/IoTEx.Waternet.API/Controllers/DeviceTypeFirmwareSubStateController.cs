
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/firmwares/{firmwareId}/states/{stateId}/subs/")]
    public class DeviceTypeFirmwareSubStateController : BaseController
    {
        public DeviceTypeFirmwareSubStateController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeEventState2SubStateTypeViewModel>>>> GetAlls(APIRequestDTO request, 
                                    Guid deviceTypeId, Guid firmwareId, Guid stateId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeEventState2SubStateTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeEventState2SubStateTypeModel> instances = _dBcontext.DeviceTypeEventState2SubStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmwareId == firmwareId && 
                            o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmware.DeviceTypeId == deviceTypeId && 
                            o.DeviceTypeEventStateTypeId == stateId);

                APIResultDTO<List<DeviceTypeEventState2SubStateTypeViewModel>> result = new APIResultDTO<List<DeviceTypeEventState2SubStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeEventState2SubStateTypeModel, DeviceTypeEventState2SubStateTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeEventState2SubStateTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeEventState2SubStateTypeViewModel>>>> GetAllsGrid(APIRequestDTO request,
                                        Guid deviceTypeId, Guid firmwareId, Guid stateId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeEventState2SubStateTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeEventState2SubStateTypeModel> instances = _dBcontext.DeviceTypeEventState2SubStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmwareId == firmwareId &&
                            o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmware.DeviceTypeId == deviceTypeId &&
                            o.DeviceTypeEventStateTypeId == stateId);

                APIResultDTO<GridResult<DeviceTypeEventState2SubStateTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeEventState2SubStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeEventState2SubStateTypeModel, DeviceTypeEventState2SubStateTypeViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeEventState2SubStateTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>>> Get(Guid deviceTypeId, 
                            Guid firmwareId, Guid stateId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeEventState2SubStateTypeModel instance = await _dBcontext.DeviceTypeEventState2SubStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmwareId == firmwareId &&
                            o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmware.DeviceTypeId == deviceTypeId &&
                            o.DeviceTypeEventStateTypeId == stateId && o.Id== id).FirstOrDefaultAsync();
                    
                if (instance != null)
                {
                    
                    APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel> result = new APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeEventState2SubStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>>> Create(Guid deviceTypeId,
                            Guid firmwareId, Guid stateId,DeviceTypeEventState2SubStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel> result = new APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>();

                DeviceTypeFirmwareEventStateTypeModel parentInstance = await _dBcontext.DeviceTypeFirmware2EventStateTypes
                   .Include(o => o.CreatedBy)
                   .Include(o => o.UpdatedBy)
                   .Where(o => o.DeviceTypeFirmwareId == firmwareId &&
                           o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId &&
                           o.Id == stateId).FirstOrDefaultAsync();
                
                if (parentInstance == null)
                {
                    result.IsOk = false;
                    result.Error = "PARENT_OBJECT_NOT_FOUND";
                    return result;
                }
                DeviceTypeEventState2SubStateTypeModel instance = dtoInstance.Create(GetAppUser());
                if (instance.DeviceTypeEventStateTypeId != stateId)
                {
                    result.IsOk = false;
                    result.Error = "ID_NOT_MATCHING";
                    return result;
                }
                
                _dBcontext.DeviceTypeEventState2SubStateTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeEventState2SubStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeEventState2SubStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();

                
                result.IsOk = true;
                result.Value = new DeviceTypeEventState2SubStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>>> Update(Guid deviceTypeId,
                            Guid firmwareId, Guid stateId, Guid id, DeviceTypeEventState2SubStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel> result = new APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>();

                DeviceTypeFirmwareEventStateTypeModel parentInstance = await _dBcontext.DeviceTypeFirmware2EventStateTypes
                   .Include(o => o.CreatedBy)
                   .Include(o => o.UpdatedBy)
                   .Where(o => o.DeviceTypeFirmwareId == firmwareId &&
                           o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId &&
                           o.EventStateTypeId == stateId).FirstAsync();
                if (parentInstance == null)
                {
                    result.IsOk = false;
                    result.Error = "OBJECT_NOT_FOUND";
                    return result;
                }

                DeviceTypeEventState2SubStateTypeModel instance = await _dBcontext.DeviceTypeEventState2SubStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmwareId == firmwareId &&
                            o.DeviceTypeFirmwareEventStateType.DeviceTypeFirmware.DeviceTypeId == deviceTypeId &&
                            o.DeviceTypeEventStateTypeId == stateId && o.Id == id).FirstAsync();
                
                instance = dtoInstance.Update(instance, GetAppUser());
                
                if (instance.DeviceTypeEventStateTypeId != stateId)
                {
                    result.IsOk = false;
                    result.Error = "ID_NOT_MATCHING";
                    return result;
                }

                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceTypeEventState2SubStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeEventState2SubStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    
                    result.IsOk = true;
                    result.Value = new DeviceTypeEventState2SubStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeEventState2SubStateTypeModel instance = await _dBcontext.DeviceTypeEventState2SubStateTypes.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypeEventState2SubStateTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel> result = new APIResultDTO<DeviceTypeEventState2SubStateTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeEventState2SubStateTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
