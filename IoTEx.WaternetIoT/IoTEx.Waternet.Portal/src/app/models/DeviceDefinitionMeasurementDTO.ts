export class DeviceDefinitionMeasurementDTO {
  id?: string;
  name?: string;
  description?: string;
  unit?: string;
  unitLabel?: string;
  minSensor?: number = 0;
  maxSensor?: number = 0;
  minMeasurement?: number = 0;
  maxMeasurement?: number = 0;
  offsetValue?: number = 0;
  updatedById?: string;
  updatedByName?: string;
}
