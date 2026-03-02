
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
    [Route("/api/users/")]
    public class UserController : BaseController
    {
        public UserController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<AppUserViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AppUserViewModel.DefineMapper());
                IQueryable<AppUserModel> instances = _dBcontext.AppUsers;

                APIResultDTO<List<AppUserViewModel>> result = new APIResultDTO<List<AppUserViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AppUserModel, AppUserViewModel>
                    .DT(request, instances)
                    .Select(o => new AppUserViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<AppUserViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AppUserViewModel.DefineMapper());
                IQueryable<AppUserModel> instances = _dBcontext.AppUsers;

                APIResultDTO<GridResult<AppUserViewModel>> result = new APIResultDTO<GridResult<AppUserViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AppUserModel, AppUserViewModel>
                    .DTGrid(request, instances, o => new AppUserViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<AppUserViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                AppUserModel instance = await _dBcontext.AppUsers
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {

                    APIResultDTO<AppUserViewModel> result = new APIResultDTO<AppUserViewModel>();
                    result.IsOk = true;
                    result.Value = new AppUserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppUserViewModel>>> Create(AppUserViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                AppUserModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.AppUsers.Add(instance);
                _dBcontext.SaveChanges();

                APIResultDTO<AppUserViewModel> result = new APIResultDTO<AppUserViewModel>();
                result.IsOk = true;
                result.Value = new AppUserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppUserViewModel>>> Update(Guid id, AppUserViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                AppUserModel instance = _dBcontext.AppUsers
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
                    APIResultDTO<AppUserViewModel> result = new APIResultDTO<AppUserViewModel>();
                    result.IsOk = true;
                    result.Value = new AppUserViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AppUserViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                AppUserModel instance = await _dBcontext.AppUsers.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.AppUsers.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<AppUserViewModel> result = new APIResultDTO<AppUserViewModel>();
                result.IsOk = true;
                result.Value = new AppUserViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }
    }


}
