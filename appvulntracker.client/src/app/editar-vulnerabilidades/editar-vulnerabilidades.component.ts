import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { VulnerabilidadService } from '../vulnerabilidades/vulnerabilidad.service';
import { NgForm } from '@angular/forms';
import { EditarVulnerabilidadesService } from './editar-vulnerabilidades.service';

@Component({
  selector: 'app-editar-vulnerabilidades',
  standalone: false,
  templateUrl: './editar-vulnerabilidades.component.html',
  styleUrl: './editar-vulnerabilidades.component.css'
})
export class EditarVulnerabilidadesComponent {
  // Importa la vulnerabilidad desde el componente padre (como la vulnerabilidad que se va a editar)
  @Input() vulnerabilidad!: Vulnerabilidad;

  // Permite emitir un evento al componente padre para cerrar el modal/formulario
  @Output() cerrar = new EventEmitter<void>();

  // Variables para mostrar mensajes en la interfaz
  mensaje = '';
  errorMessage = '';
  cargando = false;

  // Inyecta el servicio que contiene la lógica de llamada HTTP al backend
  constructor(private editarService: EditarVulnerabilidadesService) { }

  // Función que se ejecuta cuando se envía el formulario para editar la vulnerabilidad
  editarVulnerabilidad(form: NgForm) {
    // Verifica si el formulario es inválido (hay campos vacíos o incorrectos)
    if (form.invalid) {
      this.errorMessage = 'Por favor completa todos los campos correctamente.';
      return; // Sale de la función si el formulario es inválido
    }

    this.cargando = true; // Activa el estado de carga

    // Actualiza la fecha de edición
    this.vulnerabilidad.fechaActualizacion = new Date();

    // Llama al backend para editar la vulnerabilidad
    this.editarService.editarVulnerabilidad(this.vulnerabilidad).subscribe({
      next: (res) => {
        // Si la edición es exitosa, muestra un mensaje de éxito
        this.mensaje = 'Vulnerabilidad actualizada.';
        this.errorMessage = '';
        this.cargando = false; // Finaliza el estado de carga

        // Espera 1 segundo para dar tiempo a mostrar el mensaje, luego:
        setTimeout(() => {
          this.cerrar.emit(); // Emite el evento para cerrar el modal
          window.location.reload(); // Recarga la página para ver los cambios reflejados
        }, 1000);
      },
      error: (err) => {
        // Si ocurre un error, muestra un mensaje y lo imprime en consola
        this.errorMessage = 'Error al actualizar.';
        console.error(err);
        this.cargando = false;
      }
    });
  }

  // Función que se ejecuta cuando el usuario pulsa "Cancelar"
  // Simplemente cierra el modal sin hacer cambios
  cancelarEdicion() {
    this.cerrar.emit();
  }
}
