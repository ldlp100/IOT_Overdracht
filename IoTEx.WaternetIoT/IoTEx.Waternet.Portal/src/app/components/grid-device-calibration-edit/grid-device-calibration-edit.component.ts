import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-calibration-edit',
  templateUrl: './grid-device-calibration-edit.component.html',
  styleUrls: ['./grid-device-calibration-edit.component.css']
})
export class GridDeviceCalibrationEditComponent extends BaseComponent {
 
  @Input() public device: DTO.DeviceDTO

  protected _deviceCalibration: DTO.DeviceCalibrationDTO;
  private deviceCalibrationData: any[];
  public measerementTypeData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    deviceTypeFirmware2MeasurementTypeId: new FormControl({}, Validators.required),
    minReal: new FormControl(),
    maxReal: new FormControl(),
    minMeas: new FormControl(),
    maxMeas: new FormControl(),
    offsetValue: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(deviceCalibration: DTO.DeviceCalibrationDTO) {
    this._deviceCalibration = deviceCalibration;
    this.editForm.reset(deviceCalibration);
    this.active = deviceCalibration !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceCalibrationDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceCalibrationData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{    
    this.service.deviceTypeFirmwareMeasurementTypeService.gets(null, this.device.deviceTypeId, this.device.deviceTypeFirmwareId).subscribe((result)=>{
      this.measerementTypeData = result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceCalibration.deviceTypeFirmware2MeasurementTypeId = this.editForm.value.deviceTypeFirmware2MeasurementTypeId;
    this._deviceCalibration.minReal = this.editForm.value.minReal;
    this._deviceCalibration.maxReal = this.editForm.value.maxReal;
    this._deviceCalibration.minMeas = this.editForm.value.minMeas;
    this._deviceCalibration.maxMeas = this.editForm.value.maxMeas;
    this._deviceCalibration.offsetValue = this.editForm.value.offsetValue;

    this.save.emit(this._deviceCalibration);
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

