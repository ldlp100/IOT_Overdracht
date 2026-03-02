import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectDetailComponent } from './grid-project-detail.component';

describe('GridProjectDetailComponent', () => {
  let component: GridProjectDetailComponent;
  let fixture: ComponentFixture<GridProjectDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectDetailComponent]
    });
    fixture = TestBed.createComponent(GridProjectDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
