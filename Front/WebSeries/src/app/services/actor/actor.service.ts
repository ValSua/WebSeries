import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ActoresResponse } from '../../models/Actor/actores-response';
import { CreateResponse } from '../../models/Actor/create-response';
import { DeleteResponse } from '../../models/Actor/delete-response';
import { CreateActorDto } from '../../models/Actor/updateActorDto';
import { GetActorDto } from '../../models/Actor/getActorDto';

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  private _baseUrl = 'https://webseries-egdyamdsh7bwh9dx.eastus-01.azurewebsites.net/api';

  //private http = inject(HttpClient);
  constructor(private http: HttpClient) { }

  getActores(): Observable<ActoresResponse> {
    return this.http.get<ActoresResponse>(
      `${this._baseUrl}/actores/getActores`,
      { withCredentials: true }
    );
  }

  getActorById(id: string): Observable<GetActorDto> {
    return this.http.get<GetActorDto>(
      `${this._baseUrl}/actores/getActorById/${id}`);
  }

  createActor(createActor: CreateActorDto): Observable<CreateResponse> {
    return this.http.post<CreateResponse>(
      `${this._baseUrl}/actores/createActor`,
      createActor
    );
  }

  updateActor(id: string, updateActor: CreateActorDto): Observable<any> {
    return this.http.put(
      `${this._baseUrl}/actores/updateActor/${id}`,
      updateActor
    );
  }

  deleteActor(id: string): Observable<DeleteResponse> {
    return this.http.put<DeleteResponse>(
      `${this._baseUrl}/actores/deleteActor/${id}`,
      {}
    );
  }
}
