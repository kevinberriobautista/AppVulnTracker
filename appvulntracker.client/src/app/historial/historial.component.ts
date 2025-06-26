import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HistorialVulnerabilidad } from '../modelos/historialVulnerabilidad';
import { HistorialService } from './historial.service';

@Component({
  standalone: false,
  selector: 'app-historial-vulnerabilidad',
  templateUrl: './historial.component.html',
  styleUrls: ['./historial.component.css']
})
export class HistorialComponent {

  idVulnerabilidad!: number;
  historial: HistorialVulnerabilidad[] = [];
  cargando = true;
  error = '';

  constructor(private route: ActivatedRoute, private historialService: HistorialService) { }

  ngOnInit(): void {
    this.idVulnerabilidad = +this.route.snapshot.paramMap.get('id')!;
    this.cargarHistorial();
  }

  cargarHistorial() {
    if (!this.idVulnerabilidad) {
      this.error = 'ID de vulnerabilidad no válido';
      this.cargando = false;
      return;
    }

    this.historialService.obtenerHistorial(this.idVulnerabilidad).subscribe({
      next: (data) => {
        this.historial = data;
        this.cargando = false;
      },
      error: (err) => {
        this.error = 'Error al cargar el historial';
        this.cargando = false;
      }
    });
  }
}
