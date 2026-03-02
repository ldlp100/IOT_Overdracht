import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareConfigurationEditComponent } from './grid-device-type-firmware-configuration-edit.component';

describe('GridDeviceTypeFirmwareConfigurationEditComponent', () => {
  let component: GridDeviceTypeFirmwareConfigurationEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareConfigurationEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareConfigurationEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareConfigurationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
