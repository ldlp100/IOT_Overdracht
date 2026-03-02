import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareConfigurationComponent } from './grid-device-type-firmware-configuration.component';

describe('GridDeviceTypeFirmwareConfigurationComponent', () => {
  let component: GridDeviceTypeFirmwareConfigurationComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareConfigurationComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
