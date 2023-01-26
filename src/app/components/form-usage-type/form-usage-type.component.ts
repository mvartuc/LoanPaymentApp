import { Component, Input, OnInit } from '@angular/core';
import { Parameter } from 'src/app/models/parameter';

@Component({
  selector: 'app-form-usage-type',
  templateUrl: './form-usage-type.component.html',
  styleUrls: ['./form-usage-type.component.scss']
})
export class FormUsageTypeComponent implements OnInit {
  @Input()
  legend!: string;

  @Input()
  usageTypes!: Parameter[];
  
  selectedUsageType: Parameter = new Parameter();
  
  constructor() { }

  ngOnInit(): void {
  }

}
