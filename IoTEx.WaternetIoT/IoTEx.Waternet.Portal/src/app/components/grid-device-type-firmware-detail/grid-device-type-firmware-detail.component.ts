import { Component, Input } from '@angular/core';
import * as DTO from '../../models/_index'

@Component({
  selector: 'app-grid-device-type-firmware-detail',
  templateUrl: './grid-device-type-firmware-detail.component.html',
  styleUrls: ['./grid-device-type-firmware-detail.component.css']
})
export class GridDeviceTypeFirmwareDetailComponent {

  @Input() public deviceType : DTO.DeviceTypeDTO
  @Input() public deviceTypeFirmware : DTO.DeviceTypeFirmwareDTO
}
