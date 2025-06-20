export interface Vulnerabilidad {
  id_vulnerabilidad: number;
  titulo: string;
  descripcion: string;
  severidad: string;
  estado: string;
  activoAfectado: string;
  fechaCreacion: string;
  fechaActualizacion: string;
  id_reportador: number;
  id_revisor: number;
}

