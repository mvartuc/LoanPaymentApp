import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormDatepartComponent } from './form-datepart.component';

describe('FormDatepartComponent', () => {
  let component: FormDatepartComponent;
  let fixture: ComponentFixture<FormDatepartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormDatepartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormDatepartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
