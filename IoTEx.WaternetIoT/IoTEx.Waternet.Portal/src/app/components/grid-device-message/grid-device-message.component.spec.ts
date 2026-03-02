import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceMessageComponent } from './grid-device-message.component';

describe('GridDeviceMessageComponent', () => {
  let component: GridDeviceMessageComponent;
  let fixture: ComponentFixture<GridDeviceMessageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceMessageComponent]
    });
    fixture = TestBed.createComponent(GridDeviceMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
