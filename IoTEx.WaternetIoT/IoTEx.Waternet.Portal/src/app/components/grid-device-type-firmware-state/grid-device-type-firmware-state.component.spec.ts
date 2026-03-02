import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareStateComponent } from './grid-device-type-firmware-state.component';

describe('GridDeviceTypeFirmwareStateComponent', () => {
  let component: GridDeviceTypeFirmwareStateComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareStateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareStateComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
