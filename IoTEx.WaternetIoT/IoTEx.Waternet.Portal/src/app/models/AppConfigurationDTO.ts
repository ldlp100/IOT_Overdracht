import { BaseDTO } from "./baseDTO";

export class AppConfigurationDTO extends BaseDTO {
  name: string;
  description?: string;
  value?: string;
  isDeletable: boolean = false;
  isModifiable: boolean = false;
}
