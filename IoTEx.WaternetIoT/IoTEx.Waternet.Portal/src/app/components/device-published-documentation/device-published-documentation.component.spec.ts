import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePublishedDocumentationComponent } from './device-published-documentation.component';

describe('DevicePublishedDocumentationComponent', () => {
  let component: DevicePublishedDocumentationComponent;
  let fixture: ComponentFixture<DevicePublishedDocumentationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DevicePublishedDocumentationComponent]
    });
    fixture = TestBed.createComponent(DevicePublishedDocumentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
