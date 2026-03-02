using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.PortalModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using static IoTEx.WaternetIoT.Model.DTOs.API.APIRequestDTO;
using static IoTEx.WaternetIoT.Model.PortalModels.AppUserModel;

namespace IoTEx.Waternet.API.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// All the Role variables are defined here and can be used everywhere in each controller. 
        /// </summary>
        protected const string _RoleIoTExAdmin = "IoTEx.Admin";
        protected const string _RoleProjectAdmin = "IoTEx.Project.Admin";
        protected const string _RoleProjectReader = "IoTEx.Project.Reader";
        protected const string _RoleProjectGuest = "IoTEx.Project.Guest";

        protected ILogger? _logger = null;
        public IConfiguration? _configuration;
        protected IoTDBContext? _dBcontext;
        
        public BaseController()
        {

        }

        //[NonAction]
        //protected string DBAPIConnectionString()
        //{
        //    if (_configuration.GetConnectionString("IoTEx_DB_API_Connection") == null)
        //    {
        //        _logger.LogError("IoTEx_DB_API_Connection IS NOT DEFINED");
        //    }
        //    return _configuration.GetConnectionString("IoTEx_DB_API_Connection");

        //}
        //[NonAction]
        //protected string DBHistoryConnectionString()
        //{
        //    if (_configuration.GetConnectionString("IoTEx-DB-History-Connection") == null)
        //    {
        //        _logger.LogError("IoTEx-DB-History-Connection IS NOT DEFINED");
        //    }
        //    return _configuration.GetConnectionString("IoTEx-DB-History-Connection");

        //}


        [NonAction]
        protected string GetStorageAttachmentContainer()
        {
            return "iotex-attachments"; //cf-aatachement
        }

        [NonAction]
        protected AppUserModel? GetAppSuperAdmin()
        {

            try
            {


                string username = "";

                System.Security.Claims.Claim? claim = HttpContext.User.Claims.Where(o => o.Type == "preferred_username").FirstOrDefault();
                if (claim != null)
                {
                    username = claim.Value;
                    AppUserModel? user = _dBcontext?.AppUsers.Where(u => u.Username == username).FirstOrDefault();
                    if (user == null)
                    {
                        throw new Exception(HttpStatusCode.Unauthorized.ToString());
                    }
                    return user;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return null;
        }
        /// <summary>
        /// Generic function to retreive the actual user
        /// </summary>
        /// <returns></returns>

        [NonAction]
        protected string? GetUserClaim()
        {
            System.Security.Claims.Claim? claim = HttpContext.User.Claims.Where(o => o.Type == "preferred_username").FirstOrDefault();
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }
        [NonAction]
        protected AppUserModel? GetAppUser()
        {

            try
            {
                string username = "";
                AppUserModel? user = null;

                
                
                //System.Security.Claims.Claim? claim = HttpContext.User.Claims.Where(o => o.Type == ClaimTypes.Upn).FirstOrDefault();
                //if (claim == null)
                //{
                //    claim = HttpContext.User.Claims.Where(o => o.Type == "preferred_username").FirstOrDefault();
                //}
                //if (claim != null)
                //{
                username = HttpContext?.User?.Identity?.Name;// claim.Value;
                user = _dBcontext?.AppUsers.Where(u => u.Username == username).FirstOrDefault();
                if (user != null)
                {
                    return user;
                        
                }
                else
                    throw new Exception(HttpStatusCode.Unauthorized.ToString());
                //}

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return null;
        }

        [NonAction]
        protected bool IsKeyOk(string key)
        {
            return true;
        }

        [NonAction]
        protected bool IsSuperAdminKnown()
        {
            AppUserModel user = GetAppSuperAdmin();

            if (user == null)
                return false;

            return (user.Id != null);
        }
        [NonAction]
        protected bool IsUserKnown()
        {
            AppUserModel user = GetAppUser();

            if (user == null)
                return false;

            return (user.Id != null);
        }
        protected bool MayChangeDeviceData(Guid deviceId)
        {
            AppUserModel user = GetAppUser();
            //if (user.Role == RoleEnum.IoTExAdmin)
            //    return true;
            return true;
        }
        //[NonAction]
        //protected bool IsSubscriptionContributor(Guid subscriptionId)
        //{

        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return true;
        //    return (user == null) ? false : (user.Role == RoleEnum.SubscriptionContributor);

        //}

        //[NonAction]
        //protected bool IsSubscriptionOwner(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.SubscriptionReader);

        //}
        //[NonAction]
        //protected bool IsSiteContributor(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.SubscriptionContributor);

        //}
        //[NonAction]
        //protected bool IsSiteReader(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.SubscriptionReader);

        //}
        //[NonAction]
        //protected bool IsSiteOwner(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.SubscriptionReader);

        //}
        //[NonAction]
        //protected bool IsResellerContributor(Guid subscriptionId)
        //{

        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return true;
        //    return (user == null) ? false : (user.Role == RoleEnum.ResellerContributor);

        //}
        //[NonAction]
        //protected bool IsResellerReader(Guid subscriptionId)
        //{

        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return true;
        //    return (user == null) ? false : (user.Role == RoleEnum.ResellerReader);

        //}
        //[NonAction]
        //protected bool IsResellerOwner(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.ResellerReader);

        //}
        //protected bool IsOrganizationContributor(Guid subscriptionId)
        //{

        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return true;
        //    return (user == null) ? false : (user.Role == RoleEnum.OrganizationContributor);

        //}
        //[NonAction]
        //protected bool IsOrganizationReader(Guid subscriptionId)
        //{

        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return true;
        //    return (user == null) ? false : (user.Role == RoleEnum.OrganizationReader);

        //}
        //[NonAction]
        //protected bool IsOrganizationOwner(Guid subscriptionId)
        //{
        //    return true;
        //    AppUserModel user = GetAppUser(subscriptionId);
        //    return (user == null) ? false : (user.Role == RoleEnum.OrganizationReader);

        //}
        private string GetFieldNameFromMapper(Dictionary<string, string> mapper, string name)
        {
            foreach (string key in mapper.Keys)
            {
                if (key.ToUpper() == name.ToUpper())
                    return mapper[key];
            }
            return name;
        }
        /// <summary>
        /// Transform the Incomming query fom the DTO to the Model Structure
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mapper"></param>
        protected void ManageMapper(APIRequestDTO request, Dictionary<string, string> mapper)
        {
            if (request == null)
                request = new APIRequestDTO();
            if (request.Sorts != null)
            {
                foreach (SortDesc obj in request.Sorts)
                {

                    string member = obj.Member.Substring(0, 1).ToUpper() + obj.Member.Substring(1);

                    if (mapper.ContainsKey(member))
                        obj.Member = mapper[member];
                    if (mapper.ContainsKey(obj.Member))
                        obj.Member = mapper[obj.Member];

                }
            }


            if (request.Filters != null)
            {
                foreach (FilterDesc obj in request.Filters)
                {

                    if (mapper.ContainsKey(obj.Member))
                        obj.Member = mapper[obj.Member];
                    string member = obj.Member.Substring(0, 1).ToUpper() + obj.Member.Substring(1);
                    if (mapper.ContainsKey(member))
                        obj.Member = mapper[member];

                }
            }
        }

    }
}
