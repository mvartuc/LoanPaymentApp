import { Component } from '@angular/core';
import { ParentCategory } from './models/category';
import { CategoryService } from './services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'StajProjesi';
  categories: ParentCategory[] = [];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.categoryService
      .getParentCategories()
      .subscribe((result: ParentCategory[]) => (this.categories = result));
  }
}
