import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormRepaymentTermComponent } from './form-repayment-term.component';

describe('FormRepaymentTermComponent', () => {
  let component: FormRepaymentTermComponent;
  let fixture: ComponentFixture<FormRepaymentTermComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormRepaymentTermComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormRepaymentTermComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
