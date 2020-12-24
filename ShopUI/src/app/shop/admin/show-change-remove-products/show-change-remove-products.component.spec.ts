import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowChangeRemoveProductsComponent } from './show-change-remove-products.component';

describe('ShowChangeRemoveProductsComponent', () => {
  let component: ShowChangeRemoveProductsComponent;
  let fixture: ComponentFixture<ShowChangeRemoveProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowChangeRemoveProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowChangeRemoveProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
