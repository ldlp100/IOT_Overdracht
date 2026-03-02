import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IoTExService } from '../../services/_index';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as DTO from '../../models/_index';
import * as COMMON from '../../common/index';
import { BaseComponent } from '../../base.component';
import * as DATA from '../../data/data'

@Component({
  selector: 'app-grid-parser-edit',
  templateUrl: './grid-parser-edit.component.html',
  styleUrls: ['./grid-parser-edit.component.css']
})
export class GridParserEditComponent extends BaseComponent {
 
  protected _parser: DTO.ParserDTO;
  private parserData: any[];
  public active = false;
  public editForm: FormGroup = new FormGroup({
    id: new FormControl({ disabled: true }),
    name: new FormControl({}, Validators.required),
    description: new FormControl(),
    className: new FormControl()
  });
 
  @Input() public isNew = false;
 
  @Input() public set model(parser: DTO.ParserDTO) {
    this._parser = parser;
    this.editForm.reset(parser);
    this.active = parser !== undefined;
  }
 
  @Output() cancel: EventEmitter<any> = new EventEmitter();
  @Output() save: EventEmitter<DTO.ParserDTO> = new EventEmitter();
  constructor() {
    super();
    this.parserData = DATA.nameData;
  }
  
  public onSave(e): void {
    e.preventDefault();
 
    this._parser.name = this.editForm.value.name;
    this._parser.description = this.editForm.value.description;
    this._parser.className = this.editForm.value.className;
    this.save.emit(this._parser);
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
