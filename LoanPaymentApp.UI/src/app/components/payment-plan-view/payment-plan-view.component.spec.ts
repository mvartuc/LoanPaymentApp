import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentPlanViewComponent } from './payment-plan-view.component';

describe('PaymentPlanViewComponent', () => {
  let component: PaymentPlanViewComponent;
  let fixture: ComponentFixture<PaymentPlanViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentPlanViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentPlanViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
