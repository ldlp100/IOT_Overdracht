
using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace IoTEx.Waternet.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/projects/")]

    public class ProjectController : BaseController
    {
        public ProjectController(ILogger logger, IoTDBContext context, IConfiguration configuration)
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
        public async Task<ActionResult<APIResultDTO<List<ProjectViewModel>>>> GetAlls(
            APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, ProjectViewModel.DefineMapper());
                IQueryable<ProjectModel> instances = _dBcontext.Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.TargetDB);

                APIResultDTO<List<ProjectViewModel>> result = new APIResultDTO<List<ProjectViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<ProjectModel, ProjectViewModel>
                    .DT(request, instances)
                    .Select(o => new ProjectViewModel(o))
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
        public async Task<ActionResult<APIResultDTO<GridResult<ProjectViewModel>>>> GetAllsGrid(
            APIRequestDTO request)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, ProjectViewModel.DefineMapper());
                IQueryable<ProjectModel> instances = _dBcontext.Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.TargetDB);

                APIResultDTO<GridResult<ProjectViewModel>> result = new APIResultDTO<GridResult<ProjectViewModel>>();
                result.IsOk = true;

                result.Value = APIRequester<ProjectModel, ProjectViewModel>
                    .DTGrid(request, instances, o => new ProjectViewModel(o));

                return result;
            }
            else
                return Unauthorized();
        }

        [HttpGet("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin, _RoleProjectGuest, _RoleProjectReader }
        )]
        public async Task<ActionResult<APIResultDTO<ProjectViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                ProjectModel instance = await _dBcontext.Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.TargetDB)
                    .FirstAsync(o => o.Id == id);

                if (instance != null)
                {

                    APIResultDTO<ProjectViewModel> result = new APIResultDTO<ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new ProjectViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<ProjectViewModel>>> Create(
            ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                ProjectModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.Projects.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.TargetDB).Load();

                APIResultDTO<ProjectViewModel> result = new APIResultDTO<ProjectViewModel>();
                result.IsOk = true;
                result.Value = new ProjectViewModel(instance);
                return result;
            }
            else
                return Unauthorized();
        }

        [HttpPut("{id}")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin,  _RoleProjectAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<ProjectViewModel>>> Update(
            Guid id, ProjectViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                ProjectModel instance = _dBcontext.Projects
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Include(o => o.TargetDB)
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
                    _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.CreatedBy).Load();
                    _dBcontext.Entry<ProjectModel>(instance).Reference(o => o.TargetDB).Load();
                    APIResultDTO<ProjectViewModel> result = new APIResultDTO<ProjectViewModel>();
                    result.IsOk = true;
                    result.Value = new ProjectViewModel(instance);
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
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin, _RoleProjectAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<ProjectViewModel>>> Delete(
            Guid id)
        {
            if (IsUserKnown())
            {
                ProjectModel instance = await _dBcontext.Projects.FirstOrDefaultAsync(o => o.Id == id);
                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Projects.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<ProjectViewModel> result = new APIResultDTO<ProjectViewModel>();
                result.IsOk = true;
                result.Value = new ProjectViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        [HttpPost("{id}/createmap")]
        [RequiredScopeOrAppPermission(
             AcceptedScope = new string[] { },
             AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
         )]
        public async Task<ActionResult<APIResultDTO<bool>>> CreateMap(
             Guid id)
        {
            if (IsUserKnown())
            {
                APIResultDTO<bool> result = new APIResultDTO<bool>();
                result.IsOk = true;
                result.Value = true;
                return result;
            }
            else
                return Unauthorized();
        }
    }
}
