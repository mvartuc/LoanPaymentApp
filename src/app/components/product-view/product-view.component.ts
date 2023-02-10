import { Component, Input, OnInit } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { PaymentPlan } from 'src/app/models/payment-plan';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit {
  @Input() product!: Product;

  constructor() { }

  ngOnInit(): void {
  }

  getObservablePlan():Observable<PaymentPlan> {
    return new Observable((observer: Observer<PaymentPlan>) => {
      observer.next(this.product.paymentPlan!);
      observer.complete();
    })
  }
}
