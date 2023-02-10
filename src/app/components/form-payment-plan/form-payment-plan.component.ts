import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, NgModel, NgModelGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Installment } from 'src/app/models/installment';
import { Parameter } from 'src/app/models/parameter';
import { PaymentPlan } from 'src/app/models/payment-plan';
import { ParameterService } from 'src/app/services/parameter.service';
import { PaymentPlanService } from 'src/app/services/payment-plan.service';

@Component({
  selector: 'app-form-payment-plan',
  templateUrl: './form-payment-plan.component.html',
  styleUrls: ['./form-payment-plan.component.scss'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgModelGroup }],
})
export class FormPaymentPlanComponent implements OnInit {
  @Input() paymentPlan!: PaymentPlan | null;
  @Output() paymentPlanChange = new EventEmitter<PaymentPlan | null>();
  @Input() header!: string;
  @Input() planValid!: boolean | null;
  @Input() usageType!: string;
  installmentTypes$: Observable<Parameter[]> = new Observable<Parameter[]>();

  get interestPercentageAsInteger(): number {
    return this.paymentPlan!.interestPercentage * 100;
  }

  get currencySign(): string {
    if (!this.usageType) {
      return '';
    }
    // TP
    if (this.usageType === '1') {
      return '₺';
    }
    // YP
    else if (this.usageType === '2') {
      return '$';
    }
    return '';
  }

  public planObservable$!: Observable<PaymentPlan>;

  constructor(
    private paymentPlanService: PaymentPlanService,
    private parameterService: ParameterService
  ) {
    this.installmentTypes$ =
      this.parameterService.getAllParametersByGroupCode('VadeHesaplamaTuru');
  }

  ngOnInit(): void {}

  refreshModel() {
    this.paymentPlanChange.emit(this.paymentPlan);
    this.refreshInstallments();
  }

  isInvalid(model: NgModel): boolean | null {
    return model.invalid && (model.dirty || model.touched);
  }

  refreshInstallments() {
    if (this.paymentPlan && this.planValid) {
      this.planObservable$ = this.paymentPlanService.generateInstallments(
        this.paymentPlan
      );
    }
  }

  convertPercentage(event: number) {
    this.paymentPlan!.interestPercentage = event / 100;
    this.refreshModel();
  }
}
