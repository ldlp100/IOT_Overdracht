import { BaseDTO } from "./baseDTO";

export enum DeviceEventType { MEASUREMENT = 0, STATE = 1, ALERT = 2, INFO = 3 }

export class DocumentTelemetryEventDTO extends BaseDTO {

  type?: DeviceEventType;
  date?: String;
  EDUID?: string;
  name?: string;
  value?: number;
  info?: string;
  unit?: string;
  PC?: string;
  PCValue?: string;
  PCUnit?: string;
}
