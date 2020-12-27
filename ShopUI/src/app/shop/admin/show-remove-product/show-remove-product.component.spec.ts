import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowRemoveProductComponent } from './show-remove-product.component';

describe('ShowRemoveProductComponent', () => {
  let component: ShowRemoveProductComponent;
  let fixture: ComponentFixture<ShowRemoveProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowRemoveProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowRemoveProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
