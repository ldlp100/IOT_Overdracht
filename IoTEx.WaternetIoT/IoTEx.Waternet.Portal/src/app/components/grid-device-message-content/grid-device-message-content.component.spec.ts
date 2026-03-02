import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceMessageContentComponent } from './grid-device-message-content.component';

describe('GridDeviceMessageContentComponent', () => {
  let component: GridDeviceMessageContentComponent;
  let fixture: ComponentFixture<GridDeviceMessageContentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceMessageContentComponent]
    });
    fixture = TestBed.createComponent(GridDeviceMessageContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
