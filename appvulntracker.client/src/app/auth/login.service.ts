import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Usuario } from '../modelos/usuario';

interface LoginResponse {
  token: string;
  usuario: Usuario;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private baseUrl = 'https://localhost:7256/api/usuario/loginCliente';
  // Guarda el estado actual del usuario, es útil ante otros componentes que deban reaccionar al login/logout
  public usuarioSubject = new BehaviorSubject<Usuario | null>(null);
  // usuario$: es un Observable que pueden usar tus componentes para "escuchar" cambios en el usuario
  public usuario$ = this.usuarioSubject.asObservable();


  // Se inyecta el servicio HttpClient para hacer peticiones
  constructor(private http: HttpClient) {
    // Se intenta leer el usuario guardado en localStorage
    const userJson = localStorage.getItem('usuario');
    // Si hay un usuario guardado, se emite ese usuario con usuarioSubject.next(), para que la app recuerde que el usuario ya está logueado
    if (userJson) {
      this.usuarioSubject.next(JSON.parse(userJson));
    }
  }

  // Metodo login emitira una respuesta de tipo LoginResponse
  login(correo: string, contrasena: string): Observable<LoginResponse> {
    // .pipe permite encadenar operadores a la petición HTTP, es decir, ejecuta una accion secundaria con la respuesta
    return this.http.post<LoginResponse>(this.baseUrl, { correo, contrasena }).pipe(
      // tap permite ejecutar código adicional cuando se recibe la respuesta del servidor
      tap(respuesta => {
        // Guarda el token y el usuario en localStorage (almacenamiento local del navegador)
        // Crea un nuevo objeto usuario con el token incluido, esto es útil para tener todo el usuario y su token en un solo objeto
        const usuarioConToken: Usuario = { ...respuesta.usuario, token: respuesta.token };
        localStorage.setItem('token', respuesta.token);
        // localStorage solo guarda strings, por eso se convierte a JSON con JSON.stringify
        localStorage.setItem('usuario', JSON.stringify(usuarioConToken));
        // Actualiza el estado del usuario, cualquier componente que esté suscrito a usuario$ recibirá automáticamente el nuevo usuario
        this.usuarioSubject.next(usuarioConToken);
      })
    );
  }

  // Método logout
  logout() {
    // Elimina la info de usuario y token del localStorage.
    localStorage.removeItem('token');
    localStorage.removeItem('usuario');
    // Emite null en usuarioSubject para indicar que ya no hay usuario logueado
    this.usuarioSubject.next(null);
  }

  // Método para verificar si el usuario está logueado
  // Devuelve true si existe un token en localStorage (usuario logueado)
  estaLogeado(): boolean {
    // !! convierte el valor en booleano (si existe token es true, si no es false).
    return !!localStorage.getItem('token');
  }

  // Método para obtener el usuario actual
  // Devuelve el usuario actual guardado en el BehaviorSubject, útil para obtener los datos del usuario sin necesidad de suscribirse
  obtenerUsuario(): Usuario | null {
    return this.usuarioSubject.value;
  }
}
