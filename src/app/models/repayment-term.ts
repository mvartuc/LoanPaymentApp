import { DatePart } from "./date-part";

export class RepaymentTerm {
  id!: number;
  code!: string;
  yearID!: number;
  year: DatePart | null = null;
  monthID!: number;
  month: DatePart | null = null;
}
