import { BaseDTO } from "./baseDTO";

export class Device2ProjectDTO extends BaseDTO {
  deviceId: string;
  deviceName?: string;
  projectId: string;
  projectName?: string;
  assetUID?: string;
  isActive?: boolean = false;
  installedDate?: Date; 
  deviceTypeName?: string;
  deviceFirmName?: string;
  deviceBatchName?: string;
  deviceLat:number;
  deviceLong:number;
}
