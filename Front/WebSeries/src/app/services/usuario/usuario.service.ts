import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuariosResponse } from '../../models/Usuario/usuarios-response';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private _baseUrl = 'https://webseries-egdyamdsh7bwh9dx.eastus-01.azurewebsites.net/api';

  private http = inject(HttpClient);
  constructor() { }

  getUsuarios(): Observable<UsuariosResponse> {
    return this.http.get<UsuariosResponse>(
      `${this._baseUrl}/usuarios/getUsuarios`
    );
  }


  validatePassword(usuarioId: number, password: string): Observable<any> {
    return this.http.get<boolean>(`${this._baseUrl}/usuarios/validatePassword`, {
      params: {
        id: usuarioId.toString(),
        password: password
      }
    });
  }
}
