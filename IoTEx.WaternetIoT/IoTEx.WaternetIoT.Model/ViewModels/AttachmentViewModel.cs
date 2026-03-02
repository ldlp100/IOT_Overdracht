using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class AttachmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ObjectId { get; set; }
        public AttachmentModel.ObjectTypeEnum ObjectType{ get; set; }
        public AttachmentModel.AttachmentTypeEnum AttachmentType { get; set; }
        public string URL { get; set; }
        public int Size { get; set; }

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

        public AttachmentViewModel()
        {
        }
        public AttachmentViewModel(AttachmentModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            ObjectId = model.ObjectId;
            ObjectType = model.ObjectType;
            AttachmentType = model.AttachmentType;
            URL = model.URL;
            Size = model.Size;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = (model.CreatedBy==null)?null:model.CreatedBy.Username;
            UpdatedBy = (model.UpdatedBy==null)?null: model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public AttachmentModel Create(AppUserModel user)
        {
            AttachmentModel model = new AttachmentModel();
            model.Name = (Name!=null) ?Name.Trim():"";
            model.Description = Description;
            model.ObjectId = ObjectId;
            model.ObjectType = ObjectType;
            model.AttachmentType = AttachmentType;
            model.URL = URL;
            model.Size = Size;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public AttachmentModel Update(AttachmentModel model, AppUserModel user)
        {
            model.Name = (Name != null) ? Name.Trim(): "";
            model.Description = Description;
            model.ObjectId = ObjectId;
            model.ObjectType = ObjectType;
            model.AttachmentType = AttachmentType;
            model.URL = URL;
            model.Size = Size;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}