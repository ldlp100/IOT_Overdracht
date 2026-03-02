import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-configuration-edit',
  templateUrl: './grid-device-configuration-edit.component.html',
  styleUrls: ['./grid-device-configuration-edit.component.css']
})
export class GridDeviceConfigurationEditComponent extends BaseComponent implements OnInit, OnChanges {
 
  

  protected _deviceConfiguration: DTO.DeviceConfigurationDTO;
  private deviceConfigurationData: any[];
  public configurationTypeData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    deviceTypeFirmwareConfigurationId: new FormControl({}, Validators.required),
    value: new FormControl(0)
  });
  @Input() public device: DTO.DeviceDTO
  @Input() public isNew = false;
 
  @Input() public set model(deviceConfiguration: DTO.DeviceConfigurationDTO) {
    this._deviceConfiguration = deviceConfiguration;
    this.editForm.reset(deviceConfiguration);
    this.active = deviceConfiguration !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceConfigurationDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceConfigurationData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }
  public ngOnChanges(changes: SimpleChanges): void {
      console.log("Changes",changes);
      this.fillcombo();
    
  }
  public fillcombo():void{    
    if (this.device == null) {
      return;
    }
    if (this.device.deviceTypeId == null || this.device.deviceTypeFirmwareId == null) {
      return;
    }
    this.service.deviceTypeFirmwareConfigurationService.gets(null, this.device.deviceTypeId, this.device.deviceTypeFirmwareId).subscribe((result)=>{
      this.configurationTypeData = result.value;
      console.log("Result_COMBO",result);
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceConfiguration.deviceTypeFirmwareConfigurationId = this.editForm.value.deviceTypeFirmwareConfigurationId;
    this._deviceConfiguration.value = this.editForm.value.value;

    this.save.emit(this._deviceConfiguration);
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

