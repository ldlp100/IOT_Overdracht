export class DeviceProjectDTO {
  id?: string;
  name?: string;
  targetDB?: string;
  startDate?: Date;
  endDate?: Date;
  isActive: boolean = false;
}
