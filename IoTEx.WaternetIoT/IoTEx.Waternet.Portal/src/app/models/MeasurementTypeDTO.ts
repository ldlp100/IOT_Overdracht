import { BaseDTO } from "./baseDTO";

export class MeasurementTypeDTO extends BaseDTO {
  name?: string;
  description?: string;
  unitTypeId?: string;
}
