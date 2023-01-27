import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Parameter } from '../models/parameter';

@Injectable({
  providedIn: 'root',
})
export class ParameterService {
  private url = 'Parameter';
  private prefix = `${environment.apiUrl}/${this.url}`;

  constructor(private http: HttpClient) {}

  public getAllParameters(): Observable<Parameter[]> {
    return this.http.get<Parameter[]>(`${this.prefix}/GetParams`);
  }

  public getAllParametersByGroupCode(groupCode: string, params: Parameter[]): Parameter[] {
    return params.filter((p) => p.groupCode === groupCode && p.description);
  }
}
