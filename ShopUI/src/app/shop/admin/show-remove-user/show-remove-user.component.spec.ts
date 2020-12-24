import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRemoveUserComponent } from './show-remove-user.component';

describe('ShowRemoveUserComponent', () => {
  let component: ShowRemoveUserComponent;
  let fixture: ComponentFixture<ShowRemoveUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRemoveUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRemoveUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
