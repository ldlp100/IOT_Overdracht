import { BaseDTO } from "./baseDTO";

export class DeviceTypeFirmwareSubStateDTO extends BaseDTO {
  name: string;
  value: string;
  description?: string;
  deviceTypeEventStateTypeId: string;
}
