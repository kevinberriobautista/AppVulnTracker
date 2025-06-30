import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { TestVulnerabilidadCompleto } from '../modelos/testVulnerabilidadCompleto';
import { NgForm } from '@angular/forms';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { VulnerabilidadService } from '../vulnerabilidades/vulnerabilidad.service';

@Component({
  selector: 'app-crear-vulnerabilidad-por-test',
  templateUrl: './crear-vulnerabilidad-por-test.component.html',
  styleUrls: ['./crear-vulnerabilidad-por-test.component.css'],
  standalone: false
})
export class CrearVulnerabilidadPorTestComponent implements OnInit {
  @Input() testvulnerabilidad!: TestVulnerabilidadCompleto;
  @Output() cerrar = new EventEmitter<void>();

  mensaje = '';
  errorMessage = '';
  cargando = false;

  constructor(private vulnerabilidadService: VulnerabilidadService) { }

  vulnerabilidad: Vulnerabilidad = {
    id_vulnerabilidad: 0,
    titulo: '',
    descripcion: '',
    severidad: 0,
    estado: 0,
    activoAfectado: '',
    fechaCreacion: new Date(),
    fechaActualizacion: new Date(),
    id_reportador: 0,
    id_revisor: 0
  };

  ngOnInit() {
    if (this.testvulnerabilidad) {
      this.vulnerabilidad = {
        id_vulnerabilidad: 0,
        titulo: 'Vulnerabilidad detectada',
        descripcion: `Tipo de vulnerabilidad: ${this.testvulnerabilidad.nombre_tipo}\n, URL testada: ${this.testvulnerabilidad.url}`,
        severidad: 1,
        estado: 0,
        activoAfectado: this.testvulnerabilidad.url,
        fechaCreacion: new Date(),
        fechaActualizacion: new Date(),
        id_reportador: this.testvulnerabilidad.id_usuario,
        id_revisor: 0
      };
    }
  }

  

  crearVulnerabilidadPorTest(form: NgForm) {
    if (form.invalid) {
      this.errorMessage = 'Por favor completa todos los campos correctamente.';
      return;
    }

    this.cargando = true;

    this.vulnerabilidadService.crearVulnerabilidad(this.vulnerabilidad).subscribe({
      next: () => {
        this.mensaje = 'Vulnerabilidad creada con éxito.';
        this.errorMessage = '';
        this.cargando = false;
        setTimeout(() => {
          this.cerrar.emit();
          window.location.reload();
        }, 1000);
      },
      error: (err) => {
        this.errorMessage = 'Error al crear la vulnerabilidad.';
        console.error(err);
        this.cargando = false;
      }
    });
  }

  cancelarCreacion() {
    this.cerrar.emit();
  }
}
