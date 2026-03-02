import { DeviceInfoDTO, DeviceLocationDTO, DeviceNetworkInformationDTO, DeviceProjectDTO, DeviceDefinitionSettingsDTO } from "./_index";

export class DeviceDefinitionDTO {
  id?: string;
  deviceId?: string;
  deviceName?: string;
  assetUID?: string;
  isTraced?: boolean = false;
  isActive?: boolean = false;
  info?: DeviceInfoDTO;
  location?: DeviceLocationDTO;
  network?: DeviceNetworkInformationDTO;
  projects?: DeviceProjectDTO[];
  publishedDate?: Date;
  installedDate?: Date;
  publishedCounter?: number = 0;
  publishedByUserId?: string;
  publishedByUsername?: string;
  settings?: DeviceDefinitionSettingsDTO;
}
