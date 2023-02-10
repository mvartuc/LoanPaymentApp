export class Installment {
  id!: number;
  code!: string;
  order: number = 0;
  startDate: Date = new Date();
  endDate: Date = new Date();
  initialDebtAmount: number = 0;
  interestAmount: number = 0;
  bsmvAmount: number = 0;
  amountToBePaid: number = 0;
  remainingInitialDebtAmount: number = 0;
  paymentPlanID!: number;
}
