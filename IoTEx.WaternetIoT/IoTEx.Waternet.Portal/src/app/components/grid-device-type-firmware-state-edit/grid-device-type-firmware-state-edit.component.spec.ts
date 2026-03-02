import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareStateEditComponent } from './grid-device-type-firmware-state-edit.component';

describe('GridDeviceTypeFirmwareStateEditComponent', () => {
  let component: GridDeviceTypeFirmwareStateEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareStateEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceTypeFirmwareStateEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareStateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
