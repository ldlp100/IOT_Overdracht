import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareSubstateEditComponent } from './grid-device-type-firmware-substate-edit.component';

describe('GridDeviceTypeFirmwareSubstateEditComponent', () => {
  let component: GridDeviceTypeFirmwareSubstateEditComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareSubstateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GridDeviceTypeFirmwareSubstateEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareSubstateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
