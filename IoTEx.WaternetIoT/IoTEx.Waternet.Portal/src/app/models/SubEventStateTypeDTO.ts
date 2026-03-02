import { BaseDTO } from "./baseDTO";

export class SubEventStateTypeDTO extends BaseDTO {
  name?: string;
  description?: string;
  eventStateTypeId?: string;
  IsReleased?: boolean;
  IsUpdated?: boolean;
  StartDate?: Date;
  EndDate?: Date;
  Value?: number;
}
