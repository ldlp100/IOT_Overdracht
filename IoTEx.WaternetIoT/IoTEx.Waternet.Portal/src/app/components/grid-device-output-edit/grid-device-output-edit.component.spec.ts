import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceOutputEditComponent } from './grid-device-output-edit.component';

describe('GridDeviceOutputEditComponent', () => {
  let component: GridDeviceOutputEditComponent;
  let fixture: ComponentFixture<GridDeviceOutputEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceOutputEditComponent]
    });
    fixture = TestBed.createComponent(GridDeviceOutputEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
