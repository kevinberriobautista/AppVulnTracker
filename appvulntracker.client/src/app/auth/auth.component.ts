import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from '../modelos/usuario';
import { LoginService } from './login.service';

@Component({
  selector: 'app-auth',
  standalone: false,
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  correo: string = '';
  contrasena: string = '';
  error: string = '';

  constructor(private loginService: LoginService, private router: Router) { }

  onSubmit() {
    this.loginService.login(this.correo, this.contrasena).subscribe({
      next: (respuesta) => {
        // Si el login es exitoso, redirige al usuario a la página principal
        localStorage.setItem('token', respuesta.token);
        this.router.navigate(['/']);
        console.log(respuesta.token);
      },
      error: () => {
        // Si hay un error, muestra un mensaje de error
        this.error = 'Correo o contraseña incorrectos';
      }
    });
  }
}
