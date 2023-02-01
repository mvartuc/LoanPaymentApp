import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { ControlContainer, NgModel, NgModelGroup } from '@angular/forms';
import { delay, Observable } from 'rxjs';
import { Category } from 'src/app/models/category';
import { SpecialOffer } from 'src/app/models/special-offer';
import { SpecialOfferService } from 'src/app/services/special-offer.service';

@Component({
  selector: 'app-form-special-offer',
  templateUrl: './form-special-offer.component.html',
  styleUrls: ['./form-special-offer.component.scss'],
  viewProviders: [ { provide: ControlContainer, useExisting: NgModelGroup } ]
})
export class FormSpecialOfferComponent implements OnInit, OnChanges {
  public specialOffers$!: Observable<SpecialOffer[]>;
  @Input() public category!: Category;
  @Input() public legend: string = "";
  @Input() public disabled: boolean = false;
  @Input() public isInvalid: boolean = false;
  @Output() selectedOfferChange = new EventEmitter<SpecialOffer|null>();
  @Input() selectedOffer: SpecialOffer | null = null;
  @ViewChild('specialOfferNgModel') specialOfferNgModel!: NgModel;

  constructor(private specialOfferService: SpecialOfferService) {}

  ngOnInit(): void {
    this.refreshOffers();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['category'])
    {
      let newCategory = changes['category'].currentValue as Category;
      let oldCategory = changes['category'].previousValue as Category;
      let categoryChanged = oldCategory?.code != newCategory?.code;
      let isFirst = changes['category'].isFirstChange() || !oldCategory;
      if (!isFirst && categoryChanged) {
        console.log('category type changed')
        this.selectedOffer = null;
        this.refreshModel();
      }
      this.refreshOffers();
    }

  }

  refreshOffers() {
    if (this.category) {
      this.specialOffers$ = this.specialOfferService.getSpecialOffers(
        this.category.code
      );
    }
  }

  

  refreshModel() {
    this.selectedOfferChange.emit(this.selectedOffer);
  }

  // getOffers(): SpecialOffer[] {
  //   // return this.specialOffers.filter(
  //   //   (o) => o.productCategoryId === this.category.id
  //   // );

  //   return this.specialOffers;
  // }
}
