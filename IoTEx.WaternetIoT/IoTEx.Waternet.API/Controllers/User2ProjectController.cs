
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
    [Route("/api/projects/{projectId}/users/")]

    public class User2ProjectController : BaseController
    {
        public User2ProjectController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<User2ProjectViewModel>>>> GetAlls(APIRequestDTO request,
            Guid projectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, User2ProjectViewModel.DefineMapper());
                IQueryable<User2ProjectModel> instances = _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .Where(o => o.ProjectId == projectId);

                APIResultDTO<List<User2ProjectViewModel>> result = new APIResultDTO<List<User2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<User2ProjectModel, User2ProjectViewModel>
                    .DT(request, instances)
                    .Select(o => new User2ProjectViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<User2ProjectViewModel>>>> GetAllsGrid(APIRequestDTO request,
            Guid projectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, User2ProjectViewModel.DefineMapper());
                IQueryable<User2ProjectModel> instances = _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .Where(o => o.ProjectId == projectId);

                APIResultDTO<GridResult<User2ProjectViewModel>> result = new APIResultDTO<GridResult<User2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<User2ProjectModel, User2ProjectViewModel>
                    .DTGrid(request, instances, o => new User2ProjectViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<User2ProjectViewModel>>> Get(Guid id, Guid projectId)
        {
            if (IsUserKnown())
            {
                User2ProjectModel instance = await _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .FirstAsync(o => o.Id == id && o.ProjectId == projectId);

                if (instance != null)
                {

                    APIResultDTO<User2ProjectViewModel> result = new APIResultDTO<User2ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new User2ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<User2ProjectViewModel>>> Create(Guid projectId,
            User2ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                User2ProjectModel instance = dtoInstance.Create(GetAppUser());
                instance.ProjectId = projectId;

                _dBcontext.User2Projects.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.Project).Load();
                _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.User).Load();

                APIResultDTO<User2ProjectViewModel> result = new APIResultDTO<User2ProjectViewModel>();
                result.IsOk = true;
                result.Value = new User2ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<User2ProjectViewModel>>> Update(Guid projectId, Guid id,
            User2ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                User2ProjectModel instance = _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .FirstOrDefault(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                instance = dtoInstance.Update(instance, GetAppUser());
                instance.ProjectId = projectId;
                _dBcontext.Entry(instance).State = EntityState.Modified;

                try
                {
                    await _dBcontext.SaveChangesAsync();
                    _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.Project).Load();
                    _dBcontext.Entry<User2ProjectModel>(instance).Reference(o => o.User).Load();
                    APIResultDTO<User2ProjectViewModel> result = new APIResultDTO<User2ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new User2ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<User2ProjectViewModel>>> Delete(Guid projectId, Guid id)
        {
            if (IsUserKnown())
            {
                User2ProjectModel instance = await _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == id && o.ProjectId == projectId);
                    
                if (instance == null)
                {
                    return NotFound();
                }
                
                _dBcontext.User2Projects.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<User2ProjectViewModel> result = new APIResultDTO<User2ProjectViewModel>();
                result.IsOk = true;
                result.Value = new User2ProjectViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("/api/users/myProjects/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<List<User2ProjectViewModel>>>> GetMyProjectAlls(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                Guid UserId = GetAppUser().Id;
                ManageMapper(request, User2ProjectViewModel.DefineMapper());
                IQueryable<User2ProjectModel> instances = _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .Where(o => o.UserId == UserId);

                APIResultDTO<List<User2ProjectViewModel>> result = new APIResultDTO<List<User2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<User2ProjectModel, User2ProjectViewModel>
                    .DT(request, instances)
                    .Select(o => new User2ProjectViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPost("/api/users/myProjects/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<User2ProjectViewModel>>>> GetMyProjectAllsGrid(APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                Guid UserId = GetAppUser().Id;
                ManageMapper(request, User2ProjectViewModel.DefineMapper());
                IQueryable<User2ProjectModel> instances = _dBcontext.User2Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.Project)
                    .Include(o => o.User)
                    .Where(o => o.UserId == UserId);

                APIResultDTO<GridResult<User2ProjectViewModel>> result = new APIResultDTO<GridResult<User2ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<User2ProjectModel, User2ProjectViewModel>
                    .DTGrid(request, instances, o => new User2ProjectViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }
    }
}
