import { BaseDTO } from "./baseDTO";

export enum AttachmentTypeEnum { OBJ_PHOTO=1, PHOTO = 2, OBJ_VIDEO = 3,VIDEO=4, USER_MANUAL=5, INSTALLATION_MANUAL=6 , SYSTEM_DOCUMENT=7, DOCUMENT=8 }
export enum ObjectTypeEnum { PROJECT=1, DEVICETYPE=2, DEVICE = 3 , FIRMWARE=4}

export class AttachmentDTO extends BaseDTO {
  name: string;
  description: string;
  URL: string;
  objectId: string;
  objectType: ObjectTypeEnum;
  attachmentType?: AttachmentTypeEnum;
  size: number;
}
