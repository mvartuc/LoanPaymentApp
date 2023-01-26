export class Category {
  id!: number;
  code!: number;
  name: String = '';
  description: String = '';
  parentCategoryID!: number;
}

export class ParentCategory {
  id!: number;
  code!: number;
  name: String = '';
  description: String = '';
  childCategories: Category[] = [];
}
