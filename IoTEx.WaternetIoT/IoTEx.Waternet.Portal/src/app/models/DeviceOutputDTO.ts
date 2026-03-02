import { BaseDTO } from "./baseDTO";

export class DeviceOutputDTO extends BaseDTO {
  deviceId: string;
  eventStateTypeId?: string;
  eventStateTypeName?: string;
  eventStateTypeIsAlert?: boolean = false;
  measurementTypeId?: string;
  measurementTypeName?: string;
  unitTypeId?: string;
  unitTypeName?: string;
  pc: string;
}
