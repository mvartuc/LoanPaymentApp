import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, NgModel, NgModelGroup } from '@angular/forms';
import { DatePart } from 'src/app/models/date-part';
import { RepaymentTerm } from 'src/app/models/repayment-term';

@Component({
  selector: 'app-form-repayment-term',
  templateUrl: './form-repayment-term.component.html',
  styleUrls: ['./form-repayment-term.component.scss'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgModelGroup }],
})
export class FormRepaymentTermComponent implements OnInit {
  @Input() header!: string;
  @Input() repaymentTerm!: RepaymentTerm | null;
  @Output() repaymentTermChange = new EventEmitter<RepaymentTerm | null>();
  selectedDatePart: DatePart | null = null;
  constructor() {}

  ngOnInit(): void {}

  refreshModel() {
    this.repaymentTermChange.emit(this.repaymentTerm);
  }

  isInvalid(model: NgModel): boolean | null {
    return model.invalid && (model.dirty || model.touched);
  }

  repaymentTermTypeChanged() {
    this.repaymentTerm!.month!.value = 0;
    this.repaymentTerm!.year!.value = 0;
    this.refreshModel();
  }
}
