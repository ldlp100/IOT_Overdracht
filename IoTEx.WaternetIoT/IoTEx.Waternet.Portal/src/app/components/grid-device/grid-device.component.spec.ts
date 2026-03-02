import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceComponent } from './grid-device.component';

describe('GridDeviceComponent', () => {
  let component: GridDeviceComponent;
  let fixture: ComponentFixture<GridDeviceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceComponent]
    });
    fixture = TestBed.createComponent(GridDeviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
