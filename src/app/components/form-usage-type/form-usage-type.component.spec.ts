import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsageTypeComponent } from './form-usage-type.component';

describe('FormUsageTypeComponent', () => {
  let component: FormUsageTypeComponent;
  let fixture: ComponentFixture<FormUsageTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUsageTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsageTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
