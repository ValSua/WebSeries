import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActoresResponse } from '../../models/Actor/actores-response';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

  private _baseUrl = 'https://localhost:44324/api';

  private http = inject(HttpClient);
  constructor() { }

  getPaises(): Observable<ActoresResponse> {
    return this.http.get<ActoresResponse>(
      `${this._baseUrl}/actores/getActores`
    );
  }
  
}
