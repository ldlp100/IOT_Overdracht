import { DeviceAlertStateEnumDTO } from "./_index";

export class DeviceDefinitionStateDTO {
  id?: string;
  name?: string;
  description?: string;
  values?: DeviceAlertStateEnumDTO[];
  updatedById?: string;
  updatedByName?: string;
}
