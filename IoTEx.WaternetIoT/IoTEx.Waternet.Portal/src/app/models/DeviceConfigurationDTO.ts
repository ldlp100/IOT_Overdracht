import { BaseDTO } from "./baseDTO";

export class DeviceConfigurationDTO extends BaseDTO {
  deviceTypeFirmwareConfigurationId: string;
  deviceTypeFirmwareConfigurationName?: string;
  deviceId: string;
  value?: string;
}
