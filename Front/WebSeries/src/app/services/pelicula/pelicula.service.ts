import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { PeliculasResponse } from '../../models/Pelicula/peliculas-response';
import { CreateResponse } from '../../models/Actor/create-response';
import { DeleteResponse } from '../../models/Actor/delete-response';
import { GetPeliculaDto } from '../../models/Pelicula/getPeliculaDto';
import { CreatePeliculaDto } from '../../models/Pelicula/updatePeliculaDto';

@Injectable({
  providedIn: 'root'
})
export class PeliculaService {

  private _baseUrl = 'https://webseries-egdyamdsh7bwh9dx.eastus-01.azurewebsites.net/api';

  private http = inject(HttpClient);
  constructor() { }

  getPeliculas(): Observable<PeliculasResponse> {
    return this.http.get<PeliculasResponse>(
      `${this._baseUrl}/peliculas/getPeliculas`
    );
  }

  getPeliculaById(id: string): Observable<GetPeliculaDto> {
    return this.http.get<GetPeliculaDto>(
      `${this._baseUrl}/peliculas/getPeliculaById/${id}`);
  }

  createPelicula(createPelicula: CreatePeliculaDto): Observable<CreateResponse> {
    return this.http.post<CreateResponse>(
      `${this._baseUrl}/peliculas/createPelicula`,
      createPelicula
    );
  }

  updatePelicula(id: string, updatePelicula: CreatePeliculaDto): Observable<any> {
    return this.http.put(
      `${this._baseUrl}/peliculas/updatePelicula/${id}`,
      updatePelicula
    );
  }

  deletePelicula(id: string): Observable<DeleteResponse> {
    return this.http.put<DeleteResponse>(
      `${this._baseUrl}/peliculas/deletePelicula/${id}`,
      {}
    );
  }
}
