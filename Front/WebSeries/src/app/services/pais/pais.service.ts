import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CreateResponse } from '../../models/Actor/create-response';
import { DeleteResponse } from '../../models/Actor/delete-response';
import { PaisesResponse } from '../../models/Pais/paises-response';
import { GetPaisDto } from '../../models/Pais/getPaisDto';
import { CreatePaisDto } from '../../models/Pais/updatePaisDto';

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

  getPaisById(id: string): Observable<GetPaisDto> {
    return this.http.get<GetPaisDto>(
      `${this._baseUrl}/paises/getPaisById/${id}`);
  }

  createPais(createPais: CreatePaisDto): Observable<CreateResponse> {
    return this.http.post<CreateResponse>(
      `${this._baseUrl}/paises/createPais`,
      createPais
    );
  }

  updatePais(id: string, updatePais: CreatePaisDto): Observable<any> {
    return this.http.put(
      `${this._baseUrl}/paises/updatePais/${id}`,
      updatePais
    );
  }

  deletePais(id: string): Observable<DeleteResponse> {
    return this.http.put<DeleteResponse>(
      `${this._baseUrl}/paises/deletePais/${id}`,
      {}
    );
  }
}
