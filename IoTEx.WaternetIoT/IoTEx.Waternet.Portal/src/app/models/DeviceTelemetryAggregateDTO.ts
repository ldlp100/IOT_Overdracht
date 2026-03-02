import { BaseDTO } from "./baseDTO";



export class DeviceTelemetryAggregateDTO extends BaseDTO {

  name?: string;
  windowIdx?: number;
  windowDT?: Date;
  min?: number;
  max?: number;
  count?: number;
  stdDev?: number;
  avg?: number;
  pct90?: number;
}
