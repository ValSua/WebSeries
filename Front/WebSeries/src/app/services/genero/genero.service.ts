import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CreateResponse } from '../../models/Actor/create-response';
import { DeleteResponse } from '../../models/Actor/delete-response';
import { GenerosResponse } from '../../models/Genero/generos-response';
import { GetGeneroDto } from '../../models/Genero/getGeneroDto';
import { CreateGeneroDto } from '../../models/Genero/updateGeneroDto';

@Injectable({
  providedIn: 'root'
})
export class GeneroService {

  private _baseUrl = 'https://webseries-egdyamdsh7bwh9dx.eastus-01.azurewebsites.net/api';

  private http = inject(HttpClient);
  constructor() { }

  getGeneros(): Observable<GenerosResponse> {
    return this.http.get<GenerosResponse>(
      `${this._baseUrl}/generos/getGeneros`
    );
  }

  getGeneroById(id: string): Observable<GetGeneroDto> {
    return this.http.get<GetGeneroDto>(
      `${this._baseUrl}/generos/getGeneroById/${id}`);
  }

  createGenero(createGenero: CreateGeneroDto): Observable<CreateResponse> {
    return this.http.post<CreateResponse>(
      `${this._baseUrl}/generos/createGenero`,
      createGenero
    );
  }

  updateGenero(id: string, updateGenero: CreateGeneroDto): Observable<any> {
    return this.http.put(
      `${this._baseUrl}/generos/updateGenero/${id}`,
      updateGenero
    );
  }

  deleteGenero(id: string): Observable<DeleteResponse> {
    return this.http.put<DeleteResponse>(
      `${this._baseUrl}/generos/deleteGenero/${id}`,
      {}
    );
  }
}
