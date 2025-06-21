import { Component } from '@angular/core';
import { TestVulnerabilidadesService } from './test-vulnerabilidades.service';
import { TestRequest } from '../modelos/test-request';
import { LoginService } from '../auth/login.service';

@Component({
  selector: 'app-test-vulnerabilidades',
  templateUrl: './test-vulnerabilidades.component.html',
  styleUrls: ['./test-vulnerabilidades.component.css']
})
export class TestVulnerabilidadesComponent {
  constructor(
    private testService: TestVulnerabilidadesService,
    private loginService: LoginService
  ) { }

  ejecutar(tipo: number) {
    const usuario = this.loginService.obtenerUsuario(); // metodo en login.service.ts que devuelve el usuario actual
    const url = prompt('Introduce la URL a testear:');

    if (!url || !usuario) return;

    const test: TestRequest = {
      id_usuario: usuario.id_usuario,
      tipo,
      url
    };

    this.testService.ejecutarTest(test).subscribe({
      next: (id) => alert(`Test ejecutado con ID: ${id}`),
      error: () => alert('Error al ejecutar el test')
    });
  }
}
