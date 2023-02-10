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
import { ProductService } from 'src/app/services/product.service';
import { Observable } from 'rxjs';
import { ProductViewComponent } from '../product-view/product-view.component';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  @ViewChild('f', { static: false }) form!: NgForm;
  @ViewChild('step1', { static: false }) step1!: NgModelGroup;
  @ViewChild('step2', { static: false }) step2!: NgModelGroup;
  public stepSubmitted: { [key: number]: boolean } = {};
  public stepToModelGroup: { [key: number]: NgModelGroup } = {};
  public step: number = 1;

  @Input() categories!: ParentCategory[];
  @Input() product!: Product;

  @ViewChild('divClick') divClick?: ElementRef;
  public submitted: Boolean = false;
  @Input() params!: Parameter[];

  public savedProduct$:Observable<Product> = new Observable<Product>();

  constructor(private parameterService: ParameterService, private productService:ProductService) {}

  ngOnInit(): void {}

  ngAfterViewChecked(): void {
    this.stepToModelGroup = {
      1: this.step1,
      2: this.step2,
      // 3: this.step3,
      // 4: this.step4
    };
  }

  onSubmit(): void {
    console.log('submitting');
    this.stepSubmitted[this.step] = true;
    let currentFormStep = this.getFormStep();
    if (currentFormStep.valid) {
      console.log(this.product);
      this.step++;
      if (this.step === 3) {
        this.savedProduct$ = this.productService.saveProduct(this.product);
      }
    } else {
      currentFormStep.control.markAllAsTouched();
      return; // display error msg
    }
  }

  getFormStep(): NgModelGroup {
    return this.stepToModelGroup[this.step];
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
  prev(): void {
    this.step--;
  }

  print() {
    window.print();
  }
}
