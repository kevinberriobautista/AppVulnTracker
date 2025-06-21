import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestRequest } from '../modelos/test-request';

@Injectable({
  providedIn: 'root'
})
export class TestVulnerabilidadesService {
  private apiUrl = 'https://localhost:7256/api/testvulnerabilidad';

  constructor(private http: HttpClient) { }

  ejecutarTest(test: TestRequest): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/ejecutar`, test);
  }
}
