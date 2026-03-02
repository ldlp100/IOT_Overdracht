using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class ServiceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRunning { get; set; }
        public string StartAutomationUrl { get; set; }
        public string StopAutomationUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            
            return mapper; 
        }
        public ServiceViewModel()
        {
            
        }
        public ServiceViewModel(ServiceModel service)
        {
            
            Id = service.Id;
            Name = service.Name;
            Description = service.Description;
            IsRunning = service.IsRunning;
            StartAutomationUrl = service.StartAutomationUrl;
            StopAutomationUrl = service.StopAutomationUrl;

            Created = service.Created;
            Updated = service.Updated;
            CreatedBy = service.CreatedBy.Username;
            UpdatedBy = service.UpdatedBy.Username;
            CreatedById = service.CreatedById;
            UpdatedById = service.UpdatedById;
        }
        public ServiceModel Create(AppUserModel user)
        {
            ServiceModel model = new ServiceModel();
            model.Name = Name;
            model.Description = Description;
            model.IsRunning = IsRunning;
            model.StartAutomationUrl = StartAutomationUrl;
            model.StopAutomationUrl = StopAutomationUrl;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public ServiceModel Update(ServiceModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.IsRunning= IsRunning;
            model.StartAutomationUrl = StartAutomationUrl;
            model.StopAutomationUrl = StopAutomationUrl;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
    
}