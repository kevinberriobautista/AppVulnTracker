import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HistorialVulnerabilidad } from '../modelos/historialVulnerabilidad';

@Injectable({
  providedIn: 'root'
})
export class HistorialService {
  private apiUrl = 'https://localhost:7256/api/historial';

  constructor(private http: HttpClient) { }

  obtenerHistorial(id_vulnerabilidad: number): Observable<HistorialVulnerabilidad[]> {
    return this.http.get<HistorialVulnerabilidad[]>(this.apiUrl + '/' + id_vulnerabilidad);
  }
}
