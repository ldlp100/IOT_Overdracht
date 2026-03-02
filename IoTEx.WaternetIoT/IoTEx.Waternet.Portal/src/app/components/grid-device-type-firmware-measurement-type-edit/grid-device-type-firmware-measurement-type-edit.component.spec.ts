import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareMeasurementTypeEditComponent } from './grid-device-type-firmware-measurement-type-edit.component';

describe('GridDeviceTypeFirmwareMeasurementTypeEditComponent', () => {
  let component: GridDeviceTypeFirmwareMeasurementTypeEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareMeasurementTypeEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareMeasurementTypeEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareMeasurementTypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
