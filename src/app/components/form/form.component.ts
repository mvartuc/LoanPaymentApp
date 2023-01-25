import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ChildCategory, ParentCategory } from 'src/app/models/category';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  public _currentFormGroup!: FormGroup;
  @Input() categories?: ParentCategory[];
  @ViewChild('divClick') divClick?: ElementRef;
  public step: number = 1;
  

  constructor(private formBuilder:FormBuilder) {}

  ngOnInit(): void {
    this.currentFormGroup = 
  }

  get_currentFormGroup(): FormGroup {
    if(this.step == 1)
    {
      return new FormGroup({
        
      })
    }
  }

  selectCategory(childCategory: ChildCategory): void {
    console.log(childCategory);
    this.divClick?.nativeElement.click();
  }

  next(): void {
    this.step++;
  }
  prev(): void {
    this.step--;
  }
}
