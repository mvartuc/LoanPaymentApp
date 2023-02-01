import { Component, Input, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { NgModelGroup } from '@angular/forms';
import { Parameter } from 'src/app/models/parameter';
import { ControlContainer} from '@angular/forms';

@Component({
  selector: 'app-form-usage-type',
  templateUrl: './form-usage-type.component.html',
  styleUrls: ['./form-usage-type.component.scss'],
  viewProviders: [ { provide: ControlContainer, useExisting: NgModelGroup } ]
})

export class FormUsageTypeComponent implements OnInit {
  @Input()
  legend: string ="";
  @Input()
  usageTypeCode: string ="";
  @Output()
  usageTypeCodeChange = new EventEmitter<string>();
  @Input() public isInvalid: boolean = false;
  // @ViewChild('usageTypeSelect') usageTypeSelect!: FormControl;


  @Input()
  usageTypes: Parameter[] = [];
    
  constructor() { }

  ngOnInit(): void {
  }

}
