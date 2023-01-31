import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { ControlContainer, NgModelGroup } from '@angular/forms';
import { Observable } from 'rxjs';
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
  @Input() public category?: Category;
  @Input() public legend!: string;
  @Input() public disabled!: boolean;
  @Output() selectedOfferChange = new EventEmitter<SpecialOffer>();
  @Input() selectedOffer?: SpecialOffer;

  constructor(private specialOfferService: SpecialOfferService) {}

  ngOnInit(): void {
    this.refreshOffers();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['category']) {
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

  // getOffers(): SpecialOffer[] {
  //   // return this.specialOffers.filter(
  //   //   (o) => o.productCategoryId === this.category.id
  //   // );

  //   return this.specialOffers;
  // }
}
