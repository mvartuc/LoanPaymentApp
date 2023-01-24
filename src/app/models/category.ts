export enum ParentCategoryEnum {
  AdatliKredi,
  TaksitliKredi,
}
export enum ChildCategoryEnum {
  RotatifKredi,
  IsletmeIhtiyacKredisi,
}

export class ChildCategory {
  id?: number;
  code: number = 0;
  name: String = '';
  displayName: String = '';
  description: String = '';
  childCategoryEnum: ChildCategoryEnum = 0;
  parentCategoryID?: number;
}

export class ParentCategory {
  id?: number;
  code: number = 0;
  name: String = '';
  displayName: String = '';
  description: String = '';
  parentCategoryEnum: ParentCategoryEnum = 0;
  childCategories: ChildCategory[] = [];
}
