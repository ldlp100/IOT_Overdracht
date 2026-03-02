import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'
import { NotificationService } from "@progress/kendo-angular-notification";

@Component({
  selector: 'app-device-published-basic',
  standalone: false,
  templateUrl: './device-published-basic.component.html',
  styleUrl: './device-published-basic.component.css'
})
export class DevicePublishedBasicComponent extends BaseComponent implements OnInit{
  private device: DTO.DeviceDTO;
  @Input() public devicePublished: DTO.DeviceDefinitionDTO;
  public editForm: FormGroup = new FormGroup({
    name: new FormControl({ value: '', disabled: false }, Validators.required),
    assetUID: new FormControl({ value: '', disabled: false }),
    installedDate: new FormControl(new Date()),
    isActive: new FormControl({ value: false, disabled: false }),
    lat: new FormControl({ value: '', disabled: false }),
    long: new FormControl({ value: new Date(), disabled: false })
  });
  constructor(private service: IoTExService,private notificationService: NotificationService) {
      super();
  }
  public ngOnInit(): void {
    if(this.devicePublished!=null){
      console.log("Device Published Basic-",this.devicePublished);
      this.device = new DTO.DeviceDTO();
      this.device.id = this.devicePublished.deviceId;
      this.device.name = this.devicePublished.deviceName;
      this.device.assetUID = this.devicePublished.assetUID;
      this.device.installedDate = new Date(this.devicePublished.installedDate);
      //this.device.installedDate = this.devicePublished.installedDate;
      this.device.lat = this.devicePublished.location.latitude;
      this.device.long = this.devicePublished.location.longitude;
      this.device.isActive = this.devicePublished.isActive;
      this.device.deviceBatchId = this.devicePublished.info.deviceBatchId;
      this.device.deviceTypeId = this.devicePublished.info.deviceTypeId;
      
      this.editForm.reset(this.device);
      
    }
  }
  public save(){
    
    this.device.name = this.editForm.value.name;
    this.device.assetUID = this.editForm.value.assetUID;
    this.device.installedDate = this.editForm.value.installedDate;
    //this.device.installedDate = this.devicePublished.installedDate;
    this.device.lat = this.editForm.value.lat;
    this.device.long = this.editForm.value.long;
    this.device.isActive = this.editForm.value.isActive;
    
    console.log("Save",this.device);
    this.service.deviceService.saveMinimal(this.device).subscribe((result) => {
      if (result.isOk) {
        
      
        this.service.deviceService.publish(this.devicePublished.deviceId, this.devicePublished.info.deviceTypeId, 
                              this.devicePublished.info.deviceBatchId).subscribe((result) => {
          console.log("RESULT",result);
          this.notificationService.show({
            content: (result.isOk)? "Device is published successfully!" : "Error while publishing device!\n" + result.error,
            cssClass: "button-notification",
            animation: { type: "slide", duration: 400 },
            position: { horizontal: "center", vertical: "bottom" },
            type: { style: (result.isOk)?"success":"error", icon: true },
            closable: false,
          });
        });
      }
    });
  }
  public openLocationPicker(): void {
      if (!('geolocation' in navigator)) {
        this.notificationService.show({
          content: "Geolocation is not supported by this browser.",
          cssClass: "button-notification",
          animation: { type: "slide", duration: 400 },
          position: { horizontal: "center", vertical: "bottom" },
          hideAfter: 3000,
          type: { style: "error", icon: true },
          closable: true,
        });
        return;
      }

      navigator.geolocation.getCurrentPosition(
        (position) => {
          const lat = position.coords.latitude;
          const long = position.coords.longitude;

          // ensure device object exists
          if (!this.device) {
            this.device = new DTO.DeviceDTO();
          }
          this.device.lat = lat;
          this.device.long = long;

          // update the form controls
          this.editForm.patchValue({ lat, long });

          this.notificationService.show({
            content: `Location acquired (lat: ${lat.toFixed(6)}, long: ${long.toFixed(6)})`,
            cssClass: "button-notification",
            animation: { type: "fade", duration: 400 },
            position: { horizontal: "center", vertical: "bottom" },
            type: { style: "success", icon: true },
            closable: false
          });
        },
        (error) => {
          const message =
            error.code === error.PERMISSION_DENIED
              ? "Location permission denied."
              : error.message || "Unable to retrieve location.";

          this.notificationService.show({
            content: message,
            cssClass: "button-notification",
            animation: { type: "slide", duration: 400 },
            position: { horizontal: "center", vertical: "bottom" },
            type: { style: "error", icon: true },
            closable: false
          });
        },
        { enableHighAccuracy: true, timeout: 10000, maximumAge: 0 }
      );
  }
    
  
}
