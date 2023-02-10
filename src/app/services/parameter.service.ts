import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Parameter } from '../models/parameter';

@Injectable({
  providedIn: 'root',
})
export class ParameterService {
  private url = 'Parameter';
  private prefix = `${environment.apiUrl}/${this.url}`;
  private parameters: Parameter[] | null = null;

  constructor(private http: HttpClient) {}

  public getAllParameters(): Observable<Parameter[]> {
    if (this.parameters) {
      return of(this.parameters);
    }
    return this.http.get<Parameter[]>(`${this.prefix}/GetParams`).pipe(
      tap((parameters) => {
        this.parameters = parameters;
      })
    );
  }

  public getAllParametersByGroupCode(
    groupCode: string
  ): Observable<Parameter[]> {
    return this.getAllParameters().pipe(
      map(parameters => parameters.filter(
        (p) => p.groupCode === groupCode && p.description
      ))
    );
  }
}
