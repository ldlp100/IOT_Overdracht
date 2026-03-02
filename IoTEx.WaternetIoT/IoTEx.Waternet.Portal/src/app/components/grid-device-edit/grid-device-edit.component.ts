import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-edit',
  templateUrl: './grid-device-edit.component.html',
  styleUrls: ['./grid-device-edit.component.css']
})
export class GridDeviceEditComponent extends BaseComponent {
 
  @Input() public deviceTypeId: string
  
  protected _device: DTO.DeviceDTO;
  private deviceData: any[];
  public deviceTypeFirmwareData:any[]=[]; 
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    assetUID: new FormControl(),
    isActive: new FormControl(),
    isTraced: new FormControl(),
    name: new FormControl({}, Validators.required),
    long: new FormControl(),
    lat: new FormControl(),
    serialNr: new FormControl(),
    harwareVersion: new FormControl(),
    deviceTypeFirmwareId: new FormControl({}, Validators.required),
    // sigFoxId: new FormControl(),
    // sigfoxPAC: new FormControl(),
    // sigfoxAPPKey: new FormControl(),
    lorA_DEVEUI: new FormControl(),
    lorA_OTAA_APPEUI: new FormControl(),
    lorA_OTAA_APPKEY: new FormControl(),
    imei: new FormControl(),
    imeiAppKey: new FormControl(),
    iccid: new FormControl(),
    installedDate: new FormControl(new Date())
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(device: DTO.DeviceDTO) {
    this._device = device;
    if(this._device!=undefined){
      this.deviceTypeId = this._device.deviceTypeId;
      
      device.installedDate = new Date();
      this.editForm.reset(device);
      
      console.log("Device-",device);
      this.active = device !== undefined;
      this.fillcombo();
    }
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceData = DATA.nameData;
  }

  public ngOnInit(): void {
    
  }

  public fillcombo(): void {
    if (this.deviceTypeId != undefined) {
      this.service.deviceTypeFirmwareService.gets(null, this.deviceTypeId).subscribe((result)=>{
        this.deviceTypeFirmwareData = result.value;
      })
    }
  }

  public onSave(e): void {
    e.preventDefault();

    this._device.assetUID = this.editForm.value.assetUID;
    this._device.isActive = this.editForm.value.isActive;
    this._device.isTraced = this.editForm.value.isTraced;
    this._device.name = this.editForm.value.name;
    this._device.long = this.editForm.value.long;
    this._device.lat = this.editForm.value.lat;
    this._device.serialNr = this.editForm.value.serialNr;
    this._device.harwareVersion = this.editForm.value.harwareVersion;
    this._device.deviceTypeFirmwareId = this.editForm.value.deviceTypeFirmwareId;

    this._device.lorA_DEVEUI = this.editForm.value.lorA_DEVEUI;
    this._device.lorA_OTAA_APPEUI = this.editForm.value.lorA_OTAA_APPEUI;
    this._device.lorA_OTAA_APPKEY = this.editForm.value.lorA_OTAA_APPKEY;
    this._device.imei = this.editForm.value.imei;
    this._device.imeiAppKey = this.editForm.value.imeiAppKey;
    this._device.iccid = this.editForm.value.iccid;
    this._device.installedDate = this.editForm.value.installedDate;
    console.log("SAVED DEVICE",this._device);
    this.save.emit(this._device);
    this.active = false;
  }
 
  public onCancel(e): void {
    e.preventDefault();
    this.closeForm();
  }
 
  public closeForm(): void {
    this.active = false;
    this.cancel.emit();
  }
}


