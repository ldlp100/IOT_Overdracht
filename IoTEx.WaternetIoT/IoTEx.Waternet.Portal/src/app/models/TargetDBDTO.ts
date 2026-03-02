import { BaseDTO } from "./baseDTO";

export class TargetDBDTO extends BaseDTO {
  name: string;
  description: string;
  connectionString: string;
}
