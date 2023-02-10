import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Installment } from 'src/app/models/installment';
import { PaymentPlan } from 'src/app/models/payment-plan';

@Component({
  selector: 'app-payment-plan-view',
  templateUrl: './payment-plan-view.component.html',
  styleUrls: ['./payment-plan-view.component.scss'],
})
export class PaymentPlanViewComponent implements OnInit {
  @Input() public planObservable$!: Observable<PaymentPlan>;
  @Input() public currencySign: string = "";
  constructor() {}

  ngOnInit(): void {}

  getTotalInitialDebt(paymentPlan: PaymentPlan | null): number | null {
    if (paymentPlan) {
      return paymentPlan.totalInitialDebtAmount - paymentPlan.crumbAmount;
    }
    return null;
  }

  getTotalInterestDebt(installments: Installment[]| null): number | null {
    if (installments) {
      return installments.reduce((sum, b) => sum + b.interestAmount, 0);
    }
    return null;
  }

  // getTotalTotalDebt(installments: Installment[]):number {
  //   return installments.reduce((sum, b) => sum + b.totalDebt,0);
  // }
}
