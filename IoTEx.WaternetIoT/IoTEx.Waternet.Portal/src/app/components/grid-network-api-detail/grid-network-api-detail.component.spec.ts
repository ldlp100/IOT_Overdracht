import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridNetworkAPIDetailComponent } from './grid-network-api-detail.component';

describe('GridNetworkAPIDetailComponent', () => {
  let component: GridNetworkAPIDetailComponent;
  let fixture: ComponentFixture<GridNetworkAPIDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridNetworkAPIDetailComponent]
    });
    fixture = TestBed.createComponent(GridNetworkAPIDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
