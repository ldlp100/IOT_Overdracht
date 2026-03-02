using Newtonsoft.Json;


namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionProcessCodeDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string stateAlertId { get; set; }
        public string alertName { get; set; }
        public string stateName { get; set; }
        public string measurementId { get; set; }
        public string measurementName { get; set; }
        public string unitTypeId { get; set; }
        public string unitTypeName { get; set; }
        public string unitTypeLabel { get; set; }
        public string infoName { get; set; }
        public string updatedById { get; set; }
        public string updatedByName { get; set; }
    }
}
