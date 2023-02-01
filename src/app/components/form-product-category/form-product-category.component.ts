import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import {
  AbstractControl,
  ControlValueAccessor,
  NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  ValidationErrors,
  Validator,
} from '@angular/forms';
import { Category, ParentCategory } from 'src/app/models/category';

@Component({
  selector: 'app-form-product-category',
  templateUrl: './form-product-category.component.html',
  styleUrls: ['./form-product-category.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: FormProductCategoryComponent,
    },
    {
      provide: NG_VALIDATORS,
      multi: true,
      useExisting: FormProductCategoryComponent,
    },
  ],
})
export class FormProductCategoryComponent
  implements OnInit, ControlValueAccessor, Validator
{
  @Input()
  categories!: ParentCategory[];
  @Input() public isInvalid!: boolean;

  @Input()
  legend!: string;

  selectedCategory?: Category;
  selectionMessage:String = "";

  @ViewChild('divClick') divClick?: ElementRef;

  constructor() {}

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
  }

  onCategoryChange = (category: Category) => {};

  onTouched = () => {};

  touched = false;

  disabled = false;


  onExpandToggle(): void {
    this.markAsTouched();

  }

  selectCategory(category: Category): void {
    this.markAsTouched();
    if (!this.disabled) {
      this.selectedCategory = category;
      this.onCategoryChange(this.selectedCategory);
    }
    this.selectionMessage = category.name;
    this.divClick?.nativeElement.click();
  }

  writeValue(category: Category): void {
    this.selectedCategory = category;
  }

  registerOnChange(onChange: any) {
    this.onCategoryChange = onChange;
  }

  registerOnTouched(onTouched: any) {
    this.onTouched = onTouched;
  }

  markAsTouched() {
    if (!this.touched) {
      this.onTouched();
      this.touched = true;
    }
  }

  setDisabledState(disabled: boolean) {
    this.disabled = disabled;
  }

  validate(control: AbstractControl): ValidationErrors | null {
    const providedCategory = control.value;
    if (!providedCategory) {
      return {
        mustBeValid: {
          providedCategory
        }
      };
    }
    return null;
  }
}
