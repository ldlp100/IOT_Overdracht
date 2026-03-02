import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceCalibrationEditComponent } from './grid-device-calibration-edit.component';

describe('GridDeviceCalibrationEditComponent', () => {
  let component: GridDeviceCalibrationEditComponent;
  let fixture: ComponentFixture<GridDeviceCalibrationEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceCalibrationEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceCalibrationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
