import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';

@Injectable({
  providedIn: 'root'
})
export class VulnerabilidadService {
  private apiUrl = 'https://localhost:7256/api/vulnerabilidad';

  constructor(private http: HttpClient) { }

  crearVulnerabilidad(test: Vulnerabilidad): Observable<Vulnerabilidad> {
    return this.http.post<Vulnerabilidad>(this.apiUrl + '/crearVulnerabilidad', test);
  }

  obtenerVulnerabilidades(): Observable<Vulnerabilidad[]> {
    return this.http.get<Vulnerabilidad[]>(this.apiUrl + '/lista');
  }
}
