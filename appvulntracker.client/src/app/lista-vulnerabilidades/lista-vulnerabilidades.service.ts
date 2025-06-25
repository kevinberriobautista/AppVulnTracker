import { Injectable } from '@angular/core';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ListaVulnerabilidadesService {
  private apiUrl = 'https://localhost:7256/api/vulnerabilidad';

  constructor(private http: HttpClient) { }

  obtenerVulnerabilidades(): Observable<Vulnerabilidad[]> {
    return this.http.get<Vulnerabilidad[]>(this.apiUrl + '/lista');
  }

  obtenerSeveridadYEstado(id: number): Observable<{ estado: number, severidad: number }> {
    return this.http.get<{ estado: number, severidad: number }>(this.apiUrl + '/estado-severidad/' + {id})
  }
}
