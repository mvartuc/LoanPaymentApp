import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSpecialOfferComponent } from './form-special-offer.component';

describe('FormSpecialOfferComponent', () => {
  let component: FormSpecialOfferComponent;
  let fixture: ComponentFixture<FormSpecialOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormSpecialOfferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSpecialOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
