import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAppConfigurationEditComponent } from './grid-app-configuration-edit.component';

describe('GridAppConfigurationEditComponent', () => {
  let component: GridAppConfigurationEditComponent;
  let fixture: ComponentFixture<GridAppConfigurationEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridAppConfigurationEditComponent]
    });
    fixture = TestBed.createComponent(GridAppConfigurationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
