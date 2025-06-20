import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginService } from './auth/login.service';
import { Usuario } from './modelos/usuario';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {

  usuario$: Observable<Usuario | null>;

  constructor(private loginService: LoginService, private router: Router) {
    this.usuario$ = this.loginService.usuario$; // observable que emite usuario logueado o null
  }

  cerrarSesion() {
    this.loginService.logout();
    this.router.navigate(['/login']);
  }

  title = 'appvulntracker.client';
}
