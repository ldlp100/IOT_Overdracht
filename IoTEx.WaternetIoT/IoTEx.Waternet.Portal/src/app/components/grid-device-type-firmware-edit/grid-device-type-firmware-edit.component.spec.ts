import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareEditComponent } from './grid-device-type-firmware-edit.component';

describe('GridDeviceTypeFirmwareEditComponent', () => {
  let component: GridDeviceTypeFirmwareEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
