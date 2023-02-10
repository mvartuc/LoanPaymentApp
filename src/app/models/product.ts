import { Category } from "./category";
import { PaymentPlan } from "./payment-plan";
import { SpecialOffer } from "./special-offer";

export class Product {
    id?: number;
    code: string ="";
    category!: Category;
    specialOffer: SpecialOffer | null = null;
    usageTypeCode: string = "";
    paymentPlanID!: number;
    paymentPlan: PaymentPlan | null = new PaymentPlan();
}