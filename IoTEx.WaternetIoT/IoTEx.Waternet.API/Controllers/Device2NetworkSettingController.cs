
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
    [Route("/api/devices/{deviceId}/networkSettings/")] 

    public class Device2NetworkSettingController : BaseController
    {
        public Device2NetworkSettingController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<Device2SNetworkAPISettingViewModel>>>> GetAlls(APIRequestDTO request,
            Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2SNetworkAPISettingViewModel.DefineMapper());
                IQueryable<Device2SNetworkAPISettingModel> instances = _dBcontext.Device2SNetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    //.Include(o => o.)
                    .Where(o => o.DeviceId == deviceId);

                APIResultDTO<List<Device2SNetworkAPISettingViewModel>> result = new APIResultDTO<List<Device2SNetworkAPISettingViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2SNetworkAPISettingModel, Device2SNetworkAPISettingViewModel>
                    .DT(request, instances)
                    .Select(o => new Device2SNetworkAPISettingViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<Device2SNetworkAPISettingViewModel>>>> GetAllsGrid(APIRequestDTO request,
            Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2SNetworkAPISettingViewModel.DefineMapper());
                IQueryable<Device2SNetworkAPISettingModel> instances = _dBcontext.Device2SNetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Where(o => o.DeviceId == deviceId);

                APIResultDTO<GridResult<Device2SNetworkAPISettingViewModel>> result = new APIResultDTO<GridResult<Device2SNetworkAPISettingViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2SNetworkAPISettingModel, Device2SNetworkAPISettingViewModel>
                    .DTGrid(request, instances, o => new Device2SNetworkAPISettingViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>>> Get(Guid id, Guid deviceId)
        {
            if (IsUserKnown())
            {
                Device2SNetworkAPISettingModel instance = await _dBcontext.Device2SNetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .FirstAsync(o => o.Id == id && o.DeviceId == deviceId);

                if (instance != null)
                {

                    APIResultDTO<Device2SNetworkAPISettingViewModel> result = new APIResultDTO<Device2SNetworkAPISettingViewModel>();
                    result.IsOk = true;
                    result.Value = new Device2SNetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>>> Create(Guid deviceId,
            Device2SNetworkAPISettingViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                Device2SNetworkAPISettingModel instance = dtoInstance.Create(GetAppUser());
                instance.DeviceId = deviceId;

                _dBcontext.Device2SNetworkAPISettings.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.Device).Load();

                APIResultDTO<Device2SNetworkAPISettingViewModel> result = new APIResultDTO<Device2SNetworkAPISettingViewModel>();
                result.IsOk = true;
                result.Value = new Device2SNetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>>> Update(Guid deviceId, Guid id,
            Device2SNetworkAPISettingViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                Device2SNetworkAPISettingModel instance = _dBcontext.Device2SNetworkAPISettings
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.DeviceId = deviceId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<Device2SNetworkAPISettingModel>(instance).Reference(o => o.Device).Load();
                    APIResultDTO<Device2SNetworkAPISettingViewModel> result = new APIResultDTO<Device2SNetworkAPISettingViewModel>();
                    result.IsOk = true;
                    result.Value = new Device2SNetworkAPISettingViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<Device2SNetworkAPISettingViewModel>>> Delete(Guid deviceId, Guid id)
        {
            if (IsUserKnown())
            {
                Device2SNetworkAPISettingModel instance = await _dBcontext.Device2SNetworkAPISettings
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceId == deviceId);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Device2SNetworkAPISettings.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<Device2SNetworkAPISettingViewModel> result = new APIResultDTO<Device2SNetworkAPISettingViewModel>();
                result.IsOk = true;
                result.Value = new Device2SNetworkAPISettingViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
