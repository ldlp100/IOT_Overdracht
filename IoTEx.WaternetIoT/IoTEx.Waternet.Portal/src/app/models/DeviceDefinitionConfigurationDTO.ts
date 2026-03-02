export enum ConfigurationTypeEnum { type_string = 0, type_bool = 1, type_int16 = 2, type_date = 3, type_uint16 = 4, type_float = 5, type_uint8 = 6, type_int8 = 7, type_double = 8 }

export class DeviceDefinitionConfigurationDTO {
  id?: string;
  name?: string;
  symbol?: string;
  description?: string;
  role?: string;
  value?: string;
  type?: ConfigurationTypeEnum;
  minLength?: number = 0;
  maxLength?: number = 0;
  minValue?: number = 0;
  maxValue?: number = 0;
  categories?: string;
  regEx?: string;
  updatedById?: string;
  updatedByName?: string;
}
