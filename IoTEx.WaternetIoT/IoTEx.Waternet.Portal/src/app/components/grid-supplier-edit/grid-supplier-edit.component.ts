import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'
@Component({
  selector: 'app-grid-supplier-edit',
  templateUrl: './grid-supplier-edit.component.html',
  styleUrls: ['./grid-supplier-edit.component.css']
})
export class GridSupplierEditComponent extends BaseComponent {
 
  protected _supplier: DTO.SupplierDTO;
  private supplierData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    telNumber: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(supplier: DTO.SupplierDTO) {
    this._supplier = supplier;
    this.editForm.reset(supplier);
    this.active = supplier !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.SupplierDTO> = new EventEmitter();
  constructor() {
    super();
    this.supplierData = DATA.nameData;
  }
  
  public onSave(e): void {
    e.preventDefault();
 
    this._supplier.name = this.editForm.value.name;
    this._supplier.description = this.editForm.value.description;
    this._supplier.telNumber = this.editForm.value.telNumber;
    this.save.emit(this._supplier);
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
