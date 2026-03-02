import { BaseDTO } from "./baseDTO";

export class DocumentTelemetryNetworkDTO extends BaseDTO {
  SNR?: number;
  station?: string;
  RSSI?: number;
  sequence?: number;
  SF?: number;
  DT?: Date;
  CNT?: number;
}
