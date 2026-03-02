import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDeviceType2NetworkAPIComponent } from './grid-device-type-2-network-api.component';

describe('GridDeviceType2NetworkAPIComponent', () => {
  let component: GridDeviceType2NetworkAPIComponent;
  let fixture: ComponentFixture<GridDeviceType2NetworkAPIComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridDeviceType2NetworkAPIComponent]
    });
    fixture = TestBed.createComponent(GridDeviceType2NetworkAPIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
