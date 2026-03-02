import { Component, Input } from '@angular/core';
import * as DTO from '../../models/_index'

@Component({
  selector: 'app-grid-device-batch-detail',
  templateUrl: './grid-device-batch-detail.component.html',
  styleUrls: ['./grid-device-batch-detail.component.css']
})
export class GridDeviceBatchDetailComponent {

  @Input() public deviceType : DTO.DeviceTypeDTO
  @Input() public deviceBatch : DTO.DeviceBatchDTO
}
