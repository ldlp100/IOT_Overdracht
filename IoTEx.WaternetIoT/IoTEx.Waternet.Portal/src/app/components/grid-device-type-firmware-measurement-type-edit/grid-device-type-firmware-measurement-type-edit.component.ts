import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-type-firmware-measurement-type-edit',
  templateUrl: './grid-device-type-firmware-measurement-type-edit.component.html',
  styleUrls: ['./grid-device-type-firmware-measurement-type-edit.component.css']
})
export class GridDeviceTypeFirmwareMeasurementTypeEditComponent extends BaseComponent {
 
  protected _deviceTypeFirmwareMeasurementType: DTO.DeviceTypeFirmwareMeasurementTypeDTO;
  private deviceTypeFirmwareMeasurementTypeData: any[];
  public unitTypeData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    unitTypeId: new FormControl({}, Validators.required),
    minMeas: new FormControl(),
    maxMeas: new FormControl(),
    offsetValue: new FormControl(),
    minSensor: new FormControl(),
    maxSensor: new FormControl(),
    measurementTypeId: new FormControl(),
    unit: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(devicetypeFirmwareEventStateType: DTO.DeviceTypeFirmwareMeasurementTypeDTO) {
    this._deviceTypeFirmwareMeasurementType = devicetypeFirmwareEventStateType;
    this.editForm.reset(devicetypeFirmwareEventStateType);
    this.active = devicetypeFirmwareEventStateType !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceTypeFirmwareMeasurementTypeDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceTypeFirmwareMeasurementTypeData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.unitTypeService.gets(null).subscribe((result)=>{
      this.unitTypeData =result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceTypeFirmwareMeasurementType.name = this.editForm.value.name;
    this._deviceTypeFirmwareMeasurementType.description = this.editForm.value.description;
    this._deviceTypeFirmwareMeasurementType.isNew = this.editForm.value.isNew;
    this._deviceTypeFirmwareMeasurementType.measurementTypeId = this.editForm.value.measurementTypeId;
    this._deviceTypeFirmwareMeasurementType.unitTypeId = this.editForm.value.unitTypeId;
    this._deviceTypeFirmwareMeasurementType.minMeas = this.editForm.value.minMeas;
    this._deviceTypeFirmwareMeasurementType.maxMeas = this.editForm.value.maxMeas;
    this._deviceTypeFirmwareMeasurementType.offsetValue = this.editForm.value.offsetValue;
    this._deviceTypeFirmwareMeasurementType.minSensor = this.editForm.value.minSensor;
    this._deviceTypeFirmwareMeasurementType.maxSensor = this.editForm.value.maxSensor;
    this._deviceTypeFirmwareMeasurementType.unit = this.editForm.value.unit;

    this.save.emit(this._deviceTypeFirmwareMeasurementType);
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

