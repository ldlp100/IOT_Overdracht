import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeEditComponent } from './grid-device-type-edit.component';

describe('GridDeviceTypeEditComponent', () => {
  let component: GridDeviceTypeEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
