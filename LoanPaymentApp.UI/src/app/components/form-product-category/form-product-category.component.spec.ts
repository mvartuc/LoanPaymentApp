import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormProductCategoryComponent } from './form-product-category.component';

describe('FormProductCategoryComponent', () => {
  let component: FormProductCategoryComponent;
  let fixture: ComponentFixture<FormProductCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormProductCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormProductCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
