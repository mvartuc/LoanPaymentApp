import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ParentCategory } from '../models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private url = 'Category';
  private prefix = `${environment.apiUrl}/${this.url}`
  constructor(private http: HttpClient) {}

  public getParentCategories(): Observable<ParentCategory[]> {
    return this.http.get<ParentCategory[]>(`${this.prefix}/GetParents`);
  }
}
