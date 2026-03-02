import { Component, Input } from '@angular/core';
import * as DTO from '../../models/_index'

@Component({
  selector: 'app-grid-device-type-detail',
  templateUrl: './grid-device-type-detail.component.html',
  styleUrls: ['./grid-device-type-detail.component.css']
})
export class GridDeviceTypeDetailComponent {

  @Input() public deviceType : DTO.DeviceTypeDTO
}
