export interface TestRequest {
  id_usuario: number;
  tipo: number;     // 1 para XSS, 2 para SQLi, etc.
  url: string;
}
