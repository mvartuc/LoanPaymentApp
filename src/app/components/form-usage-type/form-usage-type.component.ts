import { Component, Input, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormControl, NgForm, NgModel, NgModelGroup } from '@angular/forms';
import { Parameter } from 'src/app/models/parameter';
import { SkipSelf } from '@angular/core';
import { ControlContainer} from '@angular/forms';

@Component({
  selector: 'app-form-usage-type',
  templateUrl: './form-usage-type.component.html',
  styleUrls: ['./form-usage-type.component.scss'],
  viewProviders: [ { provide: ControlContainer, useExisting: NgModelGroup } ]
})

export class FormUsageTypeComponent implements OnInit {
  @Input()
  legend!: string;
  @Input()
  usageTypeCode?: string;
  @Input()
  parentGroup?: NgModelGroup;
  @Output()
  usageTypeCodeChange = new EventEmitter<string>();
  // @ViewChild('usageTypeSelect') usageTypeSelect!: FormControl;


  @Input()
  usageTypes!: Parameter[];
  
  selectedUsageType: Parameter = new Parameter();
  
  constructor() { }

  ngOnInit(): void {
  }

}
