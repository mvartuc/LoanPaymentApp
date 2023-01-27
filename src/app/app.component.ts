import { Component } from '@angular/core';
import { ParentCategory } from './models/category';
import { Parameter } from './models/parameter';
import { CategoryService } from './services/category.service';
import { ParameterService } from './services/parameter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'StajProjesi';
  categories: ParentCategory[] = [];
  parameters: Parameter[] = [];

  constructor(
    private categoryService: CategoryService,
    private parameterService: ParameterService
  ) {}

  ngOnInit(): void {
    this.categoryService
      .getParentCategories()
      .subscribe((result: ParentCategory[]) => (this.categories = result));

    this.parameterService
      .getAllParameters()
      .subscribe((result: Parameter[]) => (this.parameters = result));
  }
}
