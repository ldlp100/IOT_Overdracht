import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridNetworkAPIComponent } from './grid-network-api.component';

describe('GridNetworkAPIComponent', () => {
  let component: GridNetworkAPIComponent;
  let fixture: ComponentFixture<GridNetworkAPIComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridNetworkAPIComponent]
    });
    fixture = TestBed.createComponent(GridNetworkAPIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
