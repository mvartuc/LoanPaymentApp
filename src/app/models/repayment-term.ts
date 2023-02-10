import { DatePart } from "./date-part";

export class RepaymentTerm {
  id!: number;
  code!: string;
  yearID!: number;
  year: DatePart | null = new DatePart("Yıl", 25);
  monthID!: number;
  month: DatePart | null = new DatePart("Ay", 25*12);
}
