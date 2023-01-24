import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ParentCategory } from '../models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private url = 'Category';
  constructor(private http: HttpClient) {}
}
