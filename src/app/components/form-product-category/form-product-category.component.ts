import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import {
  AbstractControl,
  ControlValueAccessor,
  NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  ValidationErrors,
  Validator,
} from '@angular/forms';
import { ChildCategory, ParentCategory } from 'src/app/models/category';

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

  @Input()
  legend!: string;

  selectedCategory?: ChildCategory;
  selectionMessage:String = "SECINIZ";

  @ViewChild('divClick') divClick?: ElementRef;

  constructor() {}

  ngOnInit(): void {}

  onCategoryChange = (childCategory: ChildCategory) => {};

  onTouched = () => {};

  touched = false;

  disabled = false;


  onExpandToggle(): void {
    this.markAsTouched();

  }

  selectCategory(childCategory: ChildCategory): void {
    this.markAsTouched();
    if (!this.disabled) {
      this.selectedCategory = childCategory;
      this.onCategoryChange(this.selectedCategory);
    }
    this.selectionMessage = childCategory.displayName;
    this.divClick?.nativeElement.click();
  }

  writeValue(childCategory: ChildCategory): void {
    this.selectedCategory = childCategory;
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
    const providedChildCategory = control.value;
    if (!this.categories.includes(providedChildCategory)) {
      return {
        mustBeValid: {
          providedChildCategory
        }
      };
    }
    return null;
  }
}
