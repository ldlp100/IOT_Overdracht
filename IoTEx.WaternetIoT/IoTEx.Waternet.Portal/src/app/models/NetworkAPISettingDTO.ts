import { BaseDTO } from "./baseDTO";

export class NetworkAPISettingDTO extends BaseDTO {
  name: string;
  description?: string;
  value: string;
  isSecret: boolean = false;
  isDeviceInfo: boolean = false;
  networkAPIId?: string;
}
