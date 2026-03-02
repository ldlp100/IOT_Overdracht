import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectDeviceComponent } from './grid-project-device.component';

describe('GridDeviceProjectComponent', () => {
  let component: GridProjectDeviceComponent;
  let fixture: ComponentFixture<GridProjectDeviceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectDeviceComponent]
    });
    fixture = TestBed.createComponent(GridProjectDeviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
