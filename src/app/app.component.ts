import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ParentCategory } from './models/category';
import { Parameter } from './models/parameter';
import { Product } from './models/product';
import { CategoryService } from './services/category.service';
import { ParameterService } from './services/parameter.service';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'StajProjesi';
  categories: ParentCategory[] = [];
  emptyProduct$: Observable<Product> = new Observable<Product>();
  // parameters: Parameter[] = [];

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService
  ) // private parameterService: ParameterService
  {
    this.emptyProduct$ = this.productService
    .getEmptyProduct();
  }

  ngOnInit(): void {
    this.categoryService
      .getParentCategories()
      .subscribe((result: ParentCategory[]) => (this.categories = result));



    //   this.parameterService
    //     .getAllParameters()
    //     .subscribe((result: Parameter[]) => (this.parameters = result));
    //
  }
}
