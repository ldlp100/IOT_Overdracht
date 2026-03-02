import { BaseDTO } from "./baseDTO";

export enum TaskTypeEnum { DATA_EXTRACT=0 }
export enum TaskStateEnum { INITIATED=0, RUNNING=1, COMPLETED=2, CANCELLED=3,FAILED=4 }

export class UserTaskDTO extends BaseDTO {
  name?: string;
  token?: string;
  description?: string;
  deviceId?: string;
  groupId?: string;
  taskType?: TaskTypeEnum;
  startDate?: Date;
  endDate?: Date;
  state?: TaskStateEnum;
  progress?: number;
  message?: string;
  HREF?: string;
  userId?: string;
}