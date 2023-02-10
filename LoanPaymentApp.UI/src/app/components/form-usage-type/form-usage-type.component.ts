import { Component, Input, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { NgModelGroup } from '@angular/forms';
import { Parameter } from 'src/app/models/parameter';
import { ControlContainer} from '@angular/forms';
import { Observable } from 'rxjs';
import { ParameterService } from 'src/app/services/parameter.service';

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


  usageTypes$: Observable<Parameter[]> = new Observable<Parameter[]>();
    
  constructor(private parameterService:ParameterService) { 
    this.usageTypes$ = this.parameterService.getAllParametersByGroupCode("KullandirimTipi")
  }

  ngOnInit(): void {
  }

}
