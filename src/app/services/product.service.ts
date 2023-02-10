import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = 'Product';
  private prefix = `${environment.apiUrl}/${this.url}`;

  constructor(private http: HttpClient) { }

  public getEmptyProduct(): Observable<Product> {
    return this.http.get<Product>(`${this.prefix}/GetEmptyProduct`);
  }

  public saveProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.prefix}/SaveProduct`, product);
  }
}
