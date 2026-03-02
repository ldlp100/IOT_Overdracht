import { BaseDTO } from "./baseDTO";

export class SupplierDTO extends BaseDTO {
  name: string;
  description?: string;
  telNumber?: string;
}
