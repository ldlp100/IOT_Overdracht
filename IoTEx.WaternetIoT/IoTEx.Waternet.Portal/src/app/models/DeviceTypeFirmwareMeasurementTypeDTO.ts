import { BaseDTO } from "./baseDTO";

export class DeviceTypeFirmwareMeasurementTypeDTO extends BaseDTO {
  name: string;
  description?: string;
  unitTypeId: string;
  unitTypeName?: string;
  minMeas?: number;
  maxMeas?: number;
  offsetValue?: number;
  minSensor?: number;
  maxSensor?: number;
  unit?: string;
  isNew: boolean = false;
  measurementTypeId?: string;
  deviceTypeFirmwareId: string;
}
