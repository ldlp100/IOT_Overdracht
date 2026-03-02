import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridTargetDBComponent } from './grid-target-db.component';

describe('GridTargetDBComponent', () => {
  let component: GridTargetDBComponent;
  let fixture: ComponentFixture<GridTargetDBComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridTargetDBComponent]
    });
    fixture = TestBed.createComponent(GridTargetDBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
