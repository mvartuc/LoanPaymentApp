import { DatePart } from './date-part';
import { Installment } from './installment';
import { RepaymentTerm } from './repayment-term';

export class PaymentPlan {
  id!: number;
  code!: string;
  productID!: number;
  totalInitialDebtAmount: number = 0;
  interestPercentage: number = 0;
  bsmvPercentageDisplayValue: number = 0;
  bsmvPercentage: number = 0;
  firstPaymentDate: Date = new Date();
  lastPaymentDate: Date | null = null;
  repaymentTermID!: number;
  repaymentTerm: RepaymentTerm | null = new RepaymentTerm();
  period: DatePart | null = new DatePart('Ay', 12);
  installmentTypeCode: string = "";
  installments: Installment[] = [];
  crumbAmount: number = 0;
  totalInterestAmount: number = 0;
  totalBsmvAmount: number = 0;
  totalAmountToBePaid: number = 0;
}
