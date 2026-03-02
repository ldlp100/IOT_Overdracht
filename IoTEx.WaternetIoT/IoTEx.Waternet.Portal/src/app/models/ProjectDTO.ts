import { BaseDTO } from "./baseDTO";

export enum AccessEnum { Private=0, Organization=1, Public=2 }

export class ProjectDTO extends BaseDTO {
  name: string;
  targetDBString?: string;
  description?: string;
  latitude: number = 0;
  longitude: number = 0;
  isActive: boolean = false;
  accessLevel: AccessEnum;
  beginDate?: Date;
  endDate?: Date;
  targetDBId: string;
  targetDBName: string;
}
