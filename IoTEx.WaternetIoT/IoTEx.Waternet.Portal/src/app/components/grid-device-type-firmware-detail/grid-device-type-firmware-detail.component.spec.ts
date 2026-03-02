import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareDetailComponent } from './grid-device-type-firmware-detail.component';

describe('GridDeviceTypeFirmwareDetailComponent', () => {
  let component: GridDeviceTypeFirmwareDetailComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareDetailComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
