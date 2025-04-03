import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateResponse } from '../../models/Actor/create-response';
import { DeleteResponse } from '../../models/Actor/delete-response';
import { DirectoresResponse } from '../../models/Director/directores-response';
import { GetDirectorDto } from '../../models/Director/getDirectorDto';
import { CreateDirectorDto } from '../../models/Director/updateDirectorDto';

@Injectable({
  providedIn: 'root'
})
export class DirectorService {

  private _baseUrl = 'https://localhost:44324/api';

  private http = inject(HttpClient);
  constructor() { }

  getDirectores(): Observable<DirectoresResponse> {
    return this.http.get<DirectoresResponse>(
      `${this._baseUrl}/directores/getDirectores`
    );
  }

  getDirectorById(id: string): Observable<GetDirectorDto> {
    return this.http.get<GetDirectorDto>(
      `${this._baseUrl}/directores/getDirectorById/${id}`);
  }

  createDirector(createDirector: CreateDirectorDto): Observable<CreateResponse> {
    return this.http.post<CreateResponse>(
      `${this._baseUrl}/directores/createDirector`,
      createDirector
    );
  }

  updateDirector(id: string, updateDirector: CreateDirectorDto): Observable<any> {
    return this.http.put(
      `${this._baseUrl}/directores/updateDirector/${id}`,
      updateDirector
    );
  }

  deleteDirector(id: string): Observable<DeleteResponse> {
    return this.http.put<DeleteResponse>(
      `${this._baseUrl}/directores/deleteDirector/${id}`,
      {}
    );
  }
}
