import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Category, ParentCategory } from 'src/app/models/category';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Parameter } from 'src/app/models/parameter';
import { ParameterService } from 'src/app/services/parameter.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  public form!: FormGroup;
  @Input() categories!: ParentCategory[];
  @ViewChild('divClick') divClick?: ElementRef;
  public step: number = 1;
  public submitted: Boolean = false;
  @Input() params!: Parameter[];

  constructor(private formBuilder: FormBuilder, private parameterService:ParameterService) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      formStep1: this.formBuilder.group({
        category: this.formBuilder.control(null, [Validators.required]),
      }),
    });
  }

  getParams(groupCode: string): Parameter[] {
    return this.parameterService.getAllParametersByGroupCode(groupCode, this.params)
  }
  selectCategory(category: Category): void {
    console.log(category);
    this.divClick?.nativeElement.click();
  }

  next(): void {
    this.step++;
  }
  prev(): void {
    this.step--;
  }
}
