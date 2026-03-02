import { BaseDTO } from "./baseDTO";

export class DeviceTypeFirmwareAlertDTO extends BaseDTO {
  name: string;
  description?: string;
  deviceTypeFirmwareId: string;
}
