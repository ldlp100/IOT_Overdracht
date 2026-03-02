import { Component, Input, OnChanges, OnInit } from '@angular/core';
import * as DTO from '../../models/_index'
import { IoTExService } from '../../services/_index';
@Component({
  selector: 'app-grid-device-detail',
  templateUrl: './grid-device-detail.component.html',
  styleUrls: ['./grid-device-detail.component.css']
})
export class GridDeviceDetailComponent implements OnChanges {

  @Input() public deviceType : DTO.DeviceTypeDTO
  @Input() public deviceBatch : DTO.DeviceBatchDTO
  @Input() public device : DTO.DeviceDTO

  @Input() public deviceTypeId : string;
  @Input() public deviceBatchId : string;
  @Input() public deviceId : string;

  constructor(private service: IoTExService) {
  }
  ngOnChanges() {
   
    if (this.deviceId != undefined && this.deviceTypeId != undefined && this.deviceBatchId != undefined ){
      console.log("RESULT-D",this.deviceId, this.deviceTypeId, this.deviceBatchId);
        this.service.deviceTypeService.get({},this.deviceTypeId).subscribe((result) => {
          this.deviceType = result.value;
          this.service.deviceBatchService.get({},this.deviceTypeId,this.deviceBatchId).subscribe((result) => {
            this.deviceBatch = result.value;
            this.service.deviceService.get({},this.deviceTypeId,this.deviceBatchId,this.deviceId).subscribe((result) => {
              this.device = result.value;
                
              });
            });
          });
      }
    }

}
