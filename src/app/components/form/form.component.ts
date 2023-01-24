import { Component, Input, OnInit } from '@angular/core';
import { ChildCategory, ParentCategory } from 'src/app/models/category';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  @Input() categories?: ParentCategory[];

  constructor() {}

  ngOnInit(): void {}

  selectCategory(childCategory:ChildCategory): void {
    console.log(childCategory);
  }
}
