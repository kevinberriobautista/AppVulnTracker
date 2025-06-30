import { Component } from '@angular/core';
import { Vulnerabilidad } from '../modelos/vulnerabilidad';
import { ListaVulnerabilidadesService } from './lista-vulnerabilidades.service';

@Component({
  selector: 'app-lista-vulnerabilidades',
  standalone: false,
  templateUrl: './lista-vulnerabilidades.component.html',
  styleUrl: './lista-vulnerabilidades.component.css'
})
export class ListaVulnerabilidadesComponent {

  resultado: any = null;
  listaVulnerabilidades: Vulnerabilidad[] = [];
  estadoYSeveridadMap: { [id: number]: { estado: string, severidad: string } } = {};

  constructor(
    private listaVulnerabilidadService: ListaVulnerabilidadesService
  ) { }

  ngOnInit(): void {
    this.listaVulnerabilidadService.obtenerVulnerabilidades().subscribe({
      next: data => {
        this.listaVulnerabilidades = data;

        this.listaVulnerabilidades.forEach(vuln => {
          this.listaVulnerabilidadService.obtenerSeveridadYEstado(vuln.id_vulnerabilidad).subscribe({
            next: datos => {
              this.estadoYSeveridadMap[vuln.id_vulnerabilidad] = datos;
            },
            error: () => {
              this.estadoYSeveridadMap[vuln.id_vulnerabilidad] = { estado: 'Desconocido', severidad: 'Desconocida' };
            }
          });
        });
      },
      error: err => console.error('Error cargando la lista de vulnerabilidades.')
    });
  }

  vulnerabilidadSeleccionada?: Vulnerabilidad;
  mostrarModalEditar: boolean = false;

  seleccionarParaEditar(vul: Vulnerabilidad) {
    this.vulnerabilidadSeleccionada = { ...vul }; // Copia segura
    this.mostrarModalEditar = true;
  }

  cerrarModal() {
    this.mostrarModalEditar = false;
  }

  


}
