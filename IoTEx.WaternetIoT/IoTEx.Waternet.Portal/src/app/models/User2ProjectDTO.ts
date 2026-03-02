import { BaseDTO } from "./baseDTO";
export enum RoleEnum { Admin = 0, Contributor = 1, Reader = 2 }

export class User2ProjectDTO extends BaseDTO {
  userId?: string;
  userName?: string;
  projectId?: string;
  projectName?: string;
  projectDescription?: string;
  projectIsActive?: boolean;
  role?: RoleEnum;
}
