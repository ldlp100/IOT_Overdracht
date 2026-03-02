import { DocumentTelemetryEventDTO, DocumentTelemetryNetworkDTO } from "./_index";

export enum NetworkTypeEnum { NOT_DEFINED = 0, LORAWAN_KERLINK = 1, SIGFOX = 2, NBIoT_TMOBILE = 3, IOTDEV_UDP_APN_TMOBILE_NBIOT = 4 }

export class DeviceMessageContentDTO {
  _ts?: number;
  msgName?: string;
  id?: string;
  CFGUID?: string;
  namespace?: string;
  MUID?: string;
  DMUID?: string;
  deviceID?: string;
  deviceNetworkUID?: string;
  deviceGroupID?: string;
  deviceSerialNr?: string;
  rcvDateTime?: Date;
  deviceType?: string;
  networkType?: NetworkTypeEnum;
  originalMessage?: string;
  assetUID?: string;
  latitude?: number;
  longitude?: number;
  events?: DocumentTelemetryEventDTO[];
  networkInfo?: DocumentTelemetryNetworkDTO;
}
