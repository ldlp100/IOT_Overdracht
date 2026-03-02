import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-project-edit',
  templateUrl: './grid-project-edit.component.html',
  styleUrls: ['./grid-project-edit.component.css']
})
export class GridProjectEditComponent extends BaseComponent {
 
  protected _project: DTO.ProjectDTO;
  public projectData:any[]=[];
  public targetDBData:any[]; 
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    isActive: new FormControl(),
    //targetDBString: new FormControl(),
    latitude: new FormControl(),
    longitude: new FormControl(),
    accessLevel: new FormControl({}, Validators.required),
    beginDate: new FormControl(),
    endDate: new FormControl(),
    targetDBId: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(project: DTO.ProjectDTO) {
    this._project = project;
    if(this._project!=undefined){
      this.projectData = DATA.accessEnumData;
      project.beginDate = new Date();
      project.endDate = new Date();
      this.editForm.reset(project);
      
      console.log("Project-",project);
      this.active = project !== undefined;
      this.fillcombo();
    }
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.ProjectDTO> = new EventEmitter();
  constructor(private service: IoTExService) {
    super();
    this.projectData = DATA.nameData;
  }

  public ngOnInit(): void {
    this.fillcombo();
  }

  public fillcombo():void{
    this.service.targetDBService.gets(null).subscribe((result)=>{
      this.targetDBData = result.value;
     })
  }
  
  public onSave(e): void {
    e.preventDefault();
 
    this._project.name = this.editForm.value.name;
    this._project.description = this.editForm.value.description;
    this._project.isActive = this.editForm.value.isActive;
    //this._project.targetDBString = this.editForm.value.targetDBString;
    this._project.latitude = this.editForm.value.latitude;
    this._project.longitude = this.editForm.value.longitude;
    this._project.accessLevel = this.editForm.value.accessLevel;
    this._project.beginDate = (this.editForm.value.beginDate=="")?null:this.editForm.value.beginDate;
    this._project.endDate = (this.editForm.value.endDate=="")?null:this.editForm.value.endDate;
    this._project.targetDBId = this.editForm.value.targetDBId;
    console.log("SAVED PROJECT",this._project);
    this.save.emit(this._project);
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
