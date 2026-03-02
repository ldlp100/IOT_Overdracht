import { BaseDTO } from "./baseDTO";

export class DeviceTypeFirmwareDTO extends BaseDTO {
  name: string;
  description?: string;
  isUsed: boolean = false;
  parserId: string;
  parserName?: string;
  deviceTypeId: string;
  isConfigurable: boolean = false;
}
