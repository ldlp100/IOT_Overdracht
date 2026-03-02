
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
    [Route("/api/attachments/")]
    public class AttachmentController : BaseController
    {
        public AttachmentController(ILogger logger, IoTDBContext context, IConfiguration configuration)
        {

            _dBcontext = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("type/{objectType}/objectId/{objectId}/all")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<List<AttachmentViewModel>>>> GetAlls(APIRequestDTO request, AttachmentModel.ObjectTypeEnum objectType, Guid objectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AttachmentViewModel.DefineMapper());
                IQueryable<AttachmentModel> instances = _dBcontext.Attachments
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.ObjectId == objectId && o.ObjectType == objectType);

                APIResultDTO<List<AttachmentViewModel>> result = new APIResultDTO<List<AttachmentViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AttachmentModel, AttachmentViewModel>
                    .DT(request, instances)
                    .Select(o => new AttachmentViewModel(o))
                    .ToList();

                return result;
            }
            else
                return Unauthorized();
        }
        
        [HttpPost("type/{objectType}/objectId/{objectId}/all/grid")]
        [RequiredScopeOrAppPermission(
            AcceptedScope = new string[] { },
            AcceptedAppPermission = new string[] { _RoleIoTExAdmin }
        )]
        public async Task<ActionResult<APIResultDTO<GridResult<AttachmentViewModel>>>> GetAllsGrid(APIRequestDTO request, AttachmentModel.ObjectTypeEnum objectType, Guid objectId)
        {

            if (IsUserKnown())
            {
                ManageMapper(request, AttachmentViewModel.DefineMapper());
                IQueryable<AttachmentModel> instances = _dBcontext.Attachments
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .Where(o => o.ObjectId == objectId && o.ObjectType == objectType);

                APIResultDTO<GridResult<AttachmentViewModel>> result = new APIResultDTO<GridResult<AttachmentViewModel>>();
                result.IsOk = true;
                result.Value = APIRequester<AttachmentModel, AttachmentViewModel>
                    .DTGrid(request, instances, o => new AttachmentViewModel(o));

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
        public async Task<ActionResult<APIResultDTO<AttachmentViewModel>>> Get(Guid id)
        {
            if (IsUserKnown())
            {
                AttachmentModel instance = await _dBcontext.Attachments
                    .Include(o => o.CreatedBy)
                    .Include(o => o.UpdatedBy)
                    .FirstAsync(o => o.Id == id);

                if (instance != null)
                {

                    APIResultDTO<AttachmentViewModel> result = new APIResultDTO<AttachmentViewModel>();
                    result.IsOk = true;
                    result.Value = new AttachmentViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AttachmentViewModel>>> Create(AttachmentViewModel dtoInstance)
        {
            if (IsUserKnown())
            {

                AttachmentModel instance = dtoInstance.Create(GetAppUser());

                _dBcontext.Attachments.Add(instance);
                _dBcontext.SaveChanges();
                _dBcontext.Entry<AttachmentModel>(instance).Reference(o => o.UpdatedBy).Load();
                _dBcontext.Entry<AttachmentModel>(instance).Reference(o => o.CreatedBy).Load();

                APIResultDTO<AttachmentViewModel> result = new APIResultDTO<AttachmentViewModel>();
                result.IsOk = true;
                result.Value = new AttachmentViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AttachmentViewModel>>> Update(Guid id, AttachmentViewModel dtoInstance)
        {
            if (IsUserKnown())
            {
                if (id != dtoInstance.Id)
                {
                    return BadRequest();
                }

                AttachmentModel instance = _dBcontext.Attachments
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
                    _dBcontext.Entry<AttachmentModel>(instance).Reference(o => o.UpdatedBy).Load();
                    _dBcontext.Entry<AttachmentModel>(instance).Reference(o => o.CreatedBy).Load();
                    APIResultDTO<AttachmentViewModel> result = new APIResultDTO<AttachmentViewModel>();
                    result.IsOk = true;
                    result.Value = new AttachmentViewModel(instance);
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
        public async Task<ActionResult<APIResultDTO<AttachmentViewModel>>> Delete(Guid id)
        {
            if (IsUserKnown())
            {
                AttachmentModel instance = await _dBcontext.Attachments
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (instance == null)
                {
                    return NotFound();
                }

                _dBcontext.Attachments.Remove(instance);
                await _dBcontext.SaveChangesAsync();
                APIResultDTO<AttachmentViewModel> result = new APIResultDTO<AttachmentViewModel>();
                result.IsOk = true;
                result.Value = new AttachmentViewModel(instance);
                return result;

            }
            else
                return Unauthorized();
        }

        

    }
}
