import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ContentComponent } from './components/content/content.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormComponent } from './components/form/form.component';
import { FormProductCategoryComponent } from './components/form-product-category/form-product-category.component';
import { FormUsageTypeComponent } from './components/form-usage-type/form-usage-type.component';
import { FormSpecialOfferComponent } from './components/form-special-offer/form-special-offer.component';
import { FormPaymentPlanComponent } from './components/form-payment-plan/form-payment-plan.component';
import { FormRepaymentTermComponent } from './components/form-repayment-term/form-repayment-term.component';
import { FormDatepartComponent } from './components/form-datepart/form-datepart.component';
import { PaymentPlanViewComponent } from './components/payment-plan-view/payment-plan-view.component';
import { ProductViewComponent } from './components/product-view/product-view.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContentComponent,
    FooterComponent,
    FormComponent,
    FormProductCategoryComponent,
    FormUsageTypeComponent,
    FormSpecialOfferComponent,
    FormPaymentPlanComponent,
    FormRepaymentTermComponent,
    FormDatepartComponent,
    PaymentPlanViewComponent,
    ProductViewComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
