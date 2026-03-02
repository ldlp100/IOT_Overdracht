import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceTypeFirmwareSubstateComponent } from './grid-device-type-firmware-substate.component';

describe('GridDeviceTypeFirmwareSubstateComponent', () => {
  let component: GridDeviceTypeFirmwareSubstateComponent;
  let fixture: ComponentFixture<GridDeviceTypeFirmwareSubstateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GridDeviceTypeFirmwareSubstateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GridDeviceTypeFirmwareSubstateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
