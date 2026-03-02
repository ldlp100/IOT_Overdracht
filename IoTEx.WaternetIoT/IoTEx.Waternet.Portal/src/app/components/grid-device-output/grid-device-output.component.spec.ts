import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceOutputComponent } from './grid-device-output.component';

describe('GridDeviceOutputComponent', () => {
  let component: GridDeviceOutputComponent;
  let fixture: ComponentFixture<GridDeviceOutputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceOutputComponent]
    });
    fixture = TestBed.createComponent(GridDeviceOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
