import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceProjectComponent } from './grid-device-project.component';

describe('GridDeviceProjectComponent', () => {
  let component: GridDeviceProjectComponent;
  let fixture: ComponentFixture<GridDeviceProjectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceProjectComponent]
    });
    fixture = TestBed.createComponent(GridDeviceProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
