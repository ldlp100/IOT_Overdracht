import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridNetworkAPISettingEditComponent } from './grid-network-apisetting-edit.component';

describe('GridNetworkAPISettingEditComponent', () => {
  let component: GridNetworkAPISettingEditComponent;
  let fixture: ComponentFixture<GridNetworkAPISettingEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridNetworkAPISettingEditComponent]
    });
    fixture = TestBed.createComponent(GridNetworkAPISettingEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
