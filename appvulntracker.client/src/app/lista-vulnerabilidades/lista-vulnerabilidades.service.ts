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

  obtenerSeveridadYEstado(id: number): Observable<{ estado: string, severidad: string }> {
    return this.http.get<{ estado: string, severidad: string }>(this.apiUrl + '/estado-severidad/' + id)
  }
}
