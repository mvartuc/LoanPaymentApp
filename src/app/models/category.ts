export class Category {
  id!: number;
  code!: string;
  name: String = '';
  description: String = '';
  parentCategoryID!: number;
}

export class ParentCategory {
  id!: number;
  code!: string;
  name: String = '';
  description: String = '';
  childCategories: Category[] = [];
}
