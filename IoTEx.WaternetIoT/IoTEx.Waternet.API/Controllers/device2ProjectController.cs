
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
    [Route("/api/devices/{deviceId}/projects/")]
    public class device2ProjectController : BaseController
    {
        public device2ProjectController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<Device2ProjectViewModel>>>> GetProjectForDeviceAlls(APIRequestDTO request,
            Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2ProjectViewModel.DefineMapper());
                IQueryable<Device2ProjectModel> instances = _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
                    .Where(o => o.DeviceId == deviceId);

                APIResultDTO<List<Device2ProjectViewModel>> result = new APIResultDTO<List<Device2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2ProjectModel, Device2ProjectViewModel>
                    .DT(request, instances)
                    .Select(o => new Device2ProjectViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<Device2ProjectViewModel>>>> GetProjectForDeviceAllsGrid(APIRequestDTO request,
            Guid deviceId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2ProjectViewModel.DefineMapper());
                IQueryable<Device2ProjectModel> instances = _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
                    .Include(o => o.Device.DeviceTypeFirmware)
                    .Where(o => o.DeviceId == deviceId);

                APIResultDTO<GridResult<Device2ProjectViewModel>> result = new APIResultDTO<GridResult<Device2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2ProjectModel, Device2ProjectViewModel>
                    .DTGrid(request, instances, o => new Device2ProjectViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("/api/projects/{projectId}/devices/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<List<Device2ProjectViewModel>>>> GetDevicesForProjectAlls(APIRequestDTO request,
            Guid projectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2ProjectViewModel.DefineMapper());
                IQueryable<Device2ProjectModel> instances = _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
                    .Include(o => o.Device.DeviceTypeFirmware)
                    .Where(o => o.ProjectId == projectId);

                APIResultDTO<List<Device2ProjectViewModel>> result = new APIResultDTO<List<Device2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2ProjectModel, Device2ProjectViewModel>
                    .DT(request, instances)
                    .Select(o => new Device2ProjectViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("/api/projects/{projectId}/devices/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] {_RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<Device2ProjectViewModel>>>> GetDevicesForProjectAllsGrid(APIRequestDTO request,
            Guid projectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, Device2ProjectViewModel.DefineMapper());
                IQueryable<Device2ProjectModel> instances = _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
                    .Include(o => o.Device.DeviceTypeFirmware)
                    .Where(o => o.ProjectId == projectId);

                APIResultDTO<GridResult<Device2ProjectViewModel>> result = new APIResultDTO<GridResult<Device2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<Device2ProjectModel, Device2ProjectViewModel>
                    .DTGrid(request, instances, o => new Device2ProjectViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }

        //[HttpPost("/api/projects/{projectId}/devices/map")]
        //[RequiredScopeOrAppPermission(
        //            AcceptedScope = new string[] { },
        //            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        //        )]
        //public async JsonResult GetDeviceMap2GroupsForProject(Guid projectId, APIRequestDTO request)
        //{
        //    List<GEOJSON> result = new List<GEOJSON>();
        //    if (IsUserKnown())
        //    {
        //        if (projectId == Guid.Empty && IsAdminUser())
        //        {
        //            ManageMapper(request, Device2ProjectViewModel.DefineMapper());
        //            IQueryable<DeviceModel> Devices = _dBcontext.Devices;
        //            result = APIRequester<DeviceModel>.DT(request, Devices).Select(o => new GEOJSON(o)).ToList();
        //        }
        //        else
        //        {
        //            ManageMapper(request, Device2ProjectViewModel.DefineMapper());
        //            IQueryable<Device2ProjectModel> Device2Groups = _dBcontext.Device2Projects.Include(x => x.Device).Where(o => o.ProjectId == projectId);
        //            result = APIRequester<Device2ProjectModel>.DT(request, Device2Groups).Select(o => new GEOJSON(o.Device)).ToList();
        //        }
        //    }
        //    else
        //    {
        //        //result.error = ERROR_TYPEEnum.AUTHORIZATION_NOT_ALLOWED.ToString();

        //    }
        //    return Json(result);

        //}

        [HttpGet("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<Device2ProjectViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                Device2ProjectModel instance = await _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
                    .FirstAsync(o => o.Id == id);

                if (instance != null)
                {

                    APIResultDTO<Device2ProjectViewModel> result = new APIResultDTO<Device2ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new Device2ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<Device2ProjectViewModel>>> Create(Guid deviceId,
            Device2ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                APIResultDTO<Device2ProjectViewModel> result = new APIResultDTO<Device2ProjectViewModel>();
                if (dtoInstance.DeviceId == deviceId)
                {
                    Device2ProjectModel instance = dtoInstance.Create(GetAppUser());
                    _dBcontext.Device2Projects.Add(instance);
                    _dBcontext.SaveChanges();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Device).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Project).Load();
                    _dBcontext.Entry(instance.Device).Reference(o => o.DeviceBatch).Load();
                    _dBcontext.Entry(instance.Device).Reference(o => o.DeviceTypeFirmware).Load();
                    _dBcontext.Entry(instance.Device.DeviceBatch).Reference(o => o.DeviceType).Load();

                    result.IsOk = true;
                    result.Value = new Device2ProjectViewModel(instance);


                }
                else
                {
                    result.IsOk = false;
                    result.Error = "";
                }
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
        public async Task<ActionResult<APIResultDTO<Device2ProjectViewModel>>> Update(Guid deviceId, Guid id,
            Device2ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                Device2ProjectModel instance = _dBcontext.Device2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Device)
                    .Include(o => o.Project)
                    .Include(o => o.Device.DeviceBatch)
                    .Include(o => o.Device.DeviceBatch.DeviceType)
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
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Device).Load();
                    _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Project).Load();
                    _dBcontext.Entry(instance.Device).Reference(o => o.DeviceBatch).Load();
                    _dBcontext.Entry(instance.Device).Reference(o => o.DeviceBatch.DeviceType).Load();

                    APIResultDTO<Device2ProjectViewModel> result = new APIResultDTO<Device2ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new Device2ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<Device2ProjectViewModel>>> Delete(Guid deviceId, Guid id)
        {
            if (IsUserKnown())
            {
                Device2ProjectModel instance = await _dBcontext.Device2Projects
                    .FirstOrDefaultAsync(o => o.Id == id && o.DeviceId==deviceId );

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Device2Projects.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Device).Load();
                _dBcontext.Entry<Device2ProjectModel>(instance).Reference(o => o.Project).Load();
                _dBcontext.Entry(instance.Device).Reference(o => o.DeviceBatch).Load();
                _dBcontext.Entry(instance.Device).Reference(o => o.DeviceTypeFirmware).Load();
                _dBcontext.Entry(instance.Device.DeviceBatch).Reference(o => o.DeviceType).Load();
                APIResultDTO<Device2ProjectViewModel> result = new APIResultDTO<Device2ProjectViewModel>();
                result.IsOk = true;
                result.Value = new Device2ProjectViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
