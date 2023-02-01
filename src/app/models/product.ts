import { Category } from "./category";
import { SpecialOffer } from "./special-offer";

export class Product {
    id?: number;
    code: string ="";
    category!: Category;
    specialOffer: SpecialOffer | null = null;
    usageTypeCode: string = "";
}