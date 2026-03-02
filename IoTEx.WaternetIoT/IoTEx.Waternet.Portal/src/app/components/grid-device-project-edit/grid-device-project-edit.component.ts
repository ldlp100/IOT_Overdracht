import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'
import { State, FilterDescriptor, CompositeFilterDescriptor } from '@progress/kendo-data-query';

@Component({
  selector: 'app-grid-device-project-edit',
  templateUrl: './grid-device-project-edit.component.html',
  styleUrl: './grid-device-project-edit.component.css'
})
export class GridDeviceProjectEditComponent extends BaseComponent implements OnInit {
 
  protected _device2project: DTO.Device2ProjectDTO;
  private deviceTypeData: any[];
  public projectData:any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),    
    projectId: new FormControl({}, Validators.required),
    projectName: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(device2project: DTO.Device2ProjectDTO) {
    this._device2project = device2project;
    this.editForm.reset(this._device2project);
    this.active = device2project !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.Device2ProjectDTO> = new EventEmitter();

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 0
  }

  constructor(private service: IoTExService) {
    super();
    this.fillcombo();

    
  }
  
  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.projectService.gets(this.gridState).subscribe((result)=>{
      console.log("RESULT-PROJECT",result);
      this.projectData = result.value
    });
  }

  public onSave(e): void {
    e.preventDefault();
 
    this._device2project.projectId = this.editForm.value.projectId;
    this._device2project.deviceId = this._device2project.deviceId;
    
    this.save.emit(this._device2project);
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
