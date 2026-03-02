import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceChartComponent } from './device-chart.component';

describe('DeviceChartComponent', () => {
  let component: DeviceChartComponent;
  let fixture: ComponentFixture<DeviceChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeviceChartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeviceChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
