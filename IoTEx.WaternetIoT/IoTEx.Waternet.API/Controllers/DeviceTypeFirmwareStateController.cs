
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/deviceTypes/{deviceTypeId}/firmwares/{firmwareId}/states/")]
    public class DeviceTypeFirmwareStateController : BaseController
    {
        public DeviceTypeFirmwareStateController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>>> GetAlls(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareEventStateTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareEventStateTypeModel> instances = _dBcontext.DeviceTypeFirmware2EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId && o.IsAlert == false);

                APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>> result = new APIResultDTO<List<DeviceTypeFirmwareEventStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareEventStateTypeModel, DeviceTypeFirmwareEventStateTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeFirmwareEventStateTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>>> GetAllsGrid(
            APIRequestDTO request, Guid deviceTypeId, Guid firmwareId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeFirmwareEventStateTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeFirmwareEventStateTypeModel> instances = _dBcontext.DeviceTypeFirmware2EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .Where(o => o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId && o.IsAlert == false);

                APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeFirmwareEventStateTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeFirmwareEventStateTypeModel, DeviceTypeFirmwareEventStateTypeViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeFirmwareEventStateTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>>> Get(Guid id, Guid deviceTypeId,
            Guid firmwareId)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareEventStateTypeModel instance = await _dBcontext.DeviceTypeFirmware2EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId && o.IsAlert == false);

                if (instance != null)
                {

                    APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareEventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>>> Create(Guid deviceTypeId,
            Guid firmwareId, DeviceTypeFirmwareEventStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceTypeFirmwareEventStateTypeModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceTypeFirmwareId = firmwareId;
                instance.IsAlert = false;

                _dBcontext.DeviceTypeFirmware2EventStateTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();

                APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareEventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>>> Update(Guid deviceTypeId,
            Guid firmwareId, Guid id, DeviceTypeFirmwareEventStateTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceTypeFirmwareEventStateTypeModel instance = _dBcontext.DeviceTypeFirmware2EventStateTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.DeviceTypeFirmware)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceTypeFirmwareId = firmwareId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceTypeFirmwareEventStateTypeModel>(instance).Reference(o => o.DeviceTypeFirmware).Load();
                    APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeFirmwareEventStateTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>>> Delete(Guid deviceTypeId,
            Guid firmwareId, Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeFirmwareEventStateTypeModel instance = await _dBcontext.DeviceTypeFirmware2EventStateTypes
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceTypeFirmwareId == firmwareId && o.DeviceTypeFirmware.DeviceTypeId == deviceTypeId && o.IsAlert == false);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypeFirmware2EventStateTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel> result = new APIResultDTO<DeviceTypeFirmwareEventStateTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeFirmwareEventStateTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
