
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs;
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
    [Route("/api/deviceTypes/")]
    public class DeviceTypeController : BaseController
    {
        public DeviceTypeController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<DeviceTypeViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeModel> instances = _dBcontext.DeviceTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Supplier);

                APIResultDTO<List<DeviceTypeViewModel>> result = new APIResultDTO<List<DeviceTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeModel, DeviceTypeViewModel>
                    .DT(request, instances)
                    .Select(o => new DeviceTypeViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<DeviceTypeViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, DeviceTypeViewModel.DefineMapper());
                IQueryable<DeviceTypeModel> instances = _dBcontext.DeviceTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Supplier);

                APIResultDTO<GridResult<DeviceTypeViewModel>> result = new APIResultDTO<GridResult<DeviceTypeViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<DeviceTypeModel, DeviceTypeViewModel>
                    .DTGrid(request, instances, o => new DeviceTypeViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<DeviceTypeViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeModel instance = await _dBcontext.DeviceTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Supplier)
                    .FirstAsync(o => o.Id == id);

                if (instance != null)
                {
                    
                    APIResultDTO<DeviceTypeViewModel> result = new APIResultDTO<DeviceTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeViewModel>>> Create(DeviceTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                DeviceTypeModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.DeviceTypes.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.Supplier).Load();

                APIResultDTO<DeviceTypeViewModel> result = new APIResultDTO<DeviceTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeViewModel>>> Update(Guid id, DeviceTypeViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                DeviceTypeModel instance = _dBcontext.DeviceTypes
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Supplier)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }
                
                instance = dtoInstance.Update(instance, GetAppUser());
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<DeviceTypeModel>(instance).Reference(o => o.Supplier).Load();
                    APIResultDTO<DeviceTypeViewModel> result = new APIResultDTO<DeviceTypeViewModel>();
                    result.IsOk = true;
                    result.Value = new DeviceTypeViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<DeviceTypeViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                DeviceTypeModel instance = await _dBcontext.DeviceTypes
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.DeviceTypes.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<DeviceTypeViewModel> result = new APIResultDTO<DeviceTypeViewModel>();
                result.IsOk = true;
                result.Value = new DeviceTypeViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpGet("connectionTypes/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<ValueTextViewModel[]>>> GetConnectionType()
        {
            if (IsUserKnown())
            {

                APIResultDTO<ValueTextViewModel[]> result = new APIResultDTO<ValueTextViewModel[]>();
                result.IsOk = true;
                result.Value = new ValueTextViewModel[] {
                new ValueTextViewModel { Value = (int)NetworkTypeEnum.NOT_DEFINED, Name = NetworkTypeEnum.NOT_DEFINED.ToString() },
                new ValueTextViewModel { Value = (int)NetworkTypeEnum.LORAWAN_KERLINK, Name = NetworkTypeEnum.LORAWAN_KERLINK.ToString() },
                new ValueTextViewModel { Value = (int)NetworkTypeEnum.SIGFOX, Name = NetworkTypeEnum.SIGFOX.ToString() },
                new ValueTextViewModel { Value = (int)NetworkTypeEnum.NBIoT_TMOBILE, Name = NetworkTypeEnum.NBIoT_TMOBILE.ToString() },
                };
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
