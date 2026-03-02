import { BaseDTO } from "./baseDTO";

export class DeviceMessageDTO extends BaseDTO {
  deviceId: string;
  received: Date;
}
