using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class ParserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ClassName { get; set; }        
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
        public ParserViewModel()
        {
            
        }
        public ParserViewModel(ParserModel parser)
        {
            
            Id = parser.Id;
            Name = parser.Name;
            Description = parser.Description;
            ClassName = parser.ClassName;
            
            Created = parser.Created;
            Updated = parser.Updated;
            CreatedBy = parser.CreatedBy.Username;
            UpdatedBy = parser.UpdatedBy.Username;
            CreatedById = parser.CreatedById;
            UpdatedById = parser.UpdatedById;
        }
        public ParserModel Create(AppUserModel user)
        {
            ParserModel model = new ParserModel();
            model.Name = Name;
            model.Description = Description;
            model.ClassName = ClassName;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public ParserModel Update(ParserModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.ClassName = ClassName;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
    
}