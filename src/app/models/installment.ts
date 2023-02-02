export class Installment {
  id!: number;
  code!: string;
  order: number = 0;
  startDate: Date = new Date();
  endDate: Date = new Date();
  amountToBePaid: number = 0;
  interestAmount: number = 0;
  paymentPlanID!: number;
}
