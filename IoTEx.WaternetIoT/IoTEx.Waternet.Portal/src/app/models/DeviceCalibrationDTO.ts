import { BaseDTO } from "./baseDTO";

export class DeviceCalibrationDTO extends BaseDTO {
  deviceId: string;
  deviceTypeFirmware2MeasurementTypeId: string;
  deviceTypeFirmware2MeasurementTypeName?: string;
  minReal?: number;
  maxReal?: number;
  minMeas?: number;
  maxMeas?: number;
  offsetValue?: number;
}
