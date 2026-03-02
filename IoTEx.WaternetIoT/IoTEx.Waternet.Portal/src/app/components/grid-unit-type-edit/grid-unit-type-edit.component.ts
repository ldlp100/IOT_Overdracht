import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-unit-type-edit',
  templateUrl: './grid-unit-type-edit.component.html',
  styleUrls: ['./grid-unit-type-edit.component.css']
})
export class GridUnitTypeEditComponent extends BaseComponent {
 
  protected _unitType: DTO.UnitTypeDTO;
  private unitTypeData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    label: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(unitType: DTO.UnitTypeDTO) {
    this._unitType = unitType;
    this.editForm.reset(unitType);
    this.active = unitType !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.UnitTypeDTO> = new EventEmitter();
  constructor() {
    super();
    this.unitTypeData = DATA.nameData;
  }
  
  public onSave(e): void {
    e.preventDefault();
 
    this._unitType.name = this.editForm.value.name;
    this._unitType.description = this.editForm.value.description;
    this._unitType.label = this.editForm.value.label;
    this.save.emit(this._unitType);
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
