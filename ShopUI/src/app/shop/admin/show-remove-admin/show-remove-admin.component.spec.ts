import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRemoveAdminComponent } from './show-remove-admin.component';

describe('ShowRemoveAdminComponent', () => {
  let component: ShowRemoveAdminComponent;
  let fixture: ComponentFixture<ShowRemoveAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRemoveAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRemoveAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
