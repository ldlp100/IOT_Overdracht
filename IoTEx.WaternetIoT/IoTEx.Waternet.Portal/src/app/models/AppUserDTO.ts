import { BaseDTO } from "./baseDTO";

export enum RoleEnum { Admin =0, Contributor=1, Reader=2 }

export class AppUserDTO extends BaseDTO {
  username: string;
  role: RoleEnum;
}
