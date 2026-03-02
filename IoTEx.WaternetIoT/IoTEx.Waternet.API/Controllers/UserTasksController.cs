
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
    [Route("/api/userTasks/")]
    public class UserTaskController : BaseController
    {
        public UserTaskController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<UserTaskViewModel>>>> GetAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, UserTaskViewModel.DefineMapper());
                IQueryable<UserTaskModel> instances = _dBcontext.UserTasks
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);

                APIResultDTO<List<UserTaskViewModel>> result = new APIResultDTO<List<UserTaskViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<UserTaskModel, UserTaskViewModel>
                    .DT(request, instances)
                    .Select(o => new UserTaskViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<UserTaskViewModel>>>> GetAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, UserTaskViewModel.DefineMapper());
                IQueryable<UserTaskModel> instances = _dBcontext.UserTasks
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy);
                APIResultDTO<GridResult<UserTaskViewModel>> result = new APIResultDTO<GridResult<UserTaskViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<UserTaskModel, UserTaskViewModel>
                    .DTGrid(request, instances, o => new UserTaskViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<UserTaskViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                UserTaskModel instance = await _dBcontext.UserTasks
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);
                if (instance != null)
                {

                    APIResultDTO<UserTaskViewModel> result = new APIResultDTO<UserTaskViewModel>();
                    result.IsOk = true;
                    result.Value = new UserTaskViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UserTaskViewModel>>> Create(UserTaskViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                UserTaskModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.UserTasks.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<UserTaskModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<UserTaskModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<UserTaskViewModel> result = new APIResultDTO<UserTaskViewModel>();
                result.IsOk = true;
                result.Value = new UserTaskViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UserTaskViewModel>>> Update(Guid id, UserTaskViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                UserTaskModel instance = _dBcontext.UserTasks
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
                    _dBcontext.Entry<UserTaskModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<UserTaskModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<UserTaskViewModel> result = new APIResultDTO<UserTaskViewModel>();
                    result.IsOk = true;
                    result.Value = new UserTaskViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<UserTaskViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                UserTaskModel instance = await _dBcontext.UserTasks.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.UserTasks.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<UserTaskViewModel> result = new APIResultDTO<UserTaskViewModel>();
                result.IsOk = true;
                result.Value = new UserTaskViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("myUserTasks/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<UserTaskViewModel>>>> GetMyUserTasksAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                Guid userId = GetAppUser().Id;

                ManageMapper(request, UserTaskViewModel.DefineMapper());
                int count = _dBcontext.UserTasks.Count();
                IQueryable<UserTaskModel> instances = _dBcontext.UserTasks
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.User)
                    .Where(u => u.UserId == userId);
                APIResultDTO<List<UserTaskViewModel>> result = new APIResultDTO<List<UserTaskViewModel>>();

            

                result.IsOk = true;
                result.Value = APIRequester<UserTaskModel, UserTaskViewModel>
                    .DT(request, instances)
                    .Select(o => new UserTaskViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("myUserTasks/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<UserTaskViewModel>>>> GetMyUserTasksAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                Guid userId = GetAppUser().Id;

                ManageMapper(request, UserTaskViewModel.DefineMapper());
                IQueryable<UserTaskModel> instances = _dBcontext.UserTasks
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.User)
                    .Where(u => u.UserId == userId); 
                APIResultDTO<GridResult<UserTaskViewModel>> result = new APIResultDTO<GridResult<UserTaskViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<UserTaskModel, UserTaskViewModel>
                    .DTGrid(request, instances, o => new UserTaskViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }
    }


}
