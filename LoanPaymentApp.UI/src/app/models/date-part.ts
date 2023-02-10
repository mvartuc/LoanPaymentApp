export class DatePart {
    id!: number;
    code!: string;
    name: string = '';
    value: number = 0;
    limit: number = 0;

    constructor(name:string, limit:number) {
      this.name = name;
      this.limit = limit;
    }
  }
  