import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridProjectComponent } from './grid-project.component';

describe('GridProjectComponent', () => {
  let component: GridProjectComponent;
  let fixture: ComponentFixture<GridProjectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridProjectComponent]
    });
    fixture = TestBed.createComponent(GridProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
