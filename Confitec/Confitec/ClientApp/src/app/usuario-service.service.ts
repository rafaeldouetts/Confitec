import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from './model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(
    private http: HttpClient
  ) { }

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${environment.baseUrl}/Usuario`);
  }

  deleteUsuario(id:number): Observable<number> {
    return this.http.delete<number>(`${environment.baseUrl}/Usuario/${id}`);
  }

  postUsuario(usuario:Usuario): Observable<any>{
    return this.http.post(`${environment.baseUrl}/Usuario/`, usuario);
  }

  putUsuario(usuario:Usuario): Observable<any>{
    return this.http.put(`${environment.baseUrl}/Usuario/`, usuario)
  }

}
