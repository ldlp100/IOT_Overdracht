import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-device-output-edit',
  templateUrl: './grid-device-output-edit.component.html',
  styleUrls: ['./grid-device-output-edit.component.css']
})
export class GridDeviceOutputEditComponent extends BaseComponent {
 
  @Input() public device: DTO.DeviceDTO

  protected _deviceOutput: DTO.DeviceOutputDTO;
  private deviceOutputData: any[];
  public unitTypeData:any[];
  public alertData:any[];
  public stateData:any[];
  public measerementTypeData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    pc: new FormControl({}, Validators.required),
    unitTypeId: new FormControl(),
    eventStateTypeId: new FormControl(),
    measurementTypeId: new FormControl()
  });

  public typeEvent:string="Alert";
  
  @Input() public isNew = false;
 
  @Input() public set model(deviceOutput: DTO.DeviceOutputDTO) {
    this._deviceOutput = deviceOutput;
    if (this._deviceOutput!=undefined) {
      this.editForm.reset(deviceOutput);
      this.active = deviceOutput !== undefined;

      if (deviceOutput.eventStateTypeId!=undefined)
      {
        if (deviceOutput.eventStateTypeIsAlert)
          this.typeEvent='alert';
        else 
          this.typeEvent='state';
      } 
      else 
        this.typeEvent='meas';
      
    }
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.DeviceOutputDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.deviceOutputData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }
  
  public handleChange(event){    
    this.typeEvent = event.target.value;
  }

  public fillcombo():void{    
    this.service.unitTypeService.gets(null).subscribe((result)=>{
      this.unitTypeData = result.value;
     })

    this.service.deviceTypeFirmwareAlertService.gets(null, this.device.deviceTypeId, this.device.deviceTypeFirmwareId).subscribe((result)=>{
      this.alertData = result.value;
    })

    this.service.deviceTypeFirmwareStateService.gets(null, this.device.deviceTypeId, this.device.deviceTypeFirmwareId).subscribe((result)=>{
      this.stateData = result.value;
    })
    
    this.service.deviceTypeFirmwareMeasurementTypeService.gets(null, this.device.deviceTypeId, this.device.deviceTypeFirmwareId).subscribe((result)=>{
      this.measerementTypeData = result.value;
     })
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._deviceOutput.pc = this.editForm.value.pc;
    this._deviceOutput.unitTypeId = this.editForm.value.unitTypeId;

    this._deviceOutput.eventStateTypeId=null;
    this._deviceOutput.measurementTypeId=null;
    this._deviceOutput.eventStateTypeIsAlert=false;

    if (this.typeEvent=='alert')
    {
      this._deviceOutput.eventStateTypeId = this.editForm.value.eventStateTypeId;
      this._deviceOutput.eventStateTypeIsAlert=true;
    }
    else if (this.typeEvent=='state')
    {
      this._deviceOutput.eventStateTypeId = this.editForm.value.eventStateTypeId;
      this._deviceOutput.eventStateTypeIsAlert=false;
    }
    else if ((this.typeEvent=='meas'))
      this._deviceOutput.measurementTypeId = this.editForm.value.measurementTypeId;

    this.save.emit(this._deviceOutput);
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

