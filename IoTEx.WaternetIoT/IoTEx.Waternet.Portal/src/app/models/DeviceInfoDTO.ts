import { DeviceAttachmentDTO } from "./_index";

export class DeviceInfoDTO {
  serialNr?: string;
  harwareVersion?: string;
  firmWareVersion?: string;
  deviceBatchId?: string;
  deviceBatchName?: string;
  deviceTypeId?: string;
  deviceTypeName?: string;
  deviceParserId?: string;
  deviceParserName?: string;
  deviceFirmwareId?: string;
  deviceFirmwareName?: string;
  deviceParserClassName?: string;
  deviceImageURL?: string;
  deviceTypeImageURL?: string;
  attachments?: DeviceAttachmentDTO[];

}
