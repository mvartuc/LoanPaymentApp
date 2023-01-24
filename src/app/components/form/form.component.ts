import { Component, Input, OnInit } from '@angular/core';
import { ParentCategory } from 'src/app/models/category';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  @Input() categories?: ParentCategory[];

  constructor() { }

  ngOnInit(): void {
    
  }

}
