import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridNetworkAPIEditComponent } from './grid-network-api-edit.component';

describe('GridNetworkAPIEditComponent', () => {
  let component: GridNetworkAPIEditComponent;
  let fixture: ComponentFixture<GridNetworkAPIEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GridNetworkAPIEditComponent]
    });
    fixture = TestBed.createComponent(GridNetworkAPIEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
