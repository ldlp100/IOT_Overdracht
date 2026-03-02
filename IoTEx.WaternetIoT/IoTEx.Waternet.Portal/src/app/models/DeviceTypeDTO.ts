import { BaseDTO } from "./baseDTO";

export class DeviceTypeDTO extends BaseDTO {
  name: string;
  description?: string;
  supplierId: string;
  supplierName?: string;
}
