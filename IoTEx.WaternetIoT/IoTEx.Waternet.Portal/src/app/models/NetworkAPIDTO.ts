import { BaseDTO } from "./baseDTO";

export class NetworkAPIDTO extends BaseDTO {
  name: string;
  description?: string;
  isLORA: boolean=false;
  isSigFox: boolean=false;
  isLTM: boolean=false;
  isNBIoT: boolean=false;
}
