import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaisesResponse } from '../../models/Pais/paises-response';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

  private _baseUrl = 'https://localhost:44324/api';

  private http = inject(HttpClient);
  constructor() { }

  getPaises(): Observable<PaisesResponse> {
    return this.http.get<PaisesResponse>(
      `${this._baseUrl}/paises/getPaises`
    );
  }
  
}
