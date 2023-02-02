import { Installment } from "./installment";
import { RepaymentTerm } from "./repayment-term"

export class PaymentPlan {
    id!: number;
    code!: string;
    productID!: number;
    totalAmount: number = 0;
    interestPercentage: number = 0;
    firstPaymentDate: Date = new Date();
    lastPaymentDate: Date = new Date();
    repaymentTermID!: number;
    repaymentTerm: RepaymentTerm | null = null;
    installments: Installment[] = [];
  }
  