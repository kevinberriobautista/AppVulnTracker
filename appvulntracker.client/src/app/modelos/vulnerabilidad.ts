export interface Vulnerabilidad {
  id_vulnerabilidad: number;
  titulo: string;
  descripcion: string;
  severidad: number;
  estado: number;
  activoAfectado: string;
  fechaCreacion: string;
  fechaActualizacion: string;
  id_reportador: number;
  id_revisor: number;
}

