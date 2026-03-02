import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridSupplierEditComponent } from './grid-supplier-edit.component';

describe('GridSupplierEditComponent', () => {
  let component: GridSupplierEditComponent;
  let fixture: ComponentFixture<GridSupplierEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridSupplierEditComponent]
    });
    fixture = TestBed.createComponent(GridSupplierEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
