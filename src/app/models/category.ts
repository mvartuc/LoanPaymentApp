export class Category {
  id!: number;
  code!: string;
  name: string = '';
  description: string = '';
  parentCategoryID!: number;
}

export class ParentCategory {
  id!: number;
  code!: string;
  name: string = '';
  description: string = '';
  childCategories: Category[] = [];
}
