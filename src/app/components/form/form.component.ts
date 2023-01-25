import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ChildCategory, ParentCategory } from 'src/app/models/category';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  @Input() categories?: ParentCategory[];
  @ViewChild('divClick') divClick?: ElementRef;

  constructor() {}

  ngOnInit(): void {}

  selectCategory(childCategory:ChildCategory): void {
    console.log(childCategory);
    this.divClick?.nativeElement.click();
  }
}
