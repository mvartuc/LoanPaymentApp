import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Installment } from '../models/installment';
import { PaymentPlan } from '../models/payment-plan';

@Injectable({
  providedIn: 'root'
})
export class PaymentPlanService {
  private url = 'PaymentPlan';
  private prefix = `${environment.apiUrl}/${this.url}`
  constructor(private http: HttpClient) {}

  generateInstallments(paymentPlan: PaymentPlan): Observable<PaymentPlan> {
    return this.http.post<PaymentPlan>(`${this.prefix}/GenerateInstallments`, paymentPlan);
  }
  
  // public getInstallments(paymentPlan:PaymentPlan): Observable<Installment[]> {
  //   let queryParams = new HttpParams();
  //   queryParams = queryParams.append("paymentPlan", PaymentPlan)
  //   return this.http.get<Installment[]>(`${this.prefix}/GetOffers`, {params: queryParams});
  // }
}
