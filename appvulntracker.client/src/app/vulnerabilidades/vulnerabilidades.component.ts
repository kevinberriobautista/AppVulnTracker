import { Component } from '@angular/core';
import { VulnerabilidadService } from './vulnerabilidad.service';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vulnerabilidades',
  standalone: false,
  templateUrl: './vulnerabilidades.component.html',
  styleUrl: './vulnerabilidades.component.css'
})
export class VulnerabilidadesComponent {

  vulnerabilidad: Vulnerabilidad = {
    id_vulnerabilidad: 0, // En el backend se sobreescribe al crear la vulnerabilidad
    titulo: '',
    descripcion: '',
    severidad: 0,
    estado: 0,
    activoAfectado: '',
    fechaCreacion: new Date().toISOString(),
    fechaActualizacion: new Date().toISOString(),
    id_reportador: 0,
    id_revisor: 0
  };
  errorMessage: string = ''
  mensaje = '';

  constructor(private vulnerabilidadService: VulnerabilidadService, private router: Router) { }

  crearVulnerabilidad(): void {
    console.log('Objeto enviado:', this.vulnerabilidad);
    this.vulnerabilidadService.crearVulnerabilidad(this.vulnerabilidad).subscribe({
      next: () => {
        this.mensaje = 'Vulnerabilidad registrada con éxito';
        this.router.navigate(['/vulnerabilidades']); // Redirige tras registrar la vulnerabilidad
      },
      error: () => {
        this.mensaje = 'Error al registrar la vulnerabilidad';
      } 
    })
  }
}
