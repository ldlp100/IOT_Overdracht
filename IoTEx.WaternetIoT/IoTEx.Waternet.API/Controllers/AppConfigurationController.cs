
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
    [Route("/api/appConfigurations/")]
    public class AppConfigurationController : BaseController
    {
        public AppConfigurationController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<AppConfigurationViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AppConfigurationViewModel.DefineMapper());
                IQueryable<AppConfigurationModel> instances = _dBcontext.AppConfigurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<AppConfigurationViewModel>> result = new APIResultDTO<List<AppConfigurationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AppConfigurationModel, AppConfigurationViewModel>
                    .DT(request, instances)
                    .Select(o => new AppConfigurationViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<AppConfigurationViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AppConfigurationViewModel.DefineMapper());
                IQueryable<AppConfigurationModel> instances = _dBcontext.AppConfigurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<AppConfigurationViewModel>> result = new APIResultDTO<GridResult<AppConfigurationViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AppConfigurationModel, AppConfigurationViewModel>
                    .DTGrid(request, instances, o => new AppConfigurationViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<AppConfigurationViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                AppConfigurationModel instance = await _dBcontext.AppConfigurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {
                    
                    APIResultDTO<AppConfigurationViewModel> result = new APIResultDTO<AppConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new AppConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppConfigurationViewModel>>> Create(AppConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                AppConfigurationModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.AppConfigurations.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<AppConfigurationModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<AppConfigurationModel>(instance).Reference(o => o.CreatedBy).Load();
                
                APIResultDTO<AppConfigurationViewModel> result = new APIResultDTO<AppConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new AppConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppConfigurationViewModel>>> Update(Guid id, AppConfigurationViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                AppConfigurationModel instance = _dBcontext.AppConfigurations
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
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
                    APIResultDTO<AppConfigurationViewModel> result = new APIResultDTO<AppConfigurationViewModel>();
                    result.IsOk = true;
                    result.Value = new AppConfigurationViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppConfigurationViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                AppConfigurationModel instance = await _dBcontext.AppConfigurations.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.AppConfigurations.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<AppConfigurationViewModel> result = new APIResultDTO<AppConfigurationViewModel>();
                result.IsOk = true;
                result.Value = new AppConfigurationViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }
}
