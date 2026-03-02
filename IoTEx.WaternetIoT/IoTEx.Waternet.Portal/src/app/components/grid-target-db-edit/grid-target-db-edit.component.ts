import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-target-db-edit',
  templateUrl: './grid-target-db-edit.component.html',
  styleUrls: ['./grid-target-db-edit.component.css']
})
export class GridTargetDBEditComponent extends BaseComponent {
 
  protected _targetDB: DTO.TargetDBDTO;
  private targetDBData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    connectionString: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(targetDB: DTO.TargetDBDTO) {
    this._targetDB = targetDB;
    this.editForm.reset(targetDB);
    this.active = targetDB !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.TargetDBDTO> = new EventEmitter();
  constructor() {
    super();
    this.targetDBData = DATA.nameData;
  }
  
  public onSave(e): void {
    e.preventDefault();
 
    this._targetDB.name = this.editForm.value.name;
    this._targetDB.description = this.editForm.value.description;
    this._targetDB.connectionString = this.editForm.value.connectionString;

    this.save.emit(this._targetDB);
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
