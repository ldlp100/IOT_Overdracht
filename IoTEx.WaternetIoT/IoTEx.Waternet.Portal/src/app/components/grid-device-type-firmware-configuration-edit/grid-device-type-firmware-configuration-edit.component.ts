import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-configuration-edit',
  templateUrl: './grid-device-type-firmware-configuration-edit.component.html',
  styleUrls: ['./grid-device-type-firmware-configuration-edit.component.css']
})
export class GridDeviceTypeFirmwareConfigurationEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmwareConfiguration: DTO.DeviceTypeFirmwareConfigurationDTO;
  public deviceTypeFirmwareConfigurationData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    symbol: new FormControl(),
    defaultValue: new FormControl(),
    typeName: new FormControl(),
    categories: new FormControl(),
    description: new FormControl(),
    minLength: new FormControl(),
    maxLength: new FormControl(),
    minValue: new FormControl(),
    maxValue: new FormControl(),
    role: new FormControl({}, Validators.required)
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmwareConfiguration: DTO.DeviceTypeFirmwareConfigurationDTO) {
    this._deviceTypeFirmwareConfiguration = devicetypeFirmwareConfiguration;
    this.deviceTypeFirmwareConfigurationData = DATA.ConfigurationRoleData;
    this.editForm.reset(devicetypeFirmwareConfiguration);
    this.active = devicetypeFirmwareConfiguration !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareConfigurationDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceTypeFirmwareConfigurationData = DATA.nameData;
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmwareConfiguration.symbol = this.editForm.value.symbol;
    this._deviceTypeFirmwareConfiguration.defaultValue = this.editForm.value.defaultValue;
    this._deviceTypeFirmwareConfiguration.typeName = this.editForm.value.typeName;
    this._deviceTypeFirmwareConfiguration.categories = this.editForm.value.categories;
    this._deviceTypeFirmwareConfiguration.minLength = this.editForm.value.minLength;
    this._deviceTypeFirmwareConfiguration.maxLength = this.editForm.value.maxLength;
    this._deviceTypeFirmwareConfiguration.minValue = this.editForm.value.minValue;
    this._deviceTypeFirmwareConfiguration.maxValue = this.editForm.value.maxValue;
    this._deviceTypeFirmwareConfiguration.role = this.editForm.value.role;
    this._deviceTypeFirmwareConfiguration.name = this.editForm.value.name;
    this._deviceTypeFirmwareConfiguration.description = this.editForm.value.description;

    this.save.emit(this._deviceTypeFirmwareConfiguration);
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

