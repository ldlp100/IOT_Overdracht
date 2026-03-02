import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAppConfigurationComponent } from './grid-app-configuration.component';

describe('GridAppConfigurationComponent', () => {
  let component: GridAppConfigurationComponent;
  let fixture: ComponentFixture<GridAppConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridAppConfigurationComponent]
    });
    fixture = TestBed.createComponent(GridAppConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
