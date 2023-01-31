import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Category, ParentCategory } from 'src/app/models/category';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  NgForm,
  NgModel,
  NgModelGroup,
  Validators,
} from '@angular/forms';
import { Parameter } from 'src/app/models/parameter';
import { ParameterService } from 'src/app/services/parameter.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  @ViewChild('f', { static: false }) form!: NgForm;
  @ViewChild('step1', { static: false }) step1!: NgModelGroup;
  @ViewChild('step2', { static: false }) step2!: NgModelGroup;
  // @ViewChild('step3', { static: false }) step3?: NgModelGroup;
  // @ViewChild('step4', { static: false }) step4?: NgModelGroup;
  public product: Product = new Product();
  public stepSubmitted: { [key: number]: boolean } = {};
  public stepToModelGroup: { [key: number]: NgModelGroup } = {}
  public step: number = 1;

  @Input() categories!: ParentCategory[];
  @ViewChild('divClick') divClick?: ElementRef;
  public submitted: Boolean = false;
  @Input() params!: Parameter[];

  constructor(private parameterService: ParameterService) {}

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    this.stepToModelGroup = {
      1: this.step1,
      2: this.step2,
      // 3: this.step3,
      // 4: this.step4
    }
  }

  onSubmit(): void {
    console.log('submitting')
    this.stepSubmitted[this.step] = true;
    let currentFormStep = this.getFormStep();
    if (currentFormStep.valid) {
      console.log(this.product);
      this.step++;
    } else {
      return; // display error msg
    }
  }

  getFormStep(): NgModelGroup {
    return this.stepToModelGroup[this.step];
  }

  getParams(groupCode: string): Parameter[] {
    return this.parameterService.getAllParametersByGroupCode(
      groupCode,
      this.params
    );
  }
  selectCategory(category: Category): void {
    console.log(category);
    this.divClick?.nativeElement.click();
  }

  isDisabled(name: string): boolean {
    switch (name) {
      case 'offer': {
        return !(this.product.category && this.product.usageTypeCode);
      }
      default: {
        return true;
      }
    }
  }

  // next(): void {
  //   let formStep = this.getFormStep();
  //   if (formStep.valid) {
  //     this.step++;
  //   }
  // }
  prev(): void {
    console.log(this.step);
    this.step--;
    console.log(this.step);
  }
}
