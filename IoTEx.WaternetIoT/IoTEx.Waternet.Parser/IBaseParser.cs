using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{
    public interface IBaseParser
    {
        string Version { get; }
        string Name { get; }
        DeviceDefinitionSettingsDTO GetDeviceMetaDataDefinition();        
        /// <summary>
        /// Create a String message containing the configuration that can be sent to the device.
        /// </summary>
        /// <param name="configs"></param>
        /// <returns></returns>
        APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="payload"></param>
        /// <param name="enc"></param>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo);
    }
    
}
