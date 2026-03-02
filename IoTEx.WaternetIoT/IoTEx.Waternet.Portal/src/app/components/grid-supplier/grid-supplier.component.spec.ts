import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridSupplierComponent } from './grid-supplier.component';

describe('GridSupplierComponent', () => {
  let component: GridSupplierComponent;
  let fixture: ComponentFixture<GridSupplierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridSupplierComponent]
    });
    fixture = TestBed.createComponent(GridSupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
