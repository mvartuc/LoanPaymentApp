import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormPaymentPlanComponent } from './form-payment-plan.component';

describe('FormPaymentPlanComponent', () => {
  let component: FormPaymentPlanComponent;
  let fixture: ComponentFixture<FormPaymentPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormPaymentPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormPaymentPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
