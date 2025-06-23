import { Component } from '@angular/core';
import { TestVulnerabilidadesService } from './test-vulnerabilidades.service';
import { TestRequest } from '../modelos/test-request';
import { LoginService } from '../auth/login.service';
import { UsuarioService } from '../usuarios/usuario.service';

@Component({
  standalone: false, // <- importante si lo vas a declarar en AppModule
  selector: 'app-test-vulnerabilidades',
  templateUrl: './test-vulnerabilidades.component.html',
  styleUrls: ['./test-vulnerabilidades.component.css']
})
export class TestVulnerabilidadesComponent {
  resultado: any = null;

  constructor(
    private testService: TestVulnerabilidadesService,
    private loginService: LoginService,
    private usuarioService: UsuarioService
  ) { }

  ejecutar(tipo: string) {
    const tiposMap: { [key: string]: number } = {
      xss: 1,
      sqli: 2,
      csrf: 3,
      lfi: 4,
      rce: 5,
      'open-redirect': 6
    };

    const tipoNum = tiposMap[tipo];

    if (!tipoNum) {
      alert('Tipo de test inválido');
      return;
    }

    const usuario = this.loginService.obtenerUsuario();
    const url = prompt('Introduce la URL a testear:');

    if (!url || !usuario) return;

    const test: TestRequest = {
      id_usuario: usuario.id_usuario,
      tipo: tipoNum,
      url
    };

    this.testService.ejecutarTest(test).subscribe({
      next: (data) => {
        this.resultado = data;
        this.usuarioService.getUsuarioPorId(data.id_usuario).subscribe({
          next: (usuarioData) => {
            // Añadimos el nombre de usuario dentro del resultado para mostrarlo
            this.resultado = { ...this.resultado, nombre_usuario: usuarioData.nombre };
            // Esto crea un nuevo objeto y ayuda a Angular a detectar el cambio
            console.log('Resultado completo con nombre usuario:', this.resultado);
          },
          error: () => {
            console.warn('No se pudo obtener el nombre del usuario');
          }
        });

        alert(`Test ejecutado con ID: ${data.id_testvulnerabilidad || 'desconocido'}`);
      },
      error: () => alert('Error al ejecutar el test')
    });

  }
}
