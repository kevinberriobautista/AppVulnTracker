import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EditarVulnerabilidadesService {

  private apiUrl = 'https://localhost:7256/api/vulnerabilidad';
  constructor(private http: HttpClient) { }

  editarVulnerabilidad(vulnerabilidad: Vulnerabilidad): Observable<Vulnerabilidad> {
    return this.http.put<Vulnerabilidad>(this.apiUrl + '/modificarVulnerabilidad', vulnerabilidad);
  }
}
