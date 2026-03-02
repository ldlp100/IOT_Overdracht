import { BaseDTO } from "./baseDTO";

export class EventStateTypeDTO extends BaseDTO {
  name?: string;
  description?: string;
  isState?: string;
  isReleased?: boolean;
  isUpdated?: boolean;
  derivedStateId?: string;
}
