import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridNetworkAPISettingComponent } from './grid-network-apisetting.component';

describe('GridNetworkAPISettingComponent', () => {
  let component: GridNetworkAPISettingComponent;
  let fixture: ComponentFixture<GridNetworkAPISettingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridNetworkAPISettingComponent]
    });
    fixture = TestBed.createComponent(GridNetworkAPISettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
