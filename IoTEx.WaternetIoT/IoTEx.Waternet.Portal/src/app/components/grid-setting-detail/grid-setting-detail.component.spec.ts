import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridSettingDetailComponent } from './grid-setting-detail.component';

describe('GridSettingDetailComponent', () => {
  let component: GridSettingDetailComponent;
  let fixture: ComponentFixture<GridSettingDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridSettingDetailComponent]
    });
    fixture = TestBed.createComponent(GridSettingDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
