import { BaseDTO } from "./baseDTO";

export class DeviceDTO extends BaseDTO {
  assetUID?: string;
  lastMessage?: Date;
  isActive: boolean = false;
  isTraced: boolean = false;
  name: string;
  long: number = 0;
  lat: number = 0;
  serialNr?: string;
  harwareVersion?: string;
  deviceTypeFirmwareId?: string;
  deviceTypeFirmwareName?: string;
  deviceTypeId?: string;
  deviceTypeName?: string;
  deviceBatchId?: string;
  deviceBatchName?: string;
  sigFoxId?: string;
  sigfoxPAC?: string;
  sigfoxAPPKey?: string;
  lorA_DEVEUI?: string;
  lorA_OTAA_APPEUI?: string;
  lorA_OTAA_APPKEY?: string;
  imei?: string;
  imeiAppKey?: string;
  iccid?: string;
  installedDate?: Date;
  networkId:string;
  publishedDocDate?: Date;
  altitude: number = 0;
  isRegistered: boolean = false;
  isChanged: boolean = false;
  
}
