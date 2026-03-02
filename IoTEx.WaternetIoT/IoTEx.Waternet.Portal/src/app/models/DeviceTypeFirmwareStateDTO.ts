import { BaseDTO } from "./baseDTO";

export class DeviceTypeFirmwareStateDTO extends BaseDTO {
  name: string;
  description?: string;
  deviceTypeFirmwareId: string;
}
