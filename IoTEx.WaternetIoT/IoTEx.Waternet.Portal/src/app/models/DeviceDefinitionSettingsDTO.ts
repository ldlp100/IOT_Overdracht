import { DeviceDefinitionAlertDTO, DeviceDefinitionConfigurationDTO, DeviceDefinitionInfoDTO, 
  DeviceDefinitionMeasurementDTO, DeviceDefinitionStateDTO, DeviceDefinitionProcessCodeDTO } from "./_index";

export class DeviceDefinitionSettingsDTO {
  version?: string;
  info?: DeviceDefinitionInfoDTO[];
  measurements?: DeviceDefinitionMeasurementDTO[];
  states?: DeviceDefinitionStateDTO[];
  alerts?: DeviceDefinitionAlertDTO[];
  configurations?: DeviceDefinitionConfigurationDTO[];
  processCodes?: DeviceDefinitionProcessCodeDTO[];

}
