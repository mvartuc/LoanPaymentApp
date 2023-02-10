import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SpecialOffer } from '../models/special-offer';

@Injectable({
  providedIn: 'root',
})
export class SpecialOfferService {
  private url = 'SpecialOffer';
  private prefix = `${environment.apiUrl}/${this.url}`;

  constructor(private http: HttpClient) {}

  public getSpecialOffers(categoryCode:string): Observable<SpecialOffer[]> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("categoryCode", categoryCode)
    return this.http.get<SpecialOffer[]>(`${this.prefix}/GetOffers`, {params: queryParams});
  }
}
