import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, NgModel, NgModelGroup } from '@angular/forms';
import { DatePart } from 'src/app/models/date-part';

@Component({
  selector: 'app-form-datepart',
  templateUrl: './form-datepart.component.html',
  styleUrls: ['./form-datepart.component.scss'],
  viewProviders: [ { provide: ControlContainer, useExisting: NgModelGroup } ]
})
export class FormDatepartComponent implements OnInit {
  @Input() datePart!: DatePart | null;
  @Output() datePartChange = new EventEmitter<DatePart | null>();
  public randomizedName!:string;

  constructor() {
    this.randomizedName = this.getRandomizedName();
  }

  ngOnInit(): void {}

  refreshModel() {
    this.datePartChange.emit(this.datePart);
  }

  isInvalid(model: NgModel): boolean | null {
    return model.invalid && (model.dirty || model.touched);
  }

  getRandomizedName(): string {
    return `${this.datePart?.name}-${(Math.random() + 1).toString(36).substring(7)}`
  }
}
