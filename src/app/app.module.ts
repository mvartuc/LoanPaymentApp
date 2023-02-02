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
