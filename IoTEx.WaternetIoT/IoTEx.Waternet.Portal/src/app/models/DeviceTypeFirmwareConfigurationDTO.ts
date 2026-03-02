import { BaseDTO } from "./baseDTO";

export enum ConfigurationRole { IoTWorker =0, TechnicalWorker=1, DomainWorker=2 }

export class DeviceTypeFirmwareConfigurationDTO extends BaseDTO {
  name: string;
  symbol?: string;
  defaultValue?: string;
  typeName?: string;
  categories?: string;
  description?: string;
  minLength?: number;
  maxLength?: number;
  minValue?: number;
  maxValue?: number;
  role: ConfigurationRole;
  deviceTypeFirmwareId: string;
}
