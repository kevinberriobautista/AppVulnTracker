import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestRequest } from '../modelos/test-request';
import { TestVulnerabilidad } from '../modelos/testVulnerabilidad';

@Injectable({
  providedIn: 'root'
})
export class TestVulnerabilidadesService {
  private apiUrl = 'https://localhost:7256/api/testvulnerabilidad';

  constructor(private http: HttpClient) { }

  ejecutarTest(test: TestRequest): Observable<TestVulnerabilidad> {
    return this.http.post<TestVulnerabilidad>(`${this.apiUrl}/ejecutar`, test);
  }
}
